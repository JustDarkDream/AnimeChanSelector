using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IUnitOfWork
    {
        IRepository<AnimeChanRepo> AnimeChanRepos { get; }
        ISkillRepository SkillRepos { get; }
        IChanSkillRepository ChanSkillRepos { get; }
    }
}
