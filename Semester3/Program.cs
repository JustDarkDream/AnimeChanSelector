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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //ApplicationConfiguration.Initialize();
            ////Сначало запускает окно регистрации, потом главное окно, а после окно с результатами
            //Registration registration = new Registration();
            //if (registration.ShowDialog() == DialogResult.OK)
            //{
            //    MainForm form1 = new MainForm();
            //    if (form1.ShowDialog() == DialogResult.OK)
            //    {
            //        Application.Run(new Conclution());
            //    }
            //}
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