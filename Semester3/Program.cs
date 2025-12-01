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
        public static void StartForm(Form form, Form form2, Form form3)
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(form3);
                }
            }
        }
    }
}