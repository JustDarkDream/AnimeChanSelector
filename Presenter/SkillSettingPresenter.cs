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
    internal class SkillSettingPresenter
    {
        internal SkillSettingPresenter(IViewSkillSetting view, ILogic logic)
        {
            view.CreateSkillEvent += logic.CreateSkill;
            view.ClearSkillsEvent += logic.ClearSkills;
            view.SaveSkillEvent += logic.SaveSkill;

            //public event Action<SkillDTO> CreateSkillEvent;
    }
    }
}
