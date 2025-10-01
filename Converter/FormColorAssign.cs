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
    public partial class FormColorAssign : Form
    {
        public FormColorAssign()
        {
            InitializeComponent();
        }

        private void FormColorAssign_Load(object sender, EventArgs e)
        {
            //richTextBoxBlack.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int v1 = (int)numericUpDown1.Value;
            int v2 = (int)numericUpDown2.Value;
            int v3 = (int)numericUpDown3.Value;

            if ((v1 == 1 && v2 == 1 && v3 == 1) || ((v1+v2+v3) != 3))
            {
                DialogResult result = MessageBox.Show("Warning: index values should be distinct. The input provided is not and will result in color loss -- is that OK?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.No || result == DialogResult.Cancel)
                {
                    return;
                    
                }
            }
            StaticHelperTools.resetImageColor((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
            Close();
            DialogResult = DialogResult.OK;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            if(nud.Value > 2)
            {
                nud.Value = 2;
            }
            else if (nud.Value < 0)
            {
                nud.Value = 2;
            }
        }
    }
}
