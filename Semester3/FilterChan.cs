using Model;
using System.Diagnostics;

namespace ViewForms
{
    public partial class FilterChan : Form
    {
        BourgeoisLogic logic = new BourgeoisLogic();
        
        /// <summary>
        /// Конструктор формы фильтра
        /// </summary>
        public FilterChan()
        {
            InitializeComponent();
            FilterStats filterStats = logic.LoadFilterStats();

            ageFrom.Text = filterStats.AgeFrom.ToString();
            ageTo.Text = filterStats.AgeTo.ToString();
            heightFrom.Text = filterStats.HeightFrom.ToString();
            heightTo.Text = filterStats.HeightTo.ToString();
            sizeFrom.Text = filterStats.SizeFrom.ToString();
            sizeTo.Text = filterStats.SizeTo.ToString();
            weightFrom.Text = filterStats.WeightFrom.ToString();
            weightTo.Text = filterStats.WeightTo.ToString();

            checkBox1.Checked = filterStats.isСonsiderAll;

            foreach (var skill in filterStats.Skills)
            {
                ListViewItem item = new ListViewItem(skill.Name);
                item.Tag = skill;

                listView1.Items.Add(item);
            }
        }

        ///<summary>Вызывается при нажатии на кнопку сохранения. Сохраняем все данные фильтрации введенные пользователем</summary>
        private void saveFilter_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ageFrom.Text, out int agefrom) && agefrom >= 0)
            {
                if (int.TryParse(ageTo.Text, out int ageto) && ageto >= 0)
                {
                    if (int.TryParse(heightFrom.Text, out int heightfrom) && heightfrom >= 0)
                    {
                        if (int.TryParse(heightTo.Text, out int heightto) && heightto >= 0)
                        {
                            if (int.TryParse(weightFrom.Text, out int weightfrom) && weightfrom >= 0) //Проверка на корректность данных
                            {
                                if (int.TryParse(weightTo.Text, out int weightto) && weightto >= 0)
                                {
                                    if (int.TryParse(sizeFrom.Text, out int sizefrom) && sizefrom >= 0)
                                    {
                                        if (int.TryParse(sizeTo.Text, out int sizeto) && sizeto >= 0)
                                        {
                                            if (agefrom < ageto)
                                            {
                                                if (heightfrom < heightto)
                                                {
                                                    if (weightfrom < weightto)
                                                    {
                                                        if (sizefrom < sizeto)
                                                        {
                                                            List<Skill> skills = new List<Skill>();

                                                            foreach (ListViewItem item in listView1.Items) //Считывает информацию с ListView и закидывает в список
                                                            {
                                                                if (item.Tag is Skill skill)
                                                                {
                                                                    skills.Add(skill);
                                                                }
                                                            }
                                                            logic.FilterAnimeChanList(agefrom, ageto, heightfrom, heightto, weightfrom, weightto, sizefrom, sizeto, skills, checkBox1.Checked);
                                                            this.DialogResult = DialogResult.OK; //Сообщаем, что изменения мы сохраняем
                                                            Close();
                                                        }
                                                        else
                                                        {
                                                            ErrorForm error = new ErrorForm("Значение \"Размер ОТ\" не может быть больше значения \"Размер ДО\"");
                                                            error.ShowDialog();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ErrorForm error = new ErrorForm("Значение \"Вес ОТ\" не может быть больше значения \"Вес ДО\"");
                                                        error.ShowDialog();
                                                    }
                                                }
                                                else
                                                {
                                                    ErrorForm error = new ErrorForm("Значение \"Рост ОТ\" не может быть больше значения \"Рост ДО\"");
                                                    error.ShowDialog();
                                                }
                                            }
                                            else
                                            {
                                                ErrorForm error = new ErrorForm("Значение \"Возраст ОТ\" не может быть больше значения \"Возраст ДО\"");
                                                error.ShowDialog();
                                            }
                                        }
                                        else
                                        {
                                            ErrorForm error = new ErrorForm("Введено некорректное значение в \"Размер ДО\". Введите неотрицательно число");
                                            error.ShowDialog();
                                        }
                                    }
                                    else
                                    {
                                        ErrorForm error = new ErrorForm("Введено некорректное значение в \"Размер ОТ\". Введите неотрицательно число");
                                        error.ShowDialog();
                                    }
                                }
                                else
                                {
                                    ErrorForm error = new ErrorForm("Введено некорректное значение в \"Вес ДО\". Введите неотрицательно число");
                                    error.ShowDialog();
                                }
                            }
                            else
                            {
                                ErrorForm error = new ErrorForm("Введено некорректное значение в \"Вес ОТ\". Введите неотрицательно число");
                                error.ShowDialog();
                            }
                        }
                        else
                        {
                            ErrorForm error = new ErrorForm("Введено некорректное значение в \"Рост ДО\". Введите неотрицательно число");
                            error.ShowDialog();
                        }
                    }
                    else
                    {
                        ErrorForm error = new ErrorForm("Введено некорректное значение в \"Рост ОТ\". Введите неотрицательно число");
                        error.ShowDialog();
                    }
                }
                else
                {
                    ErrorForm error = new ErrorForm("Введено некорректное значение в \"Возраст ДО\". Введите неотрицательно число");
                    error.ShowDialog();
                }
            }
            else
            {
                ErrorForm error = new ErrorForm("Введено некорректное значение в \"Возраст ОТ\". Введите неотрицательно число");
                error.ShowDialog();
            }
        }

        ///<summary>Вызывается при нажатии на кнопку редактора скиллов. Открывает форму редакторов скиллов и сохраняет изменения</summary>
        private void skillsSettung_Click(object sender, EventArgs e)
        {
            List<Skill> skills = new List<Skill>();

            foreach (ListViewItem item in listView1.Items) //Считывает информацию с ListView и закидывает в список
            {
                if (item.Tag is Skill skill)
                {
                    skills.Add(skill);
                }
            }

            SkillsSetting skillsSetting = new SkillsSetting(skills); //Создаём форму для редактирования навыков

            if (skillsSetting.ShowDialog() == DialogResult.OK)
            {
                listView1.Items.Clear();

                skills.Clear();

                foreach (Skill skill in logic.LoadSkills())
                {
                    skills.Add(skill);
                }

                foreach (Skill skill2 in skills) //Отображаем в ListView сохраненные навыки с той формы
                {
                    ListViewItem newItem = new ListViewItem(skill2.Name);
                    newItem.Tag = skill2;
                    listView1.Items.Add(newItem);
                }
            }
        }

        /// <summary>
        /// Событие загрузки формы фильтра
        /// </summary>
        /// <param name="sender">Форма фильтра</param>
        /// <param name="e">Контейнер аргументов</param>
        private void FilterChan_Load(object sender, EventArgs e)
        {

        }
    }
}
