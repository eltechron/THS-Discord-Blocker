using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THS_Discord_Blocker
{
    public partial class ConfigToolDialog : Form
    {
        public ConfigToolDialog()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }

        private void ConfigToolDialog_Load(object sender, EventArgs e)
        {
            SystemSounds.Exclamation.Play();
        }
    }
}
