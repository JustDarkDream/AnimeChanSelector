using Model;
using Ninject;
using Shared;
using System.Windows.Forms;
using ViewForms;

namespace Controller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FormsSaverAndLoader.ninjectKernel = new StandardKernel(new SimpleConfigModule());
            FormsSaverAndLoader.logic = FormsSaverAndLoader.ninjectKernel.Get<BourgeoisLogic>();

            IViewRegistration registration = FormsSaverAndLoader.GetRegistration();
            IViewMainForm main = FormsSaverAndLoader.GetMainForm();
            IViewConclution conc = FormsSaverAndLoader.GetConclution();

            //FormsSaverAndLoader.main.WriteAnimeChanTable();

            Starter.StartForm(registration, main, conc);

        }
    }
}
