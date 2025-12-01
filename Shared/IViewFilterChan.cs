using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IViewFilterChan
    {
        event Action LoadFilterStatsEvent;
        event Action<int, int, int, int, int, int, int, int, List<SkillDTO>, bool> FilterAnimeChanListEvent;
        event Action LoadSkillsEvent;

        event Func<IViewSkillSetting> GetIViewSkillSettingEvent;
        bool CorrectWork();
        void LoadFilterStats(FilterStatsDTO filter);
        void LoadSkills(List<SkillDTO> list);
    }
}
