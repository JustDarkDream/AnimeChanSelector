using Model;
using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewForms;

namespace Controller
{
    public class RegistrationVM : ViewModel, INotifyPropertyChanged
    {
        MainPersonDTO personDTO;

        ILogic logic;
        IKernel ninjectKernel;

        public RelayCommand FinishRegistration { get; set; }

        public event Action<ViewModel> RegistrationMVReadyEvent;
        public event Action<string> OpenErrorEvent;
        public event Action OpenMainFormEvent;
        public event Action RequestClose;
        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName
        {
            get
            {
                return personDTO.FirstName;
            }
            set
            {
                if (personDTO.FirstName != value)
                {
                    personDTO = new MainPersonDTO(value, LastName, Height, Weight, Age, Size);
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get
            {
                return personDTO.LastName;
            }
            set
            {
                if (personDTO.LastName != value)
                {
                    personDTO = new MainPersonDTO(FirstName, value, Height, Weight, Age, Size);
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public int Height
        {
            get
            {
                return personDTO.Height;
            }
            set
            {
                if (personDTO.Height != value)
                {
                    personDTO = new MainPersonDTO(FirstName, LastName, value, Weight, Age, Size);
                    OnPropertyChanged(nameof(Height));
                }
            }
        }

        public int Weight
        {
            get
            {
                return personDTO.Weight;
            }
            set
            {
                if (personDTO.Weight != value)
                {
                    personDTO = new MainPersonDTO(FirstName, LastName, Height, value, Age, Size);
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }

        public int Age
        {
            get
            {
                return personDTO.Age;
            }
            set
            {
                if (personDTO.Age != value)
                {
                    personDTO = new MainPersonDTO(FirstName, LastName, Height, Weight, value, Size);
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        public int Size
        {
            get
            {
                return personDTO.Size;
            }
            set
            {
                if (personDTO.Size != value)
                {
                    personDTO = new MainPersonDTO(FirstName, LastName, Height, Weight, Age, value);
                    OnPropertyChanged(nameof(Size));
                }
            }
        }

        public RegistrationVM()
        {
            ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<BourgeoisLogic>();
            personDTO = new MainPersonDTO("", "", 0, 0, 0, 0);
            FinishRegistration = new RelayCommand(GetMainForm);
        }

        public void Start()
        {
            //Какую подготовку?
            RegistrationMVReadyEvent.Invoke(this);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void GetMainForm()
        {
            if (Age >= 0)
            {
                if (Height >= 0) //Проверка на корректность данных
                {
                    if (Weight >= 0)
                    {
                        if (Size >= 0)
                        {
                            if (FirstName.Length > 0)
                            {
                                if (LastName.Length > 0)
                                {
                                    logic.SaveMainPerson(FirstName, LastName, Age, Height, Weight, Size);
                                    logic.DeleteAnimeChans();
                                    logic.DeleteSkills();
                                    logic.LoadAllSkillsInDB();
                                    logic.CreateAnimeChans();
                                    logic.CreateAnimeChansInDB();
                                    OpenMainFormEvent.Invoke();
                                    RequestClose.Invoke();
                                }
                                else
                                {
                                    OpenErrorEvent.Invoke("Ничего не введено в строку \"Фамилия\"");
                                }
                            }
                            else
                            {
                                OpenErrorEvent.Invoke("Ничего не введено в строку \"Имя\"");
                            }
                        }
                        else
                        {
                            OpenErrorEvent.Invoke("Введено некорректное значение в \"Размер\"");
                        }
                    }
                    else
                    {
                        OpenErrorEvent.Invoke("Введено некорректное значение в \"Вес\"");
                    }
                }
                else
                {
                    OpenErrorEvent.Invoke("Введено некорректное значение в \"Рост\"");
                }
            }
            else
            {
                OpenErrorEvent.Invoke("Введено некорректное значение в \"Возраст\"");
            }
        }
    }
}