namespace EP_StupidConverter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtbESWin_Text = new System.Windows.Forms.RichTextBox();
            this.rtbPrologText = new System.Windows.Forms.RichTextBox();
            this.btConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbESWin_Text
            // 
            this.rtbESWin_Text.Location = new System.Drawing.Point(12, 12);
            this.rtbESWin_Text.Name = "rtbESWin_Text";
            this.rtbESWin_Text.Size = new System.Drawing.Size(492, 592);
            this.rtbESWin_Text.TabIndex = 0;
            this.rtbESWin_Text.Text = resources.GetString("rtbESWin_Text.Text");
            // 
            // rtbPrologText
            // 
            this.rtbPrologText.Location = new System.Drawing.Point(552, 12);
            this.rtbPrologText.Name = "rtbPrologText";
            this.rtbPrologText.Size = new System.Drawing.Size(700, 592);
            this.rtbPrologText.TabIndex = 1;
            this.rtbPrologText.Text = "";
            // 
            // btConvert
            // 
            this.btConvert.Location = new System.Drawing.Point(511, 12);
            this.btConvert.Name = "btConvert";
            this.btConvert.Size = new System.Drawing.Size(35, 23);
            this.btConvert.TabIndex = 2;
            this.btConvert.Text = "=>";
            this.btConvert.UseVisualStyleBackColor = true;
            this.btConvert.Click += new System.EventHandler(this.btConvert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 616);
            this.Controls.Add(this.btConvert);
            this.Controls.Add(this.rtbPrologText);
            this.Controls.Add(this.rtbESWin_Text);
            this.Name = "Form1";
            this.Text = "ESWin -> Prolog Stupid Converter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbESWin_Text;
        private System.Windows.Forms.RichTextBox rtbPrologText;
        private System.Windows.Forms.Button btConvert;
    }
}

