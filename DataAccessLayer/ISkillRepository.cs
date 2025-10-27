using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ISkillRepository : IRepository<SkillRepo>
    {

        ///<summary>Выводит списки скиллов, указанных по имени</summary>
        /// <param name="names">содержит имена каждого нужного скилла</param>
        /// <returns>Возвращает сам список скиллов</returns>
        IEnumerable<SkillRepo> GetByNames(IEnumerable<string> names);
    }
}
