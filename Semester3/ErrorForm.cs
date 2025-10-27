namespace ViewForms
{
    public partial class ErrorForm : Form
    {
        /// <summary>
        /// Конструктор окна ошибки
        /// </summary>
        /// <param name="str">Строка ошибки для вывода</param>
        public ErrorForm(string str)
        {
            InitializeComponent();
            label2.Text = str;
        }

        /// <summary>
        /// Событие загрузки окна ошибки
        /// </summary>
        /// <param name="sender">Окно ошибки</param>
        /// <param name="e">Контейнер аругментов</param>
        private void ErrorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
