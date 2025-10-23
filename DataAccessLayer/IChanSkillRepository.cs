using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IChanSkillRepository
    {
        void AddSkillToChan(int chanId, int skillId);
        void RemoveSkillFromChan(int chanId, int skillId);
        void RemoveAllSkillsFromChan(int chanId);
        void RemoveAllChansFromSkill(int skillId);
        List<SkillRepo> GetSkillsByChanId(int chanId);
        List<AnimeChanRepo> GetChansBySkillId(int skillId);
        bool Exists(int chanId, int skillId);
    }
}
