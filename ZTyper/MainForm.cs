using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using ZUtilities;

namespace ZTyper
{
    public partial class MainForm : Form
    {
        #region vars
        KeyHookManager m_KeyboardManager;
        MouseHookManager m_MouseManager;
        List<List<string>> m_MasterList;
        List<List<string>> m_TempList;

        List<int> m_Indicies;

        Thread HWndThread;
        IntPtr m_MyHWND;

        IntPtr CurrentWindow;
        IntPtr LastWindow;

        StringBuilder m_StringBuilder;

        public bool DockMouse;

        private NotifyIcon m_Icon;

        string LogFileName;

        int wordIndex;
        char[] m_Alphabet;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            #region initilaizeRandomVars
            m_MasterList = new List<List<string>>();
            m_TempList = new List<List<string>>();
            m_Indicies = new List<int>();
            wordIndex = 1;

            LogFileName = "Log.txt";
            m_StringBuilder = new StringBuilder();
            new StreamWriter(LogFileName);

            m_MyHWND = this.Handle;
            DockMouse = true;

            this.Opacity = 80;

            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            m_Alphabet = alphabet;
            #endregion

            #region threads
            HWndThread = new Thread(new ThreadStart(WatchHWNDs));
            HWndThread.IsBackground = true;
            HWndThread.Start();
            #endregion

            #region KeyboardAndMouseManagers
            m_MouseManager = new MouseHookManager();
            m_MouseManager.OnMouseActivity += new MouseEventHandler(MouseManager_Activity);
            m_MouseManager.Start();

            m_KeyboardManager = new KeyHookManager();
            m_KeyboardManager.KeyDown += new KeyEventHandler(KeyboardManager_KeyDown);
            m_KeyboardManager.Start();
            #endregion

            #region SystemTray
            m_Icon = new NotifyIcon();

            m_Icon.Icon = Properties.Resources.keyboard;

            MenuItem[] items = new MenuItem[4];
            items[3] = new MenuItem("Exit");
            items[3].Click += new EventHandler(Exit);
            items[2] = new MenuItem("About");
            items[2].Click += new EventHandler(About_Click);
            items[1] = new MenuItem("Update");
            items[1].Click += new EventHandler(Update_Click);
            items[0] = new MenuItem("Customize");
            items[0].Click += new EventHandler(Customize_Click);

            m_Icon.ContextMenu = new ContextMenu(items);
            m_Icon.Visible = true;
            m_Icon.BalloonTipIcon = ToolTipIcon.Info;
            m_Icon.BalloonTipText = "ZTyper";
            //m_Icon.BalloonTipClicked += new EventHandler(m_Icon_MouseClick);
            //m_Icon.MouseClick += new MouseEventHandler(m_Icon_MouseClick);
            m_Icon.Text = this.Text;

            #endregion

            #region initialSorting
            using (StringReader sr = new StringReader(Properties.Resources.words))
            {
                char currentLetter = 'a';
                string line;
                int index = 0;
                m_MasterList.Add(new List<string>());

                while ((line = sr.ReadLine()) != null)
                {
                    if (line[0] != currentLetter)
                    {
                        index++;
                        int temp = (int)currentLetter;
                        temp++;
                        currentLetter = (char)temp;
                        m_MasterList.Add(new List<string>());
                    }
                    m_MasterList[index].Add(line);
                }
                m_TempList = new List<List<string>>(m_MasterList);
            }
            #endregion
        }
        #region SystemTray
        private void Exit(object sender, EventArgs e)
        {
            m_Icon.Visible = false;
            m_Icon.Dispose();
            m_Icon.ContextMenu = null;
            Application.Exit();
            Environment.Exit(0);
        }

