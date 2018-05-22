///
/// THS Discord Blocker
/// Written by Liesel Downes
/// Licensed under the MIT License
/// 

using System;
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

        public static void NotifyIconNotify(int time, string title, string content, ToolTipIcon icon)
        {
            NotifyI.Icon = Properties.Resources.Icon1;
            NotifyI.Visible = true;
            NotifyI.ShowBalloonTip(time, title, content, icon);
            NotifyI.Visible = false;
        }
    }
}
