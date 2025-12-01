using Model;
using Ninject;
using Shared;
using System.Windows.Forms;
using ViewForms;

namespace Controller
{
    internal class Program
    {
        //static Registration registration;
        //static MainForm main;
        //static Conclution conc;
        //static AnimeChanCard animeChanCard;
        //static FilterChan filterChan;
        //static SkillsSetting skillSetting;
        static void Main(string[] args)
        {
            FormsSaverAndLoader.ninjectKernel = new StandardKernel(new SimpleConfigModule());
            FormsSaverAndLoader.logic = FormsSaverAndLoader.ninjectKernel.Get<BourgeoisLogic>();

            FormsSaverAndLoader.registration = new Registration();
            FormsSaverAndLoader.main = new MainForm();
            FormsSaverAndLoader.conc = new Conclution();
            
            
            

            RegistrationPresenter presenter = new RegistrationPresenter(FormsSaverAndLoader.registration, FormsSaverAndLoader.logic);
            MainFormPresenter presenter2 = new MainFormPresenter(FormsSaverAndLoader.main, FormsSaverAndLoader.logic);
            ConclutionPresenter presenter3 = new ConclutionPresenter(FormsSaverAndLoader.conc, FormsSaverAndLoader.logic);
            
            

            FormsSaverAndLoader.main.WriteAnimeChanTable();

            Starter.StartForm(FormsSaverAndLoader.registration, FormsSaverAndLoader.main, FormsSaverAndLoader.conc);

        }
    }
}
