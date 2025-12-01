namespace Shared
{
    public interface IViewSkillSetting
    {
        event Action<string> CreateSkillEvent;
        event Action ClearSkillsEvent;
        event Action<SkillDTO> SaveSkillEvent;

        void CreateSkill(SkillDTO skill);
        bool CorrectWork(List<SkillDTO> _skills);

    }
}
