using Model;

namespace ViewForms
{
    public partial class Registration : Form
    {
        BourgeoisLogic logic = new BourgeoisLogic();
        
        /// <summary>
        /// Конструктор формы регистрации
        /// </summary>
        public Registration()
        {
            InitializeComponent();
            firstName.Text = "";
            lastName.Text = "";
            ageValue.Text = "";
            heightValue.Text = "";
            weightValue.Text = "";
            sizeValue.Text = "";
        }

        ///<summary>Вызывается при нажатии на кнопку зарегестрироваться. Регистрирует пользователя в специальный класс (MainPerson)</summary>
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
                                    logic.SaveMainPerson(firstName.Text, lastName.Text, age, height, weight, size);
                                    this.DialogResult = DialogResult.OK; //Сообщаем, что изменения мы сохраняем
                                    Close();
                                }
                                else
                                {
                                    ErrorForm error = new ErrorForm("Ничего не введено в строку \"Фамилия\"");
                                    error.ShowDialog();
                                }
                            }
                            else
                            {
                                ErrorForm error = new ErrorForm("Ничего не введено в строку \"Имя\"");
                                error.ShowDialog();
                            }
                        }
                        else
                        {
                            ErrorForm error = new ErrorForm("Введено некорректное значение в \"Размер\"");
                            error.ShowDialog();
                        }
                    }
                    else
                    {
                        ErrorForm error = new ErrorForm("Введено некорректное значение в \"Вес\"");
                        error.ShowDialog();
                    }
                }
                else
                {
                    ErrorForm error = new ErrorForm("Введено некорректное значение в \"Рост\"");
                    error.ShowDialog();
                }
            }
            else
            {
                ErrorForm error = new ErrorForm("Введено некорректное значение в \"Возраст\"");
                error.ShowDialog();
            }
        }

        /// <summary>
        /// Событие нажатия кнопки автозаполнения
        /// </summary>
        /// <param name="sender">Кнопка автозаполнения</param>
        /// <param name="e">Контейнер аргументов</param>
        private void btnAutoInput_Click(object sender, EventArgs e)
        {
            this.firstName.Text = "Фогель";
            this.lastName.Text = "Мактрахер";
            this.ageValue.Text = "25";
            this.sizeValue.Text = "15";
            this.heightValue.Text = "171";
            this.weightValue.Text = "46";
        }

        /// <summary>
        /// Событие загрузки формы регистрации
        /// </summary>
        /// <param name="sender">Форма регистрации</param>
        /// <param name="e">Контейнер аргументов</param>
        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}
