using Dapper;
using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System.Data;

public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject, new()
{
    private readonly string connectionString = @"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nubik\Documents\IloveGit\Chans\DataAccessLayer\AnimeChanDataBase.mdf;Integrated Security = True";

    private IDbConnection CreateConnection() => new SqlConnection(connectionString);

    ///<summary>Добавляет запись в БД </summary>
    /// <param name="entity">объект, который добавится в БД</param>
    public void Create(T entity)
    {
        if (entity is AnimeChanRepo chan)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    { //Добавляем тянку
                        const string sqlChan = @" 
                        INSERT INTO AnimeChans (FirstName, LastName, Age, Height, Weight, Size)
                        VALUES (@FirstName, @LastName, @Age, @Height, @Weight, @Size);
                        SELECT CAST(SCOPE_IDENTITY() AS int);";

                        chan.Id = conn.QuerySingle<int>(sqlChan, chan, tx); //Присваиваем id для тянки (экземплярам класса)

                        if (chan.Skills != null && chan.Skills.Any())
                        {
                            //Добавляем её скиллы
                            const string sqlSkill = @"
                            INSERT INTO Skills (Name, AnimeChanRepoId)
                            VALUES (@Name, @AnimeChanRepoId);";

                            foreach (var s in chan.Skills)
                            {
                                s.AnimeChanRepoId = chan.Id; //связываем скилл и тянку по id
                                conn.Execute(sqlSkill, new { Name = s.Name, AnimeChanRepoId = s.AnimeChanRepoId }, tx);
                            }
                        }

                        tx.Commit(); //Если всё ок
                    }
                    catch
                    {
                        tx.Rollback(); //Если не ок
                        throw;
                    }
                }
            }

            return;
        }
    }

    ///<summary>Читает все записи в БД</summary>
    /// <returns>Возвращает все записи из БД</returns>
    public IEnumerable<T> ReadAll()
    {
        if (typeof(T) == typeof(AnimeChanRepo))
        {
            //Выбирает тянку вместе с её скиллами
            const string sql = @" 
            SELECT a.Id, a.FirstName, a.LastName, a.Age, a.Height, a.Weight, a.Size,
                   s.Id, s.Name, s.AnimeChanRepoId
            FROM AnimeChans a
            LEFT JOIN Skills s ON s.AnimeChanRepoId = a.Id;";

            using (var conn = CreateConnection())
            {
                var dict = new Dictionary<int, AnimeChanRepo>();

                conn.Query<AnimeChanRepo, SkillRepo, AnimeChanRepo>(
                    sql,
                    (chan, skill) =>
                    {
                        if (!dict.TryGetValue(chan.Id, out var current))
                        {
                            current = chan;
                            current.Skills = new List<SkillRepo>();
                            dict.Add(current.Id, current);
                        }

                        if (skill != null && skill.Id != 0)
                            current.Skills.Add(skill);

                        return current;
                    },
                    splitOn: "Id"
                );

                return dict.Values.Cast<T>().ToList();
            }

        }
        //Для остальных
        using (var conn2 = CreateConnection())
        {
            string tableName = typeof(T).Name;
            tableName = tableName.Replace("Repo", "s");

            string sql = $"SELECT * FROM {tableName}";
            return conn2.Query<T>(sql).ToList();
        }
    }


    ///<summary>Читает запись по id</summary>
    /// <param name="id">id, по которому ищут нужный объект</param>
    /// /// <returns>Возвращает нужную запись из БД</returns>
    public T ReadById(int id)
    {
        if (typeof(T) == typeof(AnimeChanRepo))
        {
            //Выбирает тянку вместе с её скиллами
            const string sqlChan = @"SELECT * FROM AnimeChans WHERE Id = @Id;";
            const string sqlSkills = @"SELECT * FROM Skills WHERE AnimeChanRepoId = @Id;";

            using (var conn = CreateConnection())
            {
                var chan = conn.QuerySingleOrDefault<AnimeChanRepo>(sqlChan, new { Id = id });
                if (chan == null) return null;

                var skills = conn.Query<SkillRepo>(sqlSkills, new { Id = id }).ToList();
                chan.Skills = skills;

                return chan as T;
            }
        }

        // Это для этих там (для остальных)
        using (var conn = CreateConnection())
        {
            return conn.QuerySingleOrDefault<T>("SELECT * FROM " + typeof(T).Name + " WHERE Id = @Id", new { Id = id });
        }
    }

    ///<summary>Изменяет данные у записи </summary>
    /// <param name="obj">объект с измененными свойствами</param>
    public void Update(T entity)
    {
        if (entity is AnimeChanRepo chan)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        //Обновляем тянку
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


                        if (chan.Skills != null && chan.Skills.Any())
                        {
                            const string sqlInsertSkill = @"
                            UPDATE Skills (Name, AnimeChanRepoId)
                            VALUES (@Name, @AnimeChanRepoId);";

                            foreach (var s in chan.Skills)
                            {
                                conn.Execute(sqlInsertSkill, new { Name = s.Name, AnimeChanRepoId = chan.Id }, tx);
                            }
                        }

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

    }

    ///<summary>Удаляет запись в БД </summary>
    /// <param name="obj">объект, который нужно удалить из БД</param>
    public void Delete(T entity)
    {
        if (entity == null) return;

        if (entity is AnimeChanRepo chan)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        //Находим нужную тянку, её скиллы и удаляем
                        const string sqlDeleteSkills = @"DELETE FROM Skills WHERE AnimeChanRepoId = @Id;";
                        const string sqlDeleteChan = @"DELETE FROM AnimeChans WHERE Id = @Id;";

                        conn.Execute(sqlDeleteSkills, new { Id = chan.Id }, tx);
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

        // Это для этих там (для остальных)
        using (var conn = CreateConnection())
        {
            conn.Execute($"DELETE FROM {typeof(T).Name} WHERE Id = @Id", new { Id = entity.Id });
        }
    }

    ///<summary>Удаляет ВСЕ записи в БД </summary>
    public void DeleteAll()
    {
        if (typeof(T) == typeof(AnimeChanRepo))
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        //Хана всем тянкам и скиллам
                        conn.Execute("DELETE FROM Skills;", transaction: tx);
                        conn.Execute("DELETE FROM AnimeChans;", transaction: tx);
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

        // Это для этих там (для остальных)
        using (var conn = CreateConnection())
        {
            conn.Execute($"DELETE FROM {typeof(T).Name};");
        }
    }
}
