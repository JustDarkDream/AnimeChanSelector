using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewForms
{
    public partial class Error : Form
    {
        public Error(string str)
        {
            InitializeComponent();
            label2.Text = str;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
