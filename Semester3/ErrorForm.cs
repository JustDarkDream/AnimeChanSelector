namespace ViewForms
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string str)
        {
            InitializeComponent();
            label2.Text = str;
        }
    }
}
