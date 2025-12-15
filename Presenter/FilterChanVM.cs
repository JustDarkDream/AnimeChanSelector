using Model;
using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class FilterChanVM: ViewModel, INotifyPropertyChanged
    {
        public event Action<ViewModel> filterChanMVReadyEvent;
        public event Action LoadFilterListEvent;
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand SaveCommand { get; set; }
        public string Text { get; set; }
        ILogic logic;
        IKernel ninjectKernel;

        private int sizeFrom;
        public int SizeFrom
        { 
            get
            {
                return sizeFrom;
            }
            set 
            {
                if (sizeFrom != value)
                {
                    sizeFrom = value;
                    OnPropertyChanged(nameof(sizeFrom));
                }
            }
        }
        private int sizeTo;
        public int SizeTo
        {
            get
            {
                return sizeTo;
            }
            set
            {
                if (sizeTo != value)
                {
                    sizeTo = value;
                    OnPropertyChanged(nameof(sizeTo));
                }
            }
        }
        private int ageFrom;
        public int AgeFrom
        {
            get
            {
                return ageFrom;
            }
            set
            {
                if (ageFrom != value)
                {
                    ageFrom = value;
                    OnPropertyChanged(nameof(ageFrom));
                }
            }
        }
        private int ageTo;
        public int AgeTo
        {
            get
            {
                return ageTo;
            }
            set
            {
                if (ageTo != value)
                {
                    ageTo = value;
                    OnPropertyChanged(nameof(ageTo));
                }
            }
        }
        private int weightFrom;
        public int WeightFrom
        {
            get
            {
                return weightFrom;
            }
            set
            {
                if (weightFrom != value)
                {
                    weightFrom = value;
                    OnPropertyChanged(nameof(weightFrom));
                }
            }
        }
        private int weightTo;
        public int WeightTo
        {
            get
            {
                return ageTo;
            }
            set
            {
                if (weightTo != value)
                {
                    weightTo = value;
                    OnPropertyChanged(nameof(weightTo));
                }
            }
        }
        private int heightFrom;
        public int HeightFrom
        {
            get
            {
                return heightFrom;
            }
            set
            {
                if (heightFrom != value)
                {
                    heightFrom = value;
                    OnPropertyChanged(nameof(heightFrom));
                }
            }
        }
        private int heightTo;
        public int HeightTo
        {
            get
            {
                return heightTo;
            }
            set
            {
                if (heightTo != value)
                {
                    heightTo = value;
                    OnPropertyChanged(nameof(heightTo));
                }
            }
        }
        public FilterChanVM()
        {
            SaveCommand = new RelayCommand(Save);
            ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<BourgeoisLogic>();
            logic.FilterStatsLoadedEvent += FilterStatsLoaded;
            logic.LoadFilterStats();
        }

        public void Start()
        {
            filterChanMVReadyEvent.Invoke(this);
        }

        private void FilterStatsLoaded(FilterStatsDTO stats)
        {
            SizeFrom = stats.SizeFrom;
            SizeTo = stats.SizeTo;
            AgeFrom = stats.AgeFrom;
            AgeTo = stats.AgeTo;
            WeightFrom = stats.WeightFrom;
            WeightTo = stats.WeightTo;
            HeightFrom = stats.HeightFrom;
            HeightTo = stats.HeightTo;
        }

        private void Save()
        {
            logic.FilterAnimeChanList(AgeFrom, AgeTo, HeightFrom, HeightTo, WeightFrom, WeightTo, SizeFrom, SizeTo, new List<SkillDTO>(), true);
            LoadFilterListEvent.Invoke();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
