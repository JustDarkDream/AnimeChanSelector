using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DapperChanSkillRepository : IChanSkillRepository
    {
        private readonly string connectionString;

        internal DapperChanSkillRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private IDbConnection CreateConnection() => new SqlConnection(connectionString);

        public void AddSkillToChan(int chanId, int skillId)
        {
            const string sql = "INSERT INTO SkillChans (AnimeChanRepoId, SkillId) VALUES (@chanId, @skillId)";
            using (var conn = CreateConnection())
            {
                conn.Execute(sql, new { chanId, skillId });
            }
        }

            public void RemoveSkillFromChan(int chanId, int skillId)
        {
            const string sql = "DELETE FROM SkillChans WHERE ChanId = @chanId AND SkillId = @skillId";
            using (var conn = CreateConnection())
            {
                conn.Execute(sql, new { chanId, skillId });
            }
        }

        public void RemoveAllSkillsFromChan(int chanId)
        {
            const string sql = "DELETE FROM SkillChans WHERE ChanId = @chanId";
            using (var conn = CreateConnection())
            {
                conn.Execute(sql, new { chanId });
            }
        }

        public void RemoveAllChansFromSkill(int skillId)
        {
            const string sql = "DELETE FROM SkillChans WHERE SkillId = @skillId";
            using (var conn = CreateConnection())
            {
                conn.Execute(sql, new { skillId });
            }
        }

        public List<SkillRepo> GetSkillsByChanId(int chanId)
        {
            const string sql = @"
            SELECT s.* FROM Skills s
            INNER JOIN SkillChans cs ON s.Id = cs.SkillId
            WHERE cs.AnimeChanRepoId = @chanId";
            using (var conn = CreateConnection())
            {
                return conn.Query<SkillRepo>(sql, new { chanId }).ToList();
            }
        }

        public List<AnimeChanRepo> GetChansBySkillId(int skillId)
        {
            const string sql = @"
            SELECT c.* FROM Chan c
            INNER JOIN SkillChans cs ON c.Id = cs.ChanId
            WHERE cs.SkillId = @skillId";

            using (var conn = CreateConnection())
            {
                return conn.Query<AnimeChanRepo>(sql, new { skillId }).ToList();
            }
        }

        public bool Exists(int chanId, int skillId)
        {
            const string sql = "SELECT COUNT(1) FROM ChanSkills WHERE ChanId = @chanId AND SkillId = @skillId";
            
            using (var conn = CreateConnection())
            {
                int count = conn.ExecuteScalar<int>(sql, new { chanId, skillId });
                return count > 0;
            }
        }
    }
}
