using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        public IRepository<AnimeChanRepo> AnimeChanRepos { get; }
        public ISkillRepository SkillRepos { get; }
        public IChanSkillRepository ChanSkillRepos { get; }

        public DapperUnitOfWork()
        {
            var context = new DataContext();
            AnimeChanRepos = new DapperAnimeChanRepository();
            SkillRepos = new DapperSkillRepository();
            ChanSkillRepos = new DapperChanSkillRepository();
        }
    }
}
