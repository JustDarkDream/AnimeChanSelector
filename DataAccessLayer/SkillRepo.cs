namespace DataAccessLayer
{
    public class SkillRepo : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AnimeChanRepo> AnimeChansRepo { get; set; } = new List<AnimeChanRepo>();

        /// <summary>
        /// Конструктор доменного объекта скилла
        /// </summary>
        /// <param name="id">Айди скила</param>
        /// <param name="name">Название</param>
        public SkillRepo(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Конструктор доменного объекта скилла
        /// </summary>
        public SkillRepo()
        {

        }
    }
}
