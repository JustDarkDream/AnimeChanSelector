using Model;
using Ninject;
using Shared;
using System.Windows.Forms;
using ViewForms;

namespace Controller
{
    internal class Program
    {
        static IKernel ninjectKernel;
        static BourgeoisLogic logic;
        static void Main(string[] args)
        {
            ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<BourgeoisLogic>();

            var registration = new Registration();
            var main = new MainForm();
            var conc = new Conclution();

            RegistrationPresenter presenter = new RegistrationPresenter(registration, logic);
            MainFormPresenter presenter2 = new MainFormPresenter(main, logic);
            ConclutionPresenter presenter3 = new ConclutionPresenter(conc, logic);

            Starter.StartForm(registration, main, conc);

        }
    }
}
