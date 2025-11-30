using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class SkillDTO
    {
        public int Id { get; }
        public string Name { get; }
        public List<AnimeChanDTO> AnimeChansRepo { get; } = new List<AnimeChanDTO>();

        public SkillDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public SkillDTO()
        {

        }
    }
}
