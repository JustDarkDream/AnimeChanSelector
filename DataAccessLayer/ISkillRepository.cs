using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ISkillRepository : IRepository<SkillRepo>
    {
        IEnumerable<SkillRepo> GetByNames(IEnumerable<string> names);
    }
}
