using Model;
using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class MainFormVM: ViewModel, INotifyPropertyChanged
    {
        public event Action<AnimeChanDTO> OpenAnimeChanCardEvent;
        public event Action<AnimeChanDTO> OpenAnimeChanCardShowEvent;
        public event Action OpenFilterChanEvent;
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<string> OpenErrorEvent;
        public event Action RequestClose;
        public event Action OpenAnimeChanCardCreateEvent;

        public ObservableCollection<AnimeChanDTO> Chans { get; set; } = new ObservableCollection<AnimeChanDTO>();
        private AnimeChanDTO selectedChan;

        public RelayCommand DeleteChan { get; set; }
        public RelayCommand ChangeChan { get; set; }
        public RelayCommand ShowChan { get; set; }
        public RelayCommand FindChan { get; set; }
        public RelayCommand CreateChan { get; set; }
        public RelayCommand FilterChan { get; set; }
        public RelayCommand DestroyFilters { get; set; }
        public AnimeChanDTO SelectedChan
        {
            get
            {
                return selectedChan;
            }
            set
            {
                selectedChan = value;
                OnPropertyChanged(nameof(SelectedChan));
            }
        }


        ILogic logic;
        IKernel ninjectKernel;

        public RelayCommand FinishRegistration { get; set; }

        public event Action<ViewModel> MainformMVReadyEvent;

        /// <summary>
        /// Конструктор объекта MainFormVM
        /// </summary>
        public MainFormVM()
        {
            DestroyFilters = new RelayCommand(DestroyAllFilter);
            DeleteChan = new RelayCommand(DeleteThisChan);
            ChangeChan = new RelayCommand(ChangeThisChan);
            ShowChan = new RelayCommand(ShowThisChan);
            FindChan = new RelayCommand(FindNewChan);
            CreateChan = new RelayCommand(CreateNewChan);
            FilterChan = new RelayCommand(FilterAllChan);
            ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<BourgeoisLogic>();
            logic.LoadAnimeChanListEvent += LoadAnimeChanList;
            logic.FindAnimeChanEvent += FindAnimeChan;
            logic.LoadAnimeChanList();
            
        }

        /// <summary>
        /// Метод, сообщающий о готовности к работе
        /// </summary>
        public void Start()
        {
            //Какую подготовку?

            MainformMVReadyEvent.Invoke(this);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Метод загрузки листа тянок
        /// </summary>
        /// <param name="list"></param>
        private void LoadAnimeChanList(IEnumerable<AnimeChanDTO> list)
        {
            Chans.Clear();
            foreach (var chan in list)
                Chans.Add(chan);
        }

        /// <summary>
        /// Метод удаления выбранной тянки
        /// </summary>
        private void DeleteThisChan()
        {
            if (SelectedChan != null)
            {
                logic.DeleteAnimeChan(SelectedChan.Id);
                Chans.Remove(SelectedChan);
            }
            else
            {
                OpenErrorEvent.Invoke("Выберите строку, чтобы удалить Аниме-тян");
            }
        }

        /// <summary>
        /// Метод изменения выбранной тянки
        /// </summary>
        private void ChangeThisChan()
        {
            if (SelectedChan != null)
            {
                OpenAnimeChanCardEvent.Invoke(SelectedChan);
            }
            else
            {
                OpenErrorEvent.Invoke("Выберите строку, чтобы редактировать Аниме-тян");
            }
        }

        /// <summary>
        /// Метод показа тянки
        /// </summary>
        private void ShowThisChan()
        {
            if (SelectedChan != null)
            {
                OpenAnimeChanCardShowEvent.Invoke(SelectedChan);
            }
            else
            {
                OpenErrorEvent.Invoke("Выберите строку, чтобы выбрять Аниме-тян");
            }
        }
        /// <summary>
        /// Метод создания тянки
        /// </summary>
        private void CreateNewChan()
        {
            OpenAnimeChanCardCreateEvent.Invoke();
        }
        
        /// <summary>
        /// Метод поиска новой тянки
        /// </summary>
        private void FindNewChan()
        {
            logic.FindAnimeChan();
        }

        /// <summary>
        /// Метод вызывающий событие фильтрации листа тянок
        /// </summary>
        private void FilterAllChan()
        {
            OpenFilterChanEvent.Invoke();
        }

        /// <summary>
        /// Метод случайного добавления тянки
        /// </summary>
        /// <param name="animeChanDTO">Объект тянки</param>
        public void FindAnimeChan(AnimeChanDTO animeChanDTO)
        {
            Chans.Add(animeChanDTO);
        }

        /// <summary>
        /// Метод загрузки критериев фильтра
        /// </summary>
        public void LoadFilterList()
        {
            logic.LoadFilterAnimeChanListEvent += LoadFilterAnimeChanList;
            logic.LoadFilterAnimeChanList();
        }

        /// <summary>
        /// Метод загрузки отфильтрованного листа тянок
        /// </summary>
        /// <param name="list">Отфлильтрованнный лист</param>
        private void LoadFilterAnimeChanList(List<AnimeChanDTO> list)
        {
            Chans.Clear();
            foreach (var chan in list)
                Chans.Add(chan);
        }

        /// <summary>
        /// Метод отмены всех настроек фильтра
        /// </summary>
        private void DestroyAllFilter()
        {
            logic.DestroyFilter();
            logic.LoadAnimeChanList();
        }
    }
}
