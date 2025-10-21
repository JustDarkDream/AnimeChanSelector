using Model;
using System.Diagnostics;

namespace ViewForms
{
    public partial class AnimeChanCard : Form
    {
        BourgeoisLogic logic = new BourgeoisLogic();
        int animeChanId = 0;

        public AnimeChanCard(AnimeChan animeChan, bool isEditable) //Вызывается, если пользователь хочет редактировать или посмотреть на тянку
        {
            InitializeComponent();
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
                ListViewItem item = new ListViewItem(skill.Name);
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
        public AnimeChanCard() //Вызывается, если пользователь хочет создать новую тянку
        {
            InitializeComponent();
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

        ///<summary>Вызывается при нажатии на кнопку редактора скиллов. Открывает форму редакторов скиллов и сохраняет изменения</summary>
        private void skillsSettung_Click(object sender, EventArgs e)
        {
            List<Skill> skills = new List<Skill>();

            foreach (ListViewItem item in listView1.Items) //Считывает информацию с ListView и закидывает в список
            {
                if (item.Tag is Skill skill3)
                {
                    skills.Add(skill3);
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
                                        List<Skill> skills = new List<Skill>();

                                        foreach (ListViewItem item in listView1.Items) //Считывает информацию с ListView и закидывает в список
                                        {
                                            if (item.Tag is Skill skill)
                                            {
                                                skills.Add(skill);
                                            }
                                        }
                                        logic.AddAnimeChan(firstName.Text, lastName.Text, age, height, weight, size, skills);
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
                                    List<Skill> skills = new List<Skill>();

                                    foreach (ListViewItem item in listView1.Items) //Считывает информацию с ListView и закидывает в список
                                    {
                                        if (item.Tag is Skill skill)
                                        {
                                            skills.Add(skill);
                                        }
                                    }
                                    logic.SaveChangeAnimeChan(firstName.Text, lastName.Text, age, height, weight, size, skills, animeChanId);
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
            logic.SaveId(animeChanId);
            this.DialogResult = DialogResult.OK; //Сообщаем, что изменения мы сохраняем
            Close();
        }

        private void AnimeChanCard_Load(object sender, EventArgs e)
        {

        }
    }
}