        private void About_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.drsoxen.tumblr.com");
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Updater.Queery(false);
        }

        private void Customize_Click(object sender, EventArgs e)
        {
            new Customize(this);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit(sender, e);
        }
        #endregion

        #region WindowHandle
        void WatchHWNDs()
        {
            while (true)
            {
                IntPtr CurrentWindow = NativeWin32.GetForegroundWindow();
                if (CurrentWindow == m_MyHWND)
                    NativeWin32.SetForegroundWindow(LastWindow);
                LastWindow = CurrentWindow;
                Thread.Sleep(10);
            }
        }
        #endregion

        #region MouseAndKeyboardActivities
        void MouseManager_Activity(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Hide();
        }

        void KeyboardManager_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode >= 65 && (int)e.KeyCode <= 91)
            {
                SearchLetter((int)e.KeyCode - 65);
                m_Indicies.Add((int)e.KeyCode - 65);                
            }

            if (e.KeyCode == Keys.Space)
            {
                resetAll();
            }

            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                listBox_MainListBox.SelectedIndex++;
            }

            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                listBox_MainListBox.SelectedIndex--;
            }

            if (e.KeyCode == Keys.Back)
            {
                if (m_Indicies.Count > 0)
                {
                    m_Indicies.RemoveAt(m_Indicies.Count - 1);
                    resetAll(false);
                }

                for (int i = 0; i < m_Indicies.Count; i++)
                {
                    SearchLetter(m_Indicies[i]);
                }
            }

            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                button_Insert_Click(sender, e);
                resetAll();
            }

            if (e.KeyCode == Keys.Escape)
                resetAll();

            if (e.KeyCode == Keys.F2)
                System.Diagnostics.Process.Start(LogFileName);
        }

        void SearchLetter(int index)
        {
            if (m_TempList[index].Count > 0)
            {
                this.Show();
                if (DockMouse)
                    this.Location = MousePosition;
                else
                    this.Location = new Point(0, 0);

                int currentLetter = 0;
                List<List<string>> localTempList = new List<List<string>>();

                listBox_MainListBox.DataSource = m_TempList[index];
                //this.Height = m_TempList[index].Count * (int)listBox_MainListBox.Font.Size + textBox_CurrentWord.Height;

                for (int i = 0; i < 26; i++)
                    localTempList.Add(new List<string>());

                for (int i = 0; i < m_TempList[index].Count; i++)
                {
                    if (m_TempList[index][i].Length > wordIndex)
                    {
                        while (m_TempList[index][i][wordIndex] != m_Alphabet[currentLetter])
                        {
                            currentLetter++;
                        }
                        localTempList[currentLetter].Add(m_TempList[index][i]);
                    }
                }
                m_TempList = new List<List<string>>(localTempList);
                wordIndex++;
            }
            else
            {
                listBox_MainListBox.DataSource = null;
                this.Hide();
            }
            textBox_CurrentWord.Text += (char)(index + 97);
        }

        #endregion

        #region SudgestionManagers
        void resetAll(bool clearIndicies = true)
        {
            this.Hide();
            wordIndex = 1;
            m_TempList = new List<List<string>>(m_MasterList);
            textBox_CurrentWord.Clear();
            listBox_MainListBox.DataSource = null;

            if (clearIndicies)
            {
                m_Indicies.Clear();
            }
        }

        private void button_Insert_Click(object sender, EventArgs e)
        {
            string FullWord;

            string temp = listBox_MainListBox.SelectedItem.ToString();
            FullWord = temp;
            temp = temp.Remove(0, textBox_CurrentWord.Text.Length);

            for (int i = 0; i < temp.Length; i++)
            {
                m_Indicies.Add(((int)temp[i])-65);
            }

            textBox_CurrentWord.Text = FullWord;

            SendKeys.Send(temp);
            Log(FullWord);
        }

        private void Log(string toLog)
        {
            string fileName = "Log.txt";
            using (StreamReader sr = new StreamReader(fileName))
            {
                m_StringBuilder.Append(toLog + " ");
            }
            using (StreamWriter outfile = new StreamWriter(fileName))
            {
                outfile.Write(m_StringBuilder.ToString());
            }

        }
        #endregion

        #region formStuff
        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion


    }
}
