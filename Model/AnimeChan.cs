using DataAccessLayer;
using System.Drawing;
using System.Linq;

namespace Model
{
    public class AnimeChan: IDoMainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }

        public int Weight { get; set; }

        public int Age {  get; set; }

        public int Id { get; set; }
        public int Size { get; set; }

        public List<Skill> Skills { get; set; } = new List<Skill>();

        public AnimeChan() { }

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
