namespace Shared
{
    public interface IViewRegistration
    {
        event Action<string, string, int, int, int, int> SaveMainPersonEvent;
        event Action DeleteAnimeChansEvent;
        event Action DeleteSkillsEvent;
        event Action LoadAllSkillsInDBEvent;
        event Action CreateAnimeChansEvent;
        event Action CreateAnimeChansInDBEvent;
    }
}
