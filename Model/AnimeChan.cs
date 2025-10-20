using DataAccessLayer;
using System.Drawing;
using System.Linq;

namespace Model
{
    public class AnimeChan: IDomainObject
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int Height { get; internal set; }

        public int Weight { get; internal set; }

        public int Age {  get; internal set; }

        public int Id { get; set; }
        public int Size { get; internal set; }

        public List<Skill> Skills { get; internal set; } = new List<Skill>();

        public AnimeChan() { }

        /// <summary>
        /// Конструктор сущности AnimeChan
        /// </summary>
        /// <param name="repo">Репозиторий полей записи AnimeChan из БД</param>
        public AnimeChan(DataAccessLayer.AnimeChanRepo repo)
        {
            FirstName = repo.FirstName;
            LastName = repo.LastName;
            Height = repo.Height;
            Weight = repo.Weight;
            Age = repo.Age;
            Id = repo.Id;
            Size = repo.Size;

            var dalSkills = repo.Skills;
            Skills = dalSkills.Select(x => new Skill(x)).ToList();
        }
    }
}
