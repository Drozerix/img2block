namespace Converter
{
    partial class FormAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.textBoxNfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxNfo
            // 
            this.textBoxNfo.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBoxNfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNfo.Font = new System.Drawing.Font("Perfect DOS VGA 437 Win", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(255)));
            this.textBoxNfo.ForeColor = System.Drawing.Color.White;
            this.textBoxNfo.Location = new System.Drawing.Point(0, 0);
            this.textBoxNfo.Multiline = true;
            this.textBoxNfo.Name = "textBoxNfo";
            this.textBoxNfo.ReadOnly = true;
            this.textBoxNfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNfo.Size = new System.Drawing.Size(759, 592);
            this.textBoxNfo.TabIndex = 0;
            this.textBoxNfo.TabStop = false;
            this.textBoxNfo.Text = resources.GetString("textBoxNfo.Text");
            this.textBoxNfo.TextChanged += new System.EventHandler(this.textBoxNfo_TextChanged);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 592);
            this.Controls.Add(this.textBoxNfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAbout";
            this.Text = "FormAbout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNfo;
    }
}