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
        internal static ILogic logic;

        internal static IViewRegistration registration;
        internal static IViewMainForm main;
        internal static IViewConclution conc;
        internal static IViewAnimeChanCard animeChanCard;
        internal static IViewFilterChan filterChan;
        internal static IViewSkillSetting skillSetting;

        public static IViewRegistration GetRegistration()
        {
            registration = new Registration();
            RegistrationPresenter presenter = new RegistrationPresenter(registration, logic);
            return registration;
        }

        public static IViewMainForm GetMainForm()
        {
            main = new MainForm();
            MainFormPresenter presenter2 = new MainFormPresenter(main, logic);
            return main;
        }

        public static IViewConclution GetConclution()
        {
            conc = new Conclution();
            ConclutionPresenter presenter3 = new ConclutionPresenter(conc, logic);
            return conc;
        }
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
