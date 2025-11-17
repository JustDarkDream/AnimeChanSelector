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
        }
    }
}
