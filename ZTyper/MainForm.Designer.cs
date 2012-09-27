namespace ZTyper
{
    partial class MainForm
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
            this.listBox_MainListBox = new System.Windows.Forms.ListBox();
            this.textBox_CurrentWord = new System.Windows.Forms.TextBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.SuspendLayout();
            // 
            // listBox_MainListBox
            // 
            this.listBox_MainListBox.BackColor = System.Drawing.SystemColors.Control;
            this.listBox_MainListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_MainListBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listBox_MainListBox.FormattingEnabled = true;
            this.listBox_MainListBox.Location = new System.Drawing.Point(12, 25);
            this.listBox_MainListBox.Name = "listBox_MainListBox";
            this.listBox_MainListBox.Size = new System.Drawing.Size(185, 182);
            this.listBox_MainListBox.TabIndex = 0;
            // 
            // textBox_CurrentWord
            // 
            this.textBox_CurrentWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_CurrentWord.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox_CurrentWord.Location = new System.Drawing.Point(12, 2);
            this.textBox_CurrentWord.Name = "textBox_CurrentWord";
            this.textBox_CurrentWord.ReadOnly = true;
            this.textBox_CurrentWord.Size = new System.Drawing.Size(185, 13);
            this.textBox_CurrentWord.TabIndex = 3;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(212, 228);
            this.shapeContainer1.TabIndex = 4;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 213;
            this.lineShape1.Y1 = 19;
            this.lineShape1.Y2 = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 228);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_CurrentWord);
            this.Controls.Add(this.listBox_MainListBox);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_MainListBox;
        private System.Windows.Forms.TextBox textBox_CurrentWord;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
    }
}

