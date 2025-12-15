using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;
using Controller;


namespace ViewWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ViewManager manager = new ViewManager();
            manager.Start();
        }
    }

}
