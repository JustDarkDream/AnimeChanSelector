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
    internal class FilterChanPresenter
    {
        internal FilterChanPresenter(IViewFilterChan view, ILogic logic)
        {
            view.LoadFilterStatsEvent += logic.LoadFilterStats;
            view.FilterAnimeChanListEvent += logic.FilterAnimeChanList;
            view.LoadSkillsEvent += logic.LoadSkills;

            logic.LoadSkillsInViewEvent += view.LoadSkills;
            logic.FilterStatsLoadedEvent += view.LoadFilterStats;
        }
    }
}
