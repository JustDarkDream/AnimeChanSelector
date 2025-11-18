using DataAccessLayer;
using System.Diagnostics;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;


namespace Model
{
    public class BourgeoisLogic: IEveryLogic
    {
        Saves Save;
        IUnitOfWork unitOfWork;

        public IAnimeChan AnimeChanLogic { get; }
        public ISkilled SkillLogic { get; }
        public IMainPerson MainPersonLogic { get; }
        public IConclution ConclutionLogic { get; }
        public IFilterable FilterLogic { get; }

        public BourgeoisLogic(IUnitOfWork UnitOfWork, Saves saves, IAnimeChan anime, ISkilled skill, IMainPerson main, IConclution concl, IFilterable filter)
        {
            unitOfWork = UnitOfWork;
            Save = saves;

            AnimeChanLogic = anime;
            SkillLogic = skill;
            MainPersonLogic = main;
            ConclutionLogic = concl;
            FilterLogic = filter;
        }
    }
}
