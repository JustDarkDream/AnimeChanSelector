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
    public partial class ErrorForm : Form
    {
        public ErrorForm(string str)
        {
            InitializeComponent();
            label2.Text = str;
        }
    }
}
