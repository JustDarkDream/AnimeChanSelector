using Model;

namespace ViewForms
{
    public partial class Conclution : Form
    {
        BourgeoisLogic logic = new BourgeoisLogic();
        
        /// <summary>
        /// Конструктор формы заключения
        /// </summary>
        public Conclution()
        {
            InitializeComponent();
            richTextBox1.Text = logic.Conclution();
        }

        /// <summary>
        /// Событие загрузки формы заключения
        /// </summary>
        /// <param name="sender">Форма заключения</param>
        /// <param name="e">Контейнер аргументов</param>
        private void Conclution_Load(object sender, EventArgs e)
        {

        }
    }
}
