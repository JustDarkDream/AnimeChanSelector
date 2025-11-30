using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class AnimeChanDTO
    {
        public string FirstName { get;}
        public string LastName { get; }
        public int Height { get; }

        public int Weight { get; }

        public int Age { get; }

        public int Id { get; }
        public int Size { get; }

        public List<SkillDTO> Skills { get; } = new List<SkillDTO>();

        public AnimeChanDTO(string firstName, string lastName, int height,  int weight,
                            int age, int id, int size, List<SkillDTO> skills)
        {
            FirstName = firstName;
            LastName = lastName;
            Height = height;
            Weight = weight;
            Age = age;
            Id = id;
            Size = size;
            Skills = skills;
        }
    }
}
