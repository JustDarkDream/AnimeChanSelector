using Model;
using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewForms;

namespace Controller
{
    public static class FormsSaverAndLoader
    {
        internal static IKernel ninjectKernel;
        internal static BourgeoisLogic logic;
        internal static Registration registration;
        internal static MainForm main;
        internal static Conclution conc;
        internal static AnimeChanCard animeChanCard;
        internal static FilterChan filterChan;
        internal static SkillsSetting skillSetting;

        public static IViewAnimeChanCard GetAnimeChanCard()
        {
            animeChanCard = new AnimeChanCard();
            AnimeChanCardPresenter presenter4 = new AnimeChanCardPresenter(animeChanCard, logic);
            return animeChanCard;
        }

        public static IViewFilterChan GetFilterChan()
        {
            filterChan = new FilterChan();
            FilterChanPresenter presenter5 = new FilterChanPresenter(filterChan, logic);
            return filterChan;
        }

        public static IViewSkillSetting GetSkillSetting()
        {
            skillSetting = new SkillsSetting();
            SkillSettingPresenter presenter6 = new SkillSettingPresenter(skillSetting, logic);
            return skillSetting;
        }
    }
}
