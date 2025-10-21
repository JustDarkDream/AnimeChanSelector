namespace DataAccessLayer
{
    public class SkillRepo : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AnimeChanRepo AnimeChanRepo { get; set; }
        public int AnimeChanRepoId { get; set; }

    }
}
