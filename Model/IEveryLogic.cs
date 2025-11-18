using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IEveryLogic
    {
        public IAnimeChan AnimeChanLogic { get;}
        public ISkilled SkillLogic { get; }
        public IMainPerson MainPersonLogic { get; }
        public IConclution ConclutionLogic { get; }
        public IFilterable FilterLogic { get; }
    }
}
