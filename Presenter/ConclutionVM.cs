using Model;
using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    public class ConclutionVM: ViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event Action<ViewModel> conclutionMVReadyEvent;
        public AnimeChanDTO AnimeChanDTO {  get; set; }
        public string Text { get; set; }
        ILogic logic;
        IKernel ninjectKernel;

        /// <summary>
        /// Конструктор объекта Conclution ViewModel
        /// </summary>
        /// <param name="animeChanDTO">Объект тянки</param>
        public ConclutionVM(AnimeChanDTO animeChanDTO)
        {
            AnimeChanDTO = animeChanDTO;
        }

        /// <summary>
        /// Метод, сообщающий о готовнсти к работе
        /// </summary>
        public void Start()
        {
            ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<BourgeoisLogic>();
            conclutionMVReadyEvent.Invoke(this);

            logic.WriteConclutionEvent += WriteConclution;
            logic.SaveId(AnimeChanDTO.Id);
            logic.MakeConclution();
        }

        /// <summary>
        /// Метод вывода заключения
        /// </summary>
        /// <param name="str">Строка для вывода</param>
        public void WriteConclution(string str)
        {
            Text = str;
            OnPropertyChanged(nameof(Text));
        }

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
