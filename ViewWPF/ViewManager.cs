using Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ViewWPF
{
    class ViewManager
    {

        private readonly Dictionary<Type, Func<ViewModel, System.Windows.Window>> viewShow;
        private readonly Dictionary<Type, Func<ViewModel, System.Windows.Window>> viewShowDialog;

        private System.Windows.Window lastOpenedWindow;

        public ViewManager()
        {
            viewShow = new Dictionary<Type, Func<ViewModel, System.Windows.Window>>
            {
                { typeof(RegistrationVM), vm => new Registration((RegistrationVM)vm) },
                { typeof(MainFormVM), vm => new MainWindow((MainFormVM)vm) },
                { typeof(AnimeChanCardVM), vm => new AnimeChanCard((AnimeChanCardVM)vm) },
                { typeof(ConclutionVM), vm => new Conclution((ConclutionVM)vm) },
                { typeof(SkillSettingsVM), vm => new SkillsSettings((SkillSettingsVM)vm) },
            };
            viewShowDialog = new Dictionary<Type, Func<ViewModel, System.Windows.Window>>
            {
                { typeof(ErrorVM), vm => new Error((ErrorVM)vm) },
                { typeof(FilterChanVM), vm => new FilterChan((FilterChanVM)vm) },
            };

        }

        public void Start()
        {
            ViewModelManager viewModelManager = new ViewModelManager();
            viewModelManager.VMReadyEvent += VMReady;
            viewModelManager.RequestCloseAllWindows += CloseAllf;
            viewModelManager.Start();
        }

        private void VMReady(ViewModel vm)
        {
            var vmType = vm.GetType();

            if (viewShow.TryGetValue(vmType, out var createWindow))
            {
                var window = createWindow(vm);
                window.Show();
                lastOpenedWindow = window;
            }
            else if (viewShowDialog.TryGetValue(vmType, out var createWindowShowDialog))
            {
                var window = createWindowShowDialog(vm);
                window.ShowDialog();
                lastOpenedWindow = window;
            }
        }
        public void CloseAllf()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window != lastOpenedWindow)
                    window.Close();
            }
        }
    }
}
