using Ninject;
using System.Diagnostics;
using Shared;

namespace ViewForms
{
    public partial class AnimeChanCard : Form, IViewAnimeChanCard
    {
        public event Action LoadSkillsEvent;
        public event Action<string, string, int, int, int, int, List<SkillDTO>> AddAnimeChanEvent;
        public event Action<string, string, int, int, int, int, List<SkillDTO>, int> SaveChangeAnimeChanEvent;
        public event Action<int> SaveIdEvent;

        public event Func<IViewSkillSetting> GetIViewSkillSettingEvent;

        int animeChanId = 0;
        AnimeChanDTO animeChan;
        bool isEditable;

        List<SkillDTO> listSkills = new List<SkillDTO>();

        /// <summary>
        /// Конструктор формы "Инфа о тянке"
        /// </summary>
        /// <param name="animeChan">Аниме тянка</param>
        /// <param name="isEditable">Переключение между режимом редактирвоания тянки и просмотром</param>
        public AnimeChanCard(AnimeChanDTO animeChan, bool isEditable) //Вызывается, если пользователь хочет редактировать или посмотреть на тянку
        {

        }
        public AnimeChanCard() //Вызывается, если пользователь хочет создать новую тянку
        {

        }

        ///<summary>Вызывается при нажатии на кнопку редактора скиллов. Открывает форму редакторов скиллов и сохраняет изменения</summary>
        private void skillsSettung_Click(object sender, EventArgs e)
        {
            List<SkillDTO> skills = new List<SkillDTO>();
            foreach (ListViewItem item in listView1.Items) //Считывает информацию с ListView и закидывает в список
            {
                if (item.Tag is SkillDTO skill3)
                {
                    skills.Add(skill3);
                }
            }
            IViewSkillSetting skillSetting = GetIViewSkillSettingEvent.Invoke();//Создаём форму для редактирования навыков

            if (skillSetting.CorrectWork(skills))
            {

                listView1.Items.Clear();

                skills.Clear();

                LoadSkillsEvent.Invoke();

                foreach (SkillDTO skill in listSkills)
                {
                    skills.Add(skill);
                }

                foreach (SkillDTO skill2 in skills) //Отображаем в ListView сохраненные навыки с той формы
                {
                    var item = new ListViewItem(skill2.Name);
                    item.Tag = skill2;
                    listView1.Items.Add(item);
                }
            }
        }

        ///<summary>Вызывается при нажатии на кнопку добавления тянки. Сохраняет введенные пользователем данные и создаёт тянку</summary>
        private void addChan_Click(object sender, EventArgs e)
        {
            {
                if (int.TryParse(ageValue.Text, out int age) && age >= 0)
                {
                    if (int.TryParse(heightValue.Text, out int height) && height >= 0) //Проверка на корректность данных
                    {
                        if (int.TryParse(weightValue.Text, out int weight) && weight >= 0)
                        {
                            if (int.TryParse(sizeValue.Text, out int size) && size >= 0)
                            {
                                if (firstName.Text.Length > 0)
                                {
                                    if (lastName.Text.Length > 0)
                                    {
                                        List<SkillDTO> skills = new List<SkillDTO>();

                                        foreach (ListViewItem item in listView1.Items) //Считывает информацию с ListView и закидывает в список
                                        {
                                            if (item.Tag is SkillDTO skill)
                                            {
                                                skills.Add(skill);
                                            }
                                        }
                                        AddAnimeChanEvent.Invoke(firstName.Text, lastName.Text, age, height, weight, size, skills);
                                        this.DialogResult = DialogResult.OK; //Сообщаем, что изменения мы сохраняем
                                        Close();
                                    }
                                    else
                                    {
                                        ErrorForm error = new ErrorForm("Ничего не введено в строку \"Фамилия\". Введите что-нибудь");
                                        error.ShowDialog();
                                    }
                                }
                                else
                                {
                                    ErrorForm error = new ErrorForm("Ничего не введено в строку \"Имя\". Введите что-нибудь");
                                    error.ShowDialog();
                                }
                            }
                            else
                            {
                                ErrorForm error = new ErrorForm("Введено некорректное значение в \"Размер\". Введите неотрицательно число");
                                error.ShowDialog();
                            }
                        }
                        else
                        {
                            ErrorForm error = new ErrorForm("Введено некорректное значение в \"Вес\". Введите неотрицательно число");
                            error.ShowDialog();
                        }
                    }
                    else
                    {
                        ErrorForm error = new ErrorForm("Введено некорректное значение в \"Рост\". Введите неотрицательно число");
                        error.ShowDialog();
                    }
                }
                else
                {
                    ErrorForm error = new ErrorForm("Введено некорректное значение в \"Возраст\". Введите неотрицательно число");
                    error.ShowDialog();
                }
            }
        }

