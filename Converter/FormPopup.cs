using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class FormPopup : Form
    {
        public string returnChar = "";
        public FormPopup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            returnChar = (sender as Button).Text;
            Close();
            DialogResult = DialogResult.OK;
            
        }
    }
}
