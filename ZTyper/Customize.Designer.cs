namespace ZTyper
{
    partial class Customize
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
            this.button_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_Opacity = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_MouseDock = new System.Windows.Forms.RadioButton();
            this.radioButton_ZeroDock = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Opacity)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(104, 227);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 0;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opacity";
            // 
            // numericUpDown_Opacity
            // 
            this.numericUpDown_Opacity.Location = new System.Drawing.Point(152, 8);
            this.numericUpDown_Opacity.Name = "numericUpDown_Opacity";
            this.numericUpDown_Opacity.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Opacity.TabIndex = 2;
            this.numericUpDown_Opacity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_Opacity.ValueChanged += new System.EventHandler(this.numericUpDown_Opacity_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dock";
            // 
            // radioButton_MouseDock
            // 
            this.radioButton_MouseDock.AutoSize = true;
            this.radioButton_MouseDock.Location = new System.Drawing.Point(152, 59);
            this.radioButton_MouseDock.Name = "radioButton_MouseDock";
            this.radioButton_MouseDock.Size = new System.Drawing.Size(57, 17);
            this.radioButton_MouseDock.TabIndex = 4;
            this.radioButton_MouseDock.TabStop = true;
            this.radioButton_MouseDock.Text = "Mouse";
            this.radioButton_MouseDock.UseVisualStyleBackColor = true;
            this.radioButton_MouseDock.CheckedChanged += new System.EventHandler(this.radioButton_MouseDock_CheckedChanged);
            // 
            // radioButton_ZeroDock
            // 
            this.radioButton_ZeroDock.AutoSize = true;
            this.radioButton_ZeroDock.Location = new System.Drawing.Point(232, 59);
            this.radioButton_ZeroDock.Name = "radioButton_ZeroDock";
            this.radioButton_ZeroDock.Size = new System.Drawing.Size(40, 17);
            this.radioButton_ZeroDock.TabIndex = 5;
            this.radioButton_ZeroDock.Text = "0,0";
            this.radioButton_ZeroDock.UseVisualStyleBackColor = true;
            // 
            // Customize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.radioButton_ZeroDock);
            this.Controls.Add(this.radioButton_MouseDock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_Opacity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Close);
            this.Name = "Customize";
            this.Text = "Customize";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Opacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Opacity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_MouseDock;
        private System.Windows.Forms.RadioButton radioButton_ZeroDock;
    }
}