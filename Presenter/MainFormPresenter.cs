using Microsoft.EntityFrameworkCore.Metadata;
using Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    internal class MainFormPresenter
    {
        internal MainFormPresenter(IViewMainForm view, ILogic logic)
        {
            view.LoadAnimeChanListEvent += logic.LoadAnimeChanList;
            view.FindByIdEvent += logic.FindById;
            view.LoadIdEvent += logic.LoadId;
            view.DeleteAnimeChanEvent += logic.DeleteAnimeChan;
            view.DestroyFilterEvent += logic.DestroyFilter;
            view.LoadFilterAnimeChanListEvent += logic.LoadFilterAnimeChanList;
            view.FindAnimeChanEvent += logic.FindAnimeChan;
            view.GetMainPersonEvent += logic.GetMainPerson;



        //            public event Action<IEnumerable<AnimeChanDTO>> LoadAnimeChanListEvent;
        //public event Action<AnimeChanDTO> FindByIdEvent;
        //public event Action<int> LoadIdEvent;
        //public event Action<List<AnimeChanDTO>> LoadFilterAnimeChanListEvent;
        //public event Action<AnimeChanDTO> FindAnimeChanEvent;
        //public event Action<MainPersonDTO> GetMainPersonEvent;
    }
    }
}