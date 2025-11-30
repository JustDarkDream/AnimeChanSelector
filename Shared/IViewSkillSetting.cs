namespace Shared
{
    public interface IViewSkillSetting
    {
        event Action<string> CreateSkillEvent;
        event Action ClearSkillsEvent;
        event Action<SkillDTO> SaveSkillEvent;
    }
}
