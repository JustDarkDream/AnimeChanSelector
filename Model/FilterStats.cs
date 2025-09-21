using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FilterStats
    {
        public int AgeFrom { get; internal set; } = 0;
        public int AgeTo { get; internal set; } = 100;
        public int HeightFrom { get; internal set; } = 0;
        public int HeightTo { get; internal set; } = 200;
        public int WeightFrom { get; internal set; } = 0;
        public int WeightTo { get; internal set; } = 100;
        public int SizeFrom { get; internal set; } = 0;
        public int SizeTo { get; internal set; } = 10;
        public List<Skills> Skills { get; internal set; } = new List<Skills>();
        public bool isСonsiderAll { get; internal set; } = false;
    }
}
