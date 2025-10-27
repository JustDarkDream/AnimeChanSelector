using Dapper;
using DataAccessLayer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class DapperSkillRepository : IRepository<SkillRepo>, ISkillRepository
    {
        private readonly string connectionString;


        internal DapperSkillRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private IDbConnection CreateConnection() => new SqlConnection(connectionString);


        public void Create(SkillRepo skill)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    { //Добавляем скилл
                        const string sqlChan = @" 
                        INSERT INTO Skills (Name)
                        VALUES (@Name);
                        SELECT CAST(SCOPE_IDENTITY() AS int);";

                        skill.Id = conn.QuerySingle<int>(sqlChan, skill, tx); //Присваиваем id для скилла (экземплярам класса)

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

        public IEnumerable<SkillRepo> ReadAll()
        {
            //Выбирает скилл
            const string sql = @" 
            SELECT a.Id, a.Name
            FROM Skills a";

            using (var conn = CreateConnection())
            {
                return conn.Query<SkillRepo>(sql).ToList();
            }
        }

        public SkillRepo ReadById(int id)
        {
            //Выбирает тянку вместе с её скиллами
            const string sqlChan = @"SELECT * FROM Skills WHERE Id = @Id;";

            using (var conn = CreateConnection())
            {
                var skill = conn.QuerySingleOrDefault<SkillRepo>(sqlChan, new { Id = id });

                return skill;
            }
        }

        public void Update(SkillRepo skill)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        //Обновляем скилл
                        const string sqlUpdateChan = @"
                        UPDATE Skills
                        SET Name = @Name
                        WHERE Id = @Id;";

                        conn.Execute(sqlUpdateChan, skill, tx);

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

        public void Delete(SkillRepo skill)
        {
            if (skill == null) return;

            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        //Находим нужный скилл
                        const string sqlDeleteChan = @"DELETE FROM Skills WHERE Id = @Id;";

                        conn.Execute(sqlDeleteChan, new { Id = skill.Id }, tx);

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
                        //Хана всем скиллам 
                        conn.Execute("DELETE FROM Skills;", transaction: tx);
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

        public IEnumerable<SkillRepo> GetByNames(IEnumerable<string> names)
        {
            var nameList = names?.ToList() ?? new List<string>();
            Debug.WriteLine($"=== GetByNames ===");
            Debug.WriteLine($"Ищем навыки: {string.Join(", ", nameList)}");

            const string sql = "SELECT * FROM Skills WHERE Name IN @Names";

            using (var conn = CreateConnection())
            {
                var result = conn.Query<SkillRepo>(sql, new { Names = nameList }).ToList();
                Debug.WriteLine($"Найдено навыков: {result.Count}");
                foreach (var skill in result)
                {
                    Debug.WriteLine($"  Навык: ID={skill.Id}, Name={skill.Name}");
                }
                return result;
            }
        }
    }
}

