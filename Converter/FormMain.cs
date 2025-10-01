using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class FormMain : Form
    {
        //current magnification level
        int magIndex = 9;

        //magnification sizes

        static readonly float[] magFontSizes = {
            4,4.85f,5.35f,6.2f,7.15f,9.6f,10.6f,11.65f,12.85f,14.2f,15.6f,17.15f,18.85f,20.7f,22.75f,25,27.5f,30.25f,33.25f,36.55f,40.2f,44.2f,48.6f
        };

        static readonly int[] magTextBoxSizes = {
            285 ,
            300 ,
            376 ,
            402 ,
            497 ,
            658 ,
            723 ,
            806 ,
            885 ,
            931 ,
            1014,
            1105,
            1204,
            1312,
            1430,
            1558,
            1698,
            1850,
            2016,
            2197,
            2394,
            2609,
            2843,
   
        };

        ToolStripTextBox[] textboxPix = new ToolStripTextBox[9];
        public FormMain()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            InitializeComponent();
        }


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadImg();
        }

        private void toolStripButtonMagAdd_Click(object sender, EventArgs e)
        {
            //check if at max magnification
            if(magIndex == magTextBoxSizes.Length-1)
            {
                return;
            }
            magIndex++;

            groupBoxText.Width = magTextBoxSizes[magIndex] +2;
            richTextBoxMainDisplay.Width = magTextBoxSizes[magIndex];
            richTextBoxMainDisplay.Font = new Font(richTextBoxMainDisplay.Font.FontFamily, magFontSizes[magIndex]);

        }

        private void toolStripButtonMagMin_Click(object sender, EventArgs e)
        {
            //check if at min magnification
            if (magIndex == 0)
            {
                return;
            }
            magIndex--;

            groupBoxText.Width = magTextBoxSizes[magIndex] + 2;
            richTextBoxMainDisplay.Width = magTextBoxSizes[magIndex];
            richTextBoxMainDisplay.Font = new Font(richTextBoxMainDisplay.Font.FontFamily, magFontSizes[magIndex]);

        }

        private void toolStripButtonConvert_Click(object sender, EventArgs e)
        {
            loadImg();
        }

        private void loadImg()
        {
            String locationOfImg = "";
            //load image
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "bitmap files(*.bmp)|*.bmp| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    locationOfImg = dialog.FileName;
                    Bitmap temp = new Bitmap(locationOfImg);
                    String validImageMessage = StaticHelperTools.ValidateImage(temp);
                    temp.Dispose();
                    if (validImageMessage != null)
                    {
                        MessageBox.Show("Invalid image. The image you submitted " + validImageMessage + " Image must be less than or equal to 80 pixels and greater than 1 pixel in width, less than 9999 pixels and greater than 2 pixels in height, and it must only have at most 3 colors. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    MainImageBox.Image = StaticHelperTools.mainImage;
                    //resize image box
                    groupBoxImage.Height = MainImageBox.Image.Height + 25;
                    MainImageBox.Height = MainImageBox.Image.Height;
                    MainImageBox.Width = 80 * 4;
                    groupBoxImage.Width = 80 * 4;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var f = new FormPopup();
            f.ShowDialog();
            toolStripTextBox1.Text = f.returnChar;

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var f = new FormPopup();
            f.ShowDialog();
            toolStripTextBox3.Text = f.returnChar;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var f = new FormPopup();
            f.ShowDialog();
            toolStripTextBox4.Text = f.returnChar;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var f = new FormPopup();
            f.ShowDialog();
            toolStripTextBox5.Text = f.returnChar;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var f = new FormPopup();
            f.ShowDialog();
            toolStripTextBox2.Text = f.returnChar;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            var f = new FormPopup();
            f.ShowDialog();
            toolStripTextBox8.Text = f.returnChar;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            var f = new FormPopup();
            f.ShowDialog();
            toolStripTextBox7.Text = f.returnChar;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var f = new FormPopup();
            f.ShowDialog();
            toolStripTextBox6.Text = f.returnChar;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            var f = new FormPopup();
            f.ShowDialog();
            toolStripTextBox9.Text = f.returnChar;
        }

        

        private void toolStripButtonReset_Click(object sender, EventArgs e)
        {

            DialogResult confirmResult = MessageBox.Show(
                    "Are you sure you want to reset panel characters to default?",
                    "Confirm Reset",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (confirmResult == DialogResult.Yes)
            {
                toolStripTextBox1.Text = "█";//
                toolStripTextBox3.Text = "▓";//▒
                toolStripTextBox4.Text = " ";//
                toolStripTextBox5.Text = "▀";//▄▀
                toolStripTextBox2.Text = "▄";//
                toolStripTextBox8.Text = "▀";//
                toolStripTextBox7.Text = "▄";//
                toolStripTextBox6.Text = "▓";//
                toolStripTextBox9.Text = "▓";//
            }
        }
        private void toolStripButtonInvertReset_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to reset panel characters to default inverse?",
                "Confirm Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (confirmResult == DialogResult.Yes)
            {
                toolStripTextBox1.Text = " ";
                toolStripTextBox3.Text = "▓";
                toolStripTextBox4.Text = "█";
                toolStripTextBox5.Text = "▄";
                toolStripTextBox2.Text = "▀";
                toolStripTextBox8.Text = "▄";
                toolStripTextBox7.Text = "▀";
                toolStripTextBox6.Text = "▓";
                toolStripTextBox9.Text = "▓";
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            textboxPix[0] = toolStripTextBox1;//
            textboxPix[1] = toolStripTextBox3;//"▓";//▒
            textboxPix[2] = toolStripTextBox4;//" ";
            textboxPix[3] = toolStripTextBox5;//"▀";//▄▀
            textboxPix[4] = toolStripTextBox2;//"▄";
            textboxPix[5] = toolStripTextBox8;//"▀";
            textboxPix[6] = toolStripTextBox7;//"▄";
            textboxPix[7] = toolStripTextBox6;//"▓";
            textboxPix[8] = toolStripTextBox9;//"▓";
            if (StaticHelperTools.mainDataImage == null) return;
            int charArrSize = StaticHelperTools.mainDataImage.Height + StaticHelperTools.mainDataImage.Width * (StaticHelperTools.mainDataImage.Height / 2);

            char[] result = new char[charArrSize];
            int index = 0;
            for(int i = 0; i < StaticHelperTools.mainDataImage.Height; i+=2)
            {
                for (int j = 0; j < StaticHelperTools.mainDataImage.Width; j++)
                {
                    result[index] = calculateConversion(i,j);
                    index++;
                }
                result[index] = '\n';
                index++;
            }
            richTextBoxMainDisplay.Text = new string(result);
        }

        private char calculateConversion(int row, int col)
        {
            String deleteThis = StaticHelperTools.mainDataImage.GetPixel(col, row).Name + "" + StaticHelperTools.mainDataImage.GetPixel(col, row + 1).Name;
            int index = StaticHelperTools.colorMap[StaticHelperTools.mainDataImage.GetPixel(col, row).Name + "" + StaticHelperTools.mainDataImage.GetPixel(col, row + 1).Name];
            return (char)textboxPix[index].Text[0]; //get first char of indexed pix textbox
        }

        private void toolStripButtonSwap_Click(object sender, EventArgs e)
        {

            if (richTextBoxMainDisplay.BackColor != Color.Black)
            {
                richTextBoxMainDisplay.BackColor = Color.Black;
                richTextBoxMainDisplay.ForeColor = Color.White;
            }
            else
            {
                richTextBoxMainDisplay.BackColor = Color.White;
                richTextBoxMainDisplay.ForeColor = Color.Black;
            }
        }

        private void toolStripButtonColorPick_Click(object sender, EventArgs e)
        {
            var f = new FormColorAssign();
            //f.ShowDialog();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MainImageBox.Image = StaticHelperTools.mainImage;

            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    //sfd.FilterIndex = 2;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, richTextBoxMainDisplay.Text);
                    }
                }
            
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FormAbout();
            f.ShowDialog();
        }


    }
}
