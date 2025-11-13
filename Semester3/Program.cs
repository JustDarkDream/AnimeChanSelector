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
            ApplicationConfiguration.Initialize();
            //Сначало запускает окно регистрации, потом главное окно, а после окно с результатами
            Registration registration = new Registration();
            if (registration.ShowDialog() == DialogResult.OK)
            {
                MainForm form1 = new MainForm();
                if (form1.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Conclution());
                }
            }
        }
    }
}