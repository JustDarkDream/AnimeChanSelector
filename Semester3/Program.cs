using Shared;
using System.Windows.Forms;

namespace ViewForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

        }
    }

    public static class Starter 
    {
        public static void StartForm(IViewRegistration form, IViewMainForm form2, IViewConclution form3)
        {

            if (form.CorrectWork())
            {
                if (form2.CorrectWork())
                {
                    form3.CorrectWork();
                }
            }
        }
    }
}