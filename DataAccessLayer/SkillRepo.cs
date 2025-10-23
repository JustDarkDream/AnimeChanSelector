namespace DataAccessLayer
{
    public class SkillRepo : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AnimeChanRepo> AnimeChansRepo { get; set; } = new List<AnimeChanRepo>();

    }
}
