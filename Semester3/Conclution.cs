using Shared;

namespace ViewForms
{
    public partial class Conclution : Form, IViewConclution
    {
        public event Action MakeConclutionEvent;
        /// <summary>
        /// Конструктор формы заключения
        /// </summary>
        public Conclution()
        {
        }

        public bool CorrectWork()
        {
            InitializeComponent();

            // Показываем форму и возвращаем результат
            DialogResult result = this.ShowDialog();
            return result == DialogResult.OK;
        }

        public void WriteConclution(string str)
        {
            richTextBox1.Text = str;
        }

        /// <summary>
        /// Событие загрузки формы заключения
        /// </summary>
        /// <param name="sender">Форма заключения</param>
        /// <param name="e">Контейнер аргументов</param>
        private void Conclution_Load(object sender, EventArgs e)
        {
            MakeConclutionEvent.Invoke();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
