using DataAccessLayer;

namespace DataAccessLayer
{
    public class AnimeChanRepo : IDoMainObject
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public int Height { get;  set; }

        public int Weight { get;  set; }

        public int Age { get;  set; }

        public int Id { get; set; }
        public int Size { get;  set; }

        public List<SkillRepo> Skills { get; set; } = new List<SkillRepo>();

        public AnimeChanRepo()
        {

        }

        //internal AnimeChan(string firstName, string lastName, int age, int id, int height, int weight, int size, List<Skills> skills)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Age = age;
        //    Id = id;
        //    Height = height;
        //    Weight = weight;
        //    Size = size;
        //    Skills = skills;
        //}
    }
}
