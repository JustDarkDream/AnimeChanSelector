using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using Dapper;
using DataAccessLayer;

public class DapperRepository<T> : IRepository<T> where T : class, IDoMainObject, new()
{
    private readonly string connectionString = @"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nubik\Documents\IloveGit\Semester3\DataAccessLayer\AnimeChanDataBase.mdf;Integrated Security = True";

    private IDbConnection CreateConnection() => new SqlConnection(connectionString);

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
                    {
                        const string sqlChan = @"
INSERT INTO AnimeChans (FirstName, LastName, Age, Height, Weight, Size)
VALUES (@FirstName, @LastName, @Age, @Height, @Weight, @Size);
SELECT CAST(SCOPE_IDENTITY() AS int);";

                        chan.Id = conn.QuerySingle<int>(sqlChan, chan, tx);

                        if (chan.Skills != null && chan.Skills.Any())
                        {
                            const string sqlSkill = @"
INSERT INTO Skills (Name, AnimeChanRepoId)
VALUES (@Name, @AnimeChanRepoId);";

                            foreach (var s in chan.Skills)
                            {
                                s.AnimeChanRepoId = chan.Id;
                                conn.Execute(sqlSkill, new { Name = s.Name, AnimeChanRepoId = s.AnimeChanRepoId }, tx);
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

        throw new NotImplementedException($"Create not implemented for {typeof(T).Name}");
    }

    public IEnumerable<T> ReadAll()
    {
        if (typeof(T) == typeof(AnimeChanRepo))
        {
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

        throw new NotImplementedException($"ReadAll not implemented for {typeof(T).Name}");
    }

    public T ReadById(int id)
    {
        if (typeof(T) == typeof(AnimeChanRepo))
        {
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

        // Для других типов — простое поведение
        using (var conn = CreateConnection())
        {
            return conn.QuerySingleOrDefault<T>("SELECT * FROM " + typeof(T).Name + " WHERE Id = @Id", new { Id = id });
        }
    }

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

                        // Удаляем старые скиллы и вставляем новые — это простой и надёжный подход
                        const string sqlDeleteSkills = @"DELETE FROM Skills WHERE AnimeChanRepoId = @Id;";
                        conn.Execute(sqlDeleteSkills, new { Id = chan.Id }, tx);

                        if (chan.Skills != null && chan.Skills.Any())
                        {
                            const string sqlInsertSkill = @"
INSERT INTO Skills (Name, AnimeChanRepoId)
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

        throw new NotImplementedException($"Update not implemented for {typeof(T).Name}");
    }

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

        // Для простых типов — удаление по Id (предполагая, что таблица названа по типу)
        using (var conn = CreateConnection())
        {
            conn.Execute($"DELETE FROM {typeof(T).Name} WHERE Id = @Id", new { Id = entity.Id });
        }
    }

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

        using (var conn = CreateConnection())
        {
            conn.Execute($"DELETE FROM {typeof(T).Name};");
        }
    }

    // Остальные методы интерфейса можно реализовать аналогично...
}
