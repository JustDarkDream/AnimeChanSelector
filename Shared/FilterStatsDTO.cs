using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class FilterStatsDTO
    {
        public int AgeFrom { get; } = 0;
        public int AgeTo { get; } = 100;
        public int HeightFrom { get; } = 0;
        public int HeightTo { get; } = 200;
        public int WeightFrom { get; } = 0;
        public int WeightTo { get; } = 100;
        public int SizeFrom { get; } = 0;
        public int SizeTo { get; } = 10;
        public List<SkillDTO> Skills { get; } = new List<SkillDTO>();
        public bool isСonsiderAll { get; } = false;

        public FilterStatsDTO(int ageFrom, int ageTo, int heightFrom, int heightTo, int weightFrom,
                              int weightTo, int sizeFrom, int sizeTo, List<SkillDTO> skills, bool isConsiderAll)
        {
            AgeFrom = ageFrom;
            AgeTo = ageTo;
            HeightFrom = heightFrom;
            HeightTo = heightTo;
            WeightFrom = weightFrom;
            WeightTo = weightTo;
            SizeFrom = sizeFrom;
            SizeTo = sizeTo;
            Skills = skills;
            isСonsiderAll = isConsiderAll;
        }
    }
}
