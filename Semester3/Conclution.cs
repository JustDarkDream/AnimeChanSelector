using Model;
using Ninject;

namespace ViewForms
{
    public partial class Conclution : Form
    {
        IKernel ninjectKernel;
        BourgeoisLogic logic;
        //BourgeoisLogic logic = new BourgeoisLogic();
        
        /// <summary>
        /// Конструктор формы заключения
        /// </summary>
        public Conclution()
        {
            ninjectKernel = new StandardKernel(new SimpleConfigModule());
            logic = ninjectKernel.Get<BourgeoisLogic>();
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
