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

            view.GetIViewAnimeChanCardEvent += FormsSaverAndLoader.GetAnimeChanCard;
            view.GetIViewFilterChanEvent += FormsSaverAndLoader.GetFilterChan;

            logic.LoadAnimeChanListEvent += view.LoadAnimeChanList;
            logic.GetMainPersonEvent += view.GetMainPerson;
            logic.FindByIdEvent += view.FindById;
            logic.LoadIdEvent += view.LoadId;
            logic.FindAnimeChanEvent += view.FindAnimeChan;
            logic.LoadFilterAnimeChanListEvent += view.FilterAnimeChanList;
        }
    }
}