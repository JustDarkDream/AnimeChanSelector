using Dapper;
using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class AnimeChanRepository : IRepository<AnimeChanRepo>
{
    private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nubik\Documents\IloveGit\AnimeChanSelector\DataAccessLayer\AnimeChanDataBase.mdf;Integrated Security=True";

    private IDbConnection CreateConnection() => new SqlConnection(connectionString);


    public void Create(AnimeChanRepo chan)
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

    ///<summary>Читает все записи в БД</summary>
    /// <returns>Возвращает все записи из БД</returns>
    public IEnumerable<AnimeChanRepo> ReadAll()
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

                return dict.Values.ToList();
        }
    }


    ///<summary>Читает запись по id</summary>
    /// <param name="id">id, по которому ищут нужный объект</param>
    /// /// <returns>Возвращает нужную запись из БД</returns>
    public AnimeChanRepo ReadById(int id)
    {
            //Выбирает тянку вместе с её скиллами
            const string sqlChan = @"SELECT * FROM AnimeChans WHERE Id = @Id;";

            using (var conn = CreateConnection())
            {
                var chan = conn.QuerySingleOrDefault<AnimeChanRepo>(sqlChan, new { Id = id });

                return chan;
            }
    }

    ///<summary>Изменяет данные у записи </summary>
    /// <param name="obj">объект с измененными свойствами</param>
    public void Update(AnimeChanRepo chan)
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

    ///<summary>Удаляет запись в БД </summary>
    /// <param name="obj">объект, который нужно удалить из БД</param>
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

    ///<summary>Удаляет ВСЕ записи в БД </summary>
    public void DeleteAll()
    {
        using (var conn = CreateConnection())
        {
            conn.Open();
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    //Хана всем тянкам 
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
}
