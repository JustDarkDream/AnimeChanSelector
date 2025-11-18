using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Ninject;
using Ninject.Modules;

namespace Model
{
    public class SimpleConfigModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EntityUnitOfWork>().InSingletonScope();
            Bind<Saves>().ToMethod(x => Saves.GetInstatnce()).InSingletonScope();

            // Логики
            Bind<IAnimeChan>().To<AnimeChanLogic>().InTransientScope();
            Bind<ISkilled>().To<SkillLogic>().InTransientScope();
            Bind<IMainPerson>().To<MainPersonLogic>().InTransientScope();
            Bind<IConclution>().To<ConclutionLogic>().InTransientScope();
            Bind<IFilterable>().To<FilterLogic>().InTransientScope();
        }
    }
}
