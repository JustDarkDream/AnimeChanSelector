using DataAccessLayer;

namespace Model
{
    public class Skill : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; internal set; }

        /// <summary>
        /// Конструктор объекта класса Skill
        /// </summary>
        /// <param name="repo">репозиторий полей записи из БД</param>
        public Skill(DataAccessLayer.SkillRepo repo)
        {
            Id = repo.Id;
            Name = repo.Name;
        }
        /// <summary>
        /// Констурктор объекта класса скилл без аргументов
        /// </summary>
        public Skill()
        {
        }
    }
}
