using NativeWifi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace THS_Discord_Blocker
{
    class service
    {

        public static string AppdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\THSDiscordBlocker";
        public static string discordPath = AppdataFolder + @"\path.cfg";

        public static void serviceInit()
        {
            //Check if Discord is already open, if so, kill it with fire!
            if (discordPath.Contains("Canary"))
            {
                killDiscord(true);
            }
            else
            {
                killDiscord(false);
            }

            //Get SSID(s)
            WlanClient wlan = new WlanClient();
            Collection<String> connectedSsids = new Collection<string>();

            foreach (WlanClient.WlanInterface wlanInterface in wlan.Interfaces)
            {
                Wlan.Dot11Ssid ssid = wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
                connectedSsids.Add(new String(Encoding.ASCII.GetChars(ssid.SSID, 0, (int)ssid.SSIDLength)));
            }
            foreach (string s in connectedSsids)
            {
                MessageBox.Show(s);
            }

            //Detect if connected to Heights network
            if (connectedSsids.Contains("THS-Students") || connectedSsids.Contains("THS-Secure") || connectedSsids.Contains("Achilleus"))
            {
                NotifyIcon.ni_notify(5000, "Heights Network Detected", "Discord will not open.", ToolTipIcon.Info);
                //Block Discord if already open?
                Environment.Exit(-1);
            }
            else
            {
                openDiscord();
            }
        }

        public static void openDiscord()
        {
            if (!File.Exists(discordPath))
            {
                NotifyIcon.ni_notify(5000, "THS Discord Blocker Error", "Config corrupt, please run the config tool again.", ToolTipIcon.Error);
                Environment.Exit(-1);
            }

            string path = File.ReadAllText(discordPath);

            if (!path.EndsWith(".exe"))
            {
                NotifyIcon.ni_notify(5000, "THS Discord Blocker Error", "Config corrupt, please run the config tool again.", ToolTipIcon.Error);
                Environment.Exit(-1);
            }

            if (path.Contains("Canary"))
            {
                MessageBox.Show("Canary detected");
                Process.Start(path, "--processStart DiscordCanary.exe");
            }
            else
            {
                Process.Start(path, "--processStart Discord.exe");
            }
        }

        public static bool killDiscord(bool canary)
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName == "Discord")
                {
                    proc.Kill();

                }
                else if (proc.ProcessName == "DiscordCanary")
                {
                    proc.Kill();
                }
            }
            List<Process> procs = new List<Process>();
            foreach (Process proc in Process.GetProcesses())
            {
                procs.Add(proc);
            }
            bool discordLeft;
            foreach (Process proc in procs)
            {
                if (proc.ProcessName == "DiscordCanary" || proc.ProcessName == "Discord")
                {
                    discordLeft = true;
                    NotifyIcon.ni_notify(5000, "THS Discord Blocker Error", "We attempted to close Discord but the attempt failed. Oops.", ToolTipIcon.Error);
                    return false;
                }
            //NotifyIcon.ni_notify(5000, "Discord process killed", "We killed Discord BOIIIII", ToolTipIcon.Info);
            }
            return true;

            //    if (canary)
            //    {
            //        try
            //        {
            //            Process[] proc = Process.GetProcessesByName("DiscordCanary.exe");
            //            proc[0].Kill();
            //            return true;
            //        }
            //        catch (Exception ex)
            //        {
            //            NotifyIcon.ni_notify(5000, "THS Discord Blocker Error", "We attempted to close Discord but the attempt failed. Oops.", ToolTipIcon.Error);
            //            MessageBox.Show(ex.Message);
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        try
            //        {
            //            Process[] proc = Process.GetProcessesByName("Discord.exe");
            //            proc[0].Kill();
            //            return true;
            //        }
            //        catch (Exception ex)
            //        {
            //            NotifyIcon.ni_notify(5000, "THS Discord Blocker Error", "We attempted to close Discord but the attempt failed. Oops.", ToolTipIcon.Error);
            //            MessageBox.Show(ex.Message);
            //            return false;
            //        }
            //    }
            //}
        }
    }
}