        ///<summary>Вызывается при нажатии на кнопку сохранения изменений. Сохраняет введенные пользователем изменения характеристик тянки</summary>
        private void saveChanges_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ageValue.Text, out int age) && age >= 0)
            {
                if (int.TryParse(heightValue.Text, out int height) && height >= 0) //Проверка на корректность данных
                {
                    if (int.TryParse(weightValue.Text, out int weight) && weight >= 0)
                    {
                        if (int.TryParse(sizeValue.Text, out int size) && size >= 0)
                        {
                            if (firstName.Text.Length > 0)
                            {
                                if (lastName.Text.Length > 0)
                                {
                                    List<SkillDTO> skills = new List<SkillDTO>();

                                    foreach (ListViewItem item in listView1.Items) //Считывает информацию с ListView и закидывает в список
                                    {
                                        if (item.Tag is SkillDTO skill)
                                        {
                                            skills.Add(skill);
                                        }
                                    }
                                    SaveChangeAnimeChanEvent.Invoke(firstName.Text, lastName.Text, age, height, weight, size, skills, animeChanId);
                                    this.DialogResult = DialogResult.OK; //Сообщаем, что изменения мы сохраняем
                                    Close();
                                }
                                else
                                {
                                    ErrorForm error = new ErrorForm("Ничего не введено в строку \"Фамилия\". Введите что-нибудь");
                                    error.ShowDialog();
                                }
                            }
                            else
                            {
                                ErrorForm error = new ErrorForm("Ничего не введено в строку \"Имя\". Введите что-нибудь");
                                error.ShowDialog();
                            }
                        }
                        else
                        {
                            ErrorForm error = new ErrorForm("Введено некорректное значение в \"Размер\". Введите число");
                            error.ShowDialog();
                        }
                    }
                    else
                    {
                        ErrorForm error = new ErrorForm("Введено некорректное значение в \"Вес\". Введите число");
                        error.ShowDialog();
                    }
                }
                else
                {
                    ErrorForm error = new ErrorForm("Введено некорректное значение в \"Рост\". Введите число");
                    error.ShowDialog();
                }
            }
            else
            {
                ErrorForm error = new ErrorForm("Введено некорректное значение в \"Возраст\". Введите число");
                error.ShowDialog();
            }
        }

        ///<summary>Вызывается при нажатии на кнопку выбора её. Отрывает форму с итогом и закрывает все остальные</summary>
        private void chooseHer_Click(object sender, EventArgs e)
        {
            SaveIdEvent.Invoke(animeChanId);
            this.DialogResult = DialogResult.OK; //Сообщаем, что изменения мы сохраняем
            Close();
        }

        /// <summary>
        /// Событие загрузки формы "Инфа о тянке"
        /// </summary>
        /// <param name="sender">Форма "Инфа о тянке"</param>
        /// <param name="e">Контейнер аргументов</param>
        private void AnimeChanCard_Load(object sender, EventArgs e)
        {

        }

        public void LoadSkills(List<SkillDTO> list)
        {
            listSkills = list;
        }

        public bool CorrectWork(AnimeChanDTO _animeChan, bool _isEditable)
        {
            InitializeComponent();
            animeChan = _animeChan;
            isEditable = _isEditable;

            // Показываем форму и возвращаем результат
            this.Load += AnimeChanCardLoad;
            DialogResult result = this.ShowDialog();
            this.Load -= AnimeChanCardLoad;
            return result == DialogResult.OK;
        }

        public bool CorrectWork()
        {
            InitializeComponent();

            // Показываем форму и возвращаем результат
            this.Load += AnimeChanCardLoadWithoutParam;
            DialogResult result = this.ShowDialog();
            this.Load -= AnimeChanCardLoadWithoutParam;
            return result == DialogResult.OK;
        }

        private void AnimeChanCardLoad(object sender, EventArgs e)
        {
            firstName.Text = animeChan.FirstName;
            lastName.Text = animeChan.LastName;

            ageValue.Text = animeChan.Age.ToString();
            heightValue.Text = animeChan.Height.ToString();
            weightValue.Text = animeChan.Weight.ToString();
            sizeValue.Text = animeChan.Size.ToString();

            animeChanId = animeChan.Id;

            listView1.Clear();

            foreach (var skill in animeChan.Skills) //Перечисляет навыки тянки
            {
                var item = new ListViewItem(skill.Name);
                item.Tag = skill;
                listView1.Items.Add(item);
            }

            //Редактирует состояние кнопок в зависимости от выбора
            addChan.Visible = false;
            addChan.Enabled = false;
            chooseHer.Visible = !isEditable;
            chooseHer.Enabled = !isEditable;
            skillsSettung.Visible = isEditable;
            skillsSettung.Enabled = isEditable;
            saveChanges.Enabled = isEditable;
            saveChanges.Visible = isEditable;

            //Редактирует состояние TextBox в зависимости от выбора
            firstName.Enabled = isEditable;
            lastName.Enabled = isEditable;
            ageValue.Enabled = isEditable;
            heightValue.Enabled = isEditable;
            weightValue.Enabled = isEditable;
            sizeValue.Enabled = isEditable;


        }

        private void AnimeChanCardLoadWithoutParam(object sender, EventArgs e)
        {
            firstName.Text = "";
            lastName.Text = "";
            ageValue.Text = "";
            heightValue.Text = "";
            weightValue.Text = "";
            sizeValue.Text = "";
            listView1.Clear();

            //Редактирует состояние кнопок в для создания тянки
            addChan.Visible = true;
            addChan.Enabled = true;
            chooseHer.Visible = false;
            chooseHer.Enabled = false;
            skillsSettung.Visible = true;
            skillsSettung.Enabled = true;
            saveChanges.Enabled = false;
            saveChanges.Visible = false;

            //Редактирует состояние TextBox для создания тянки
            firstName.Enabled = true;
            lastName.Enabled = true;
            ageValue.Enabled = true;
            heightValue.Enabled = true;
            weightValue.Enabled = true;
            sizeValue.Enabled = true;
        }
    }
}
