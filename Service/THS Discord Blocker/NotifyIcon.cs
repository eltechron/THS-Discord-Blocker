using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THS_Discord_Blocker
{
    class NotifyIcon
    {
        public static System.Windows.Forms.NotifyIcon notifyI = new System.Windows.Forms.NotifyIcon();

        private static void exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static void ni_notify(int time, string title, string content, System.Windows.Forms.ToolTipIcon icon)
        {
            notifyI.Icon = Properties.Resources.Icon1;
            notifyI.Visible = true;
            notifyI.ShowBalloonTip(time, title, content, icon);
            notifyI.Visible = false;
        }
    }
}
