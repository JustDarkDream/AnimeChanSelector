using System.Drawing;

namespace Shared
{
    public interface IViewAnimeChanCard
    {
        event Action LoadSkillsEvent;
        event Action<string, string, int, int, int, int, List<SkillDTO>> AddAnimeChanEvent;
        event Action<string, string, int, int, int, int, List<SkillDTO>, int> SaveChangeAnimeChanEvent;
        event Action<int> SaveIdEvent;

        void LoadSkills(List<SkillDTO> list);
    }
}
