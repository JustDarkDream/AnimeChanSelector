namespace DataAccessLayer
{
    public class AnimeChanRepo : IDomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }

        public int Weight { get; set; }

        public int Age { get; set; }

        public int Id { get; set; }
        public int Size { get; set; }

        public List<SkillRepo> Skills { get; set; } = new List<SkillRepo>();

        public AnimeChanRepo()
        {

        }
    }
}
