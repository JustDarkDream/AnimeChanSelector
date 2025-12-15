using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model;
using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AnimeChanCardVM : ViewModel, INotifyPropertyChanged
    {
        private SharedAnimeChan shared;
        public ObservableCollection<SkillDTO> Skills { get; set; } = new ObservableCollection<SkillDTO>();

        public event Action<ViewModel> AnimeChanCardMVReadyEvent;
        public event Action<AnimeChanDTO> OpenConclutionEvent;
        public event Action<SharedAnimeChan> OpenSkillsSettingsEvent;
        public event Action<string> OpenErrorEvent;
        public event Action RequestSave;
        public event Action<AnimeChanDTO> RequestCreate;
        public event PropertyChangedEventHandler PropertyChanged;

        public string SaveButtonStatus {  get; set; }
        public string ShowButtonStatus { get; set; }
        public string CreateButtonStatus { get; set; }
        public string ChangeSkillsButtonStatus { get; set; }
        public bool IsReadOnly {  get; set; }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ShowCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand ChangeSkillsCommand { get; set; }
        ILogic logic;
        IKernel ninjectKernel;

        int newId = 0;

        public string FirstName
        {
            get => shared.DTO.FirstName;
            set => shared.Update(firstName: value);
        }

        public string LastName
        {
            get => shared.DTO.LastName;
            set => shared.Update(lastName: value);
        }

        public int Height
        {
            get => shared.DTO.Height;
            set => shared.Update(height: value);
        }

        public int Weight
        {
            get => shared.DTO.Weight;
            set => shared.Update(weight: value);
        }

        public int Age
        {
            get => shared.DTO.Age;
            set => shared.Update(age: value);
        }

        public int Size
        {
            get => shared.DTO.Size;
            set => shared.Update(size: value);
        }

        /// <summary>
        /// Конструктор объекта AnimeChanCard ViewModel
        /// </summary>
        /// <param name="sharedAnimeChan">Объект тян</param>
        /// <param name="isEditable">Редактируема ли информация</param>
        public AnimeChanCardVM(SharedAnimeChan sharedAnimeChan, bool isEditable)
        {
            ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<BourgeoisLogic>();
            shared = sharedAnimeChan;

            foreach (var skill in shared.DTO.Skills)
                Skills.Add(skill);

            shared.Changed += () =>
            {
                Skills.Clear();
                foreach (var skill in shared.DTO.Skills)
                    Skills.Add(skill);

                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(Height));
                OnPropertyChanged(nameof(Weight));
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(Size));
            };
            //Skills = shared.Skills;

            if (isEditable)
            {
                SaveButtonStatus = "Visible";
                ShowButtonStatus = "Collapsed";
                CreateButtonStatus = "Collapsed";
            }
            else
            {
                SaveButtonStatus = "Collapsed";
                ShowButtonStatus = "Visible";
                CreateButtonStatus = "Collapsed";
            }
            IsReadOnly = !isEditable;
            OnPropertyChanged(nameof(CreateButtonStatus));
            OnPropertyChanged(nameof(SaveButtonStatus));
            OnPropertyChanged(nameof(ShowButtonStatus));
            OnPropertyChanged(nameof(IsReadOnly));
        }

        /// <summary>
        /// Конструктор объекта AnimeChanCard ViewModel
        /// </summary>
        public AnimeChanCardVM()
        {
            ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<BourgeoisLogic>();
            shared = new SharedAnimeChan(new AnimeChanDTO("", "", 0,0,0,0,0, new List<SkillDTO>()));

            shared.Changed += () =>
            {
                Skills.Clear();
                foreach (var skill in shared.DTO.Skills)
                    Skills.Add(skill);
            };
            IsReadOnly = false;
            SaveButtonStatus = "Collapsed";
            ShowButtonStatus = "Collapsed";
            CreateButtonStatus = "Visible";
            OnPropertyChanged(nameof(CreateButtonStatus));
            OnPropertyChanged(nameof(SaveButtonStatus));
            OnPropertyChanged(nameof(ShowButtonStatus));
            OnPropertyChanged(nameof(IsReadOnly));
        }

        /// <summary>
        /// Метод, сообщающий о готовности к работе
        /// </summary>
        public void Start()
        {
            SaveCommand = new RelayCommand(Save);
            ShowCommand = new RelayCommand(Show);
            CreateCommand = new RelayCommand(Create);
            ChangeSkillsCommand = new RelayCommand(Change);

            AnimeChanCardMVReadyEvent.Invoke(this);
        }

        /// <summary>
        /// Метод загрузки ID
        /// </summary>
        /// <param name="id">ID тянки</param>
        private void LoadId(int id)
        {
            newId = id;
        }

        /// <summary>
        /// Метод сохранения изменений
        /// </summary>
        private void Save()
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
                                    RequestSave.Invoke();
                                    logic.SaveChangeAnimeChan(shared.DTO.FirstName, shared.DTO.LastName, shared.DTO.Age, shared.DTO.Height, shared.DTO.Weight, shared.DTO.Size, shared.DTO.Skills, shared.DTO.Id);
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

        /// <summary>
        /// Метод активации события открытия окна итогов
        /// </summary>
        private void Show()
        {
            OpenConclutionEvent.Invoke(shared.DTO);
        }

        /// <summary>
        /// Метод создания тянки
        /// </summary>
        private void Create()
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
                                    logic.AddAnimeChan(shared.DTO.FirstName, shared.DTO.LastName, shared.DTO.Age, shared.DTO.Height, shared.DTO.Weight, shared.DTO.Size, shared.DTO.Skills);
                                    logic.LoadIdEvent += LoadId;
                                    logic.LoadId();
                                    shared.Update(id: newId);
                                    RequestCreate.Invoke(shared.DTO);
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

        /// <summary>
        /// Метод изменения скиллов тянки
        /// </summary>
        private void Change()
        {

            OpenSkillsSettingsEvent.Invoke(shared);
        }
        
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}