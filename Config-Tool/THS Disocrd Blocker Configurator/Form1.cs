using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THS_Disocrd_Blocker_Configurator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        string CurrentDiscord;
        bool CurrentEnabled;

        private void enabledB_Click(object sender, EventArgs e)
        {
            if (CurrentEnabled)
            {
                enabledB.BackColor = Color.Red;
                enabledB.Text = "False";
                FileHandler.SaveConfig(false, CurrentDiscord);
            }
            else
            {
                enabledB.BackColor = Color.Green;
                enabledB.Text = "True";
                FileHandler.SaveConfig(true, CurrentDiscord);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileHandler.SaveConfig(true, @"C:\Users\eltechron\AppData\Local\DiscordCanary\Update.exe");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileHandler.CreateFolder();
            System.Threading.Thread.Sleep(500);
            XmlReader.Return r = new XmlReader.Return();
            r = XmlReader.ReadXml();
            CurrentEnabled = r.enabled;
            CurrentDiscord = r.path;
            if (!CurrentEnabled)
            {
                enabledB.BackColor = Color.Red;
                enabledB.Text = "False";
            }
            else
            {
                enabledB.BackColor = Color.Green;
                enabledB.Text = "True";
            }
            exeTB.Text = r.path;
        }
    }
}
