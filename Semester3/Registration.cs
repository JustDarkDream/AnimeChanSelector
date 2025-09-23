using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                                    Error error = new Error("Ничего не введено в строку \"Фамилия\". Введите что-нибудь");
                                    error.ShowDialog();
                                }
                            }
                            else
                            {
                                Error error = new Error("Ничего не введено в строку \"Имя\". Введите что-нибудь");
                                error.ShowDialog();
                            }
                        }
                        else
                        {
                            Error error = new Error("Введено некорректное значение в \"Размер\". Введите неотрицательно число");
                            error.ShowDialog();
                        }
                    }
                    else
                    {
                        Error error = new Error("Введено некорректное значение в \"Вес\". Введите неотрицательно число");
                        error.ShowDialog();
                    }
                }
                else
                {
                    Error error = new Error("Введено некорректное значение в \"Рост\". Введите неотрицательно число");
                    error.ShowDialog();
                }
            }
            else
            {
                Error error = new Error("Введено некорректное значение в \"Возраст\". Введите неотрицательно число");
                error.ShowDialog();
            }
        }
    }
}
