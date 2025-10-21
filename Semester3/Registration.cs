using Model;

namespace ViewForms
{
    public partial class Registration : Form
    {
        BourgeoisLogic logic = new BourgeoisLogic();
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

        private void lastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
