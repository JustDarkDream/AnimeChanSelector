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
    internal class AnimeChanCardPresenter
    {
        internal AnimeChanCardPresenter(IViewAnimeChanCard view, ILogic logic)
        {
            view.SaveIdEvent += logic.SaveId;
            view.AddAnimeChanEvent += logic.AddAnimeChan;
            view.SaveChangeAnimeChanEvent += logic.SaveChangeAnimeChan;
            view.LoadSkillsEvent += logic.LoadSkills;


            view.GetIViewSkillSettingEvent += FormsSaverAndLoader.GetSkillSetting;

            logic.LoadSkillsInViewEvent += view.LoadSkills;
        }
    }
}
