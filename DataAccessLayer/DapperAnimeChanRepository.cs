using Dapper;
using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class DapperAnimeChanRepository : IRepository<AnimeChanRepo>
{
    private readonly string connectionString;

    internal DapperAnimeChanRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    private IDbConnection CreateConnection() => new SqlConnection(connectionString);


    public void Create(AnimeChanRepo chan)
    {
        using (var conn = CreateConnection())
        {
            conn.Open();
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    // 1. Сначала создаём персонажа
                    const string sqlChan = @" 
                    INSERT INTO AnimeChans (FirstName, LastName, Age, Height, Weight, Size)
                    VALUES (@FirstName, @LastName, @Age, @Height, @Weight, @Size);
                    SELECT CAST(SCOPE_IDENTITY() AS int);";

                    chan.Id = conn.QuerySingle<int>(sqlChan, chan, tx);

                    if (chan.Skills != null && chan.Skills.Any())
                    {

                        // 2. Получаем ВСЕ нужные навыки ОДНИМ запросом
                        var skillNames = chan.Skills.Select(s => s.Name).Distinct().ToList();

                        const string sqlGetSkills = "SELECT Id, Name FROM Skills WHERE Name IN @Names";
                        var existingSkills = conn.Query<SkillRepo>(sqlGetSkills, new { Names = skillNames }, tx)
                                                .ToList();

                        // 3. Создаём недостающие навыки
                        var newSkillNames = skillNames.Except(existingSkills.Select(s => s.Name)).ToList();

                        foreach (var skillName in newSkillNames)
                        {
                            const string sqlInsertSkill = @"
                            INSERT INTO Skills (Name) VALUES (@Name);
                            SELECT CAST(SCOPE_IDENTITY() AS int);";

                            var newSkillId = conn.QuerySingle<int>(sqlInsertSkill, new { Name = skillName }, tx);
                            existingSkills.Add(new SkillRepo { Id = newSkillId, Name = skillName });
                        }

                        var skillsDict = existingSkills.ToDictionary(s => s.Name, s => s.Id);

                        foreach (var skillName in skillNames)
                        {
                            if (skillsDict.TryGetValue(skillName, out var skillId))
                            {
                                const string sqlLink = @"INSERT INTO SkillChans (AnimeChansRepoId, SkillsId) 
                                VALUES (@ChanId, @SkillId);";
                                conn.Execute(sqlLink, new { ChanId = chan.Id, SkillId = skillId }, tx);
                            }

                        }
                    }
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }
    }

    public IEnumerable<AnimeChanRepo> ReadAll()
    {
        const string sql = @" 
        SELECT 
            a.Id as ChanId,
            a.FirstName, a.LastName, a.Age, a.Height, a.Weight, a.Size,
            s.Id as SkillId,
            s.Name as SkillName
        FROM AnimeChans a
        LEFT JOIN SkillChans sc ON a.Id = sc.AnimeChansRepoId
        LEFT JOIN Skills s ON s.Id = sc.SkillsId";


        using (var conn = CreateConnection())
        {
            var results = conn.Query(sql).ToList();
            var dict = new Dictionary<int, AnimeChanRepo>();

            foreach (dynamic row in results)
            {
                int chanId = row.ChanId;

                if (!dict.TryGetValue(chanId, out var animeChan))
                {
                    animeChan = new AnimeChanRepo
                    {
                        Id = chanId,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        Age = row.Age,
                        Height = row.Height,
                        Weight = row.Weight,
                        Size = row.Size,
                        Skills = new List<SkillRepo>()
                    };
                    dict[chanId] = animeChan;
                    Debug.WriteLine($"Создан персонаж: {chanId} - {row.FirstName} {row.LastName}");
                }

                // Добавляем навык если он есть
                if (row.SkillId != null && row.SkillId != 0)
                {
                    var skill = new SkillRepo
                    {
                        Id = row.SkillId,
                        Name = row.SkillName
                    };

                    if (!animeChan.Skills.Any(s => s.Id == skill.Id))
                    {
                        animeChan.Skills.Add(skill);
                        Debug.WriteLine($"Добавлен навык: {skill.Name} к персонажу {chanId}");
                    }
                }
            }

            foreach (var chan in dict.Values)
            {
                Debug.WriteLine($"Персонаж {chan.Id}: {chan.Skills.Count} навыков");
            }

            return dict.Values.ToList();
        }
    }


    public AnimeChanRepo ReadById(int id)
    {
        ////Выбирает тянку вместе с её скиллами
        //const string sqlChan = @"SELECT * FROM AnimeChans WHERE Id = @Id;";

        //using (var conn = CreateConnection())
        //{
        //    var chan = conn.QuerySingleOrDefault<AnimeChanRepo>(sqlChan, new { Id = id });

        //    return chan;
        //}

        {
            const string sql = @" 
            SELECT 
                a.Id as ChanId,
                a.FirstName, a.LastName, a.Age, a.Height, a.Weight, a.Size,
                s.Id as SkillId,
                s.Name as SkillName
            FROM AnimeChans a
            LEFT JOIN SkillChans sc ON a.Id = sc.AnimeChansRepoId
            LEFT JOIN Skills s ON s.Id = sc.SkillsId
            WHERE a.Id = @Id";

            using (var conn = CreateConnection())
            {
                var results = conn.Query(sql, new { Id = id }).ToList();

                if (!results.Any())
                    return null;

                // Создаём персонажа из первой строки
                var firstRow = results[0];
                var animeChan = new AnimeChanRepo
                {
                    Id = firstRow.ChanId,
                    FirstName = firstRow.FirstName,
                    LastName = firstRow.LastName,
                    Age = firstRow.Age,
                    Height = firstRow.Height,
                    Weight = firstRow.Weight,
                    Size = firstRow.Size,
                    Skills = new List<SkillRepo>()
                };

                // Добавляем все навыки
                foreach (dynamic row in results)
                {
                    if (row.SkillId != null && row.SkillId != 0)
                    {
                        var skill = new SkillRepo
                        {
                            Id = row.SkillId,
                            Name = row.SkillName
                        };

                        if (!animeChan.Skills.Any(s => s.Id == skill.Id))
                        {
                            animeChan.Skills.Add(skill);
                        }
                    }
                }

                return animeChan;
            }
        }
    }


    public void Update(AnimeChanRepo chan)
    {

        using (var conn = CreateConnection())
        {
            conn.Open();
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    // 1. Обновляем тянку
                    const string sqlUpdateChan = @"
                    UPDATE AnimeChans
                    SET FirstName = @FirstName,
                        LastName  = @LastName,
                        Age       = @Age,
                        Height    = @Height,
                        Weight    = @Weight,
                        Size      = @Size
                    WHERE Id = @Id;";

                    conn.Execute(sqlUpdateChan, chan, tx);

                    // 2. Обновляем навыки (если они есть)
                    if (chan.Skills != null)
                    {
                        // Удаляем все старые связи
                        const string sqlDeleteLinks = @"
                        DELETE FROM SkillChans 
                        WHERE AnimeChansRepoId = @ChanId";

                        conn.Execute(sqlDeleteLinks, new { ChanId = chan.Id }, tx);

                        // Создаём новые связи
                        foreach (var skill in chan.Skills)
                        {
                            const string sqlInsertLink = @"
                            INSERT INTO SkillChans (AnimeChansRepoId, SkillsId) 
                            VALUES (@ChanId, @SkillId)";

                            conn.Execute(sqlInsertLink, new
                            {
                                ChanId = chan.Id,
                                SkillId = skill.Id
                            }, tx);
                        }
                    }

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }
    }

    public void Delete(AnimeChanRepo chan)
    {
        if (chan == null) return;

            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        //Находим нужную тянку
                        const string sqlDeleteChan = @"DELETE FROM AnimeChans WHERE Id = @Id;";

                        conn.Execute(sqlDeleteChan, new { Id = chan.Id }, tx);

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
            return;
    }

    public void DeleteAll()
    {
        using (var conn = CreateConnection())
        {
            conn.Open();
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    conn.Execute("DELETE FROM AnimeChans", transaction: tx);

                    tx.Commit();

                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }
    }
}
