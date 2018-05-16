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
        public static System.Windows.Forms.NotifyIcon NotifyI = new System.Windows.Forms.NotifyIcon();

        private static void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static void NotifyIconNotify(int time, string title, string content, System.Windows.Forms.ToolTipIcon icon)
        {
            NotifyI.Icon = Properties.Resources.Icon1;
            NotifyI.Visible = true;
            NotifyI.ShowBalloonTip(time, title, content, icon);
            NotifyI.Visible = false;
        }
    }
}
