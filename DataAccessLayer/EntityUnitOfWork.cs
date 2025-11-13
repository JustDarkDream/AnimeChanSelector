using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EntityUnitOfWork: IUnitOfWork
    {
        public IRepository<AnimeChanRepo> AnimeChanRepos { get; }
        public ISkillRepository SkillRepos { get; }
        public EntityUnitOfWork()
        {
            var context = new DataContext();
            AnimeChanRepos = new EntityAnimeChanRepository(context);
            SkillRepos = new EntitySkillRepository(context);
        }
    }
}