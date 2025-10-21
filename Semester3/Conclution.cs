using Model;

namespace ViewForms
{
    public partial class Conclution : Form
    {
        BourgeoisLogic logic = new BourgeoisLogic();
        public Conclution()
        {
            InitializeComponent();
            richTextBox1.Text = logic.Conclution();
        }
    }
}
