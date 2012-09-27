using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZTyper
{
    public partial class Customize : Form
    {
        MainForm m_ParentForm;
        bool goodToGo;
        public Customize(MainForm ParentForm)
        {
            goodToGo = false;
            m_ParentForm = ParentForm;
            InitializeComponent();
            numericUpDown_Opacity.Value = (decimal)m_ParentForm.Opacity*100;

            this.radioButton_ZeroDock.Checked = !m_ParentForm.DockMouse;
            this.radioButton_MouseDock.Checked = m_ParentForm.DockMouse;

            this.Show();
            goodToGo = true;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown_Opacity_ValueChanged(object sender, EventArgs e)
        {
            m_ParentForm.Opacity = (double)numericUpDown_Opacity.Value/100;
        }

        private void radioButton_MouseDock_CheckedChanged(object sender, EventArgs e)
        {
            if(goodToGo)
            m_ParentForm.DockMouse = !m_ParentForm.DockMouse;
        }
    }
}
