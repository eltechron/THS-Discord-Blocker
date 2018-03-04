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

namespace THS_Disocrd_Blocker_Configurator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        //bool CurrentEnabled = bool.Parse(File.ReadAllText(FileHandler.EnabledFile));

        private void enabledB_Click(object sender, EventArgs e)
        {
            //if (CurrentEnabled)
            //{
            //    enabledB.BackColor = Color.Red;
            //    enabledB.Text = "False";
            //    FileHandler.SaveConfigEnabled(false);
            //}
            //else
            //{
            //    enabledB.BackColor = Color.Green;
            //    enabledB.Text = "True";
            //    FileHandler.SaveConfigEnabled(true);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = ofd.FileName;
                MessageBox.Show(file);
                FileHandler.SaveConfigPath(file);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
