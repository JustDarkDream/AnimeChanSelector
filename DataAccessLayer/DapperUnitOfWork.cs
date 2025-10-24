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
            string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nubik\Documents\IloveGit\AnimeChanSelector\DataAccessLayer\AnimeChanDataBase.mdf;Integrated Security=True";
            AnimeChanRepos = new DapperAnimeChanRepository(str);
            SkillRepos = new DapperSkillRepository(str);
            ChanSkillRepos = new DapperChanSkillRepository(str);
        }
    }
}
