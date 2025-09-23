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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Сначало запускает окно регистрации, потом главное окно, а после окно с результатами
            Registration registration = new Registration();
            if (registration.ShowDialog() == DialogResult.OK)
            {
                Form1 form1 = new Form1();
                if (form1.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Conclution());
                }
            }
        }
    }
}