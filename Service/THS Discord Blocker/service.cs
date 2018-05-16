///
/// THS Discord Blocker
/// Written by Liesel Downes
/// Licensed under the MIT License
/// 

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
    class Service
    {

        //Paths
        /*Service AppData*/ public static string AppdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\THSDiscordBlocker";
        /*Service Config (In appdata)*/ public static string ConfigPath = AppdataFolder + @"\path.cfg";

        public static void ServiceInit()
        {
            Logger.Log("Service started.");
            //Get SSID(s)
            WlanClient wlan = new WlanClient();
            Collection<String> connectedSsiDs = new Collection<string>();  
            foreach (WlanClient.WlanInterface wlanInterface in wlan.Interfaces)
            {
                Wlan.Dot11Ssid ssid = wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
                connectedSsiDs.Add(new String(Encoding.ASCII.GetChars(ssid.SSID, 0, (int)ssid.SSIDLength)));
            }

            Logger.Log("SSIDS found below:");
            foreach (string ssid in connectedSsiDs)
            {
                Logger.Log(ssid);
            }

            //Detect if connected to Heights network
            if (connectedSsiDs.Contains("THS-Students") || connectedSsiDs.Contains("THS-Secure") || connectedSsiDs.Contains("Achilleus"))
            {
                //Notify Discord will not open and quit service
                Logger.Log("Network found!");
                KillDiscord();
                NotifyIcon.NotifyIconNotify(5000, "Heights Network Detected", "Discord will not open.", ToolTipIcon.Info);
                Environment.Exit(-1);
            }
            else 
            {
                Logger.Log("No network found.");
                //Open Discord and quit service
                OpenDiscord();
                Environment.Exit(-1);
            }
        }

        public static void OpenDiscord()
        {
            //Check if config doesn't exist
            if (!File.Exists(ConfigPath))
            {
                NotifyIcon.NotifyIconNotify(5000, "THS Discord Blocker Error", "Config corrupt, please run the config tool again.", ToolTipIcon.Error);
                Environment.Exit(-1);
            }

            //Read config and get path
            string path = File.ReadAllText(ConfigPath);

            //Check if someone didn't select an executable
            if (!path.EndsWith(".exe"))
            {
                NotifyIcon.NotifyIconNotify(5000, "THS Discord Blocker Error", "Config corrupt, please run the config tool again.", ToolTipIcon.Error);
                Environment.Exit(-1);
            }

            //Check whether Canary is installed or not
            if (path.Contains("Canary"))
            { 
                //Start it
                Process.Start(path, "--processStart DiscordCanary.exe");
                Logger.Log("Discord Canary start from " + path);
            }
            else
            {
                //Start it
                Process.Start(path, "--processStart Discord.exe");
                Logger.Log("Discord start from " + path);
            }
        }

        public static void KillDiscord()
        {
            try
            {
                //Get processes
                foreach (Process proc in Process.GetProcesses())
                {
                    //Check if canary or normal
                    if (proc.ProcessName == "Discord")
                    {
                        proc.Kill();
                        Logger.Log("Discord Killed " + proc);

                    }
                    else if (proc.ProcessName == "DiscordCanary")
                    {
                        proc.Kill();
                        Logger.Log("Discord Killed " + proc);
                    }
                }
            }
            catch (InvalidOperationException ioe)
            {
                //Notify user of error
                NotifyIcon.NotifyIconNotify(5000, "THS Discord Blocker Error", "Error while killing Discord. Error info has been logged.", ToolTipIcon.Error);
                Logger.Log(ioe.Message + " " + ioe.HelpLink);
            }
            catch (NotSupportedException ise)
            {
                //Notify user of error
                NotifyIcon.NotifyIconNotify(5000, "THS Discord Blocker Error", "Error while killing Discord. Error info has been logged.", ToolTipIcon.Error);
                Logger.Log(ise.Message + " " + ise.HelpLink);
            }
            catch (Exception ex)
            {
                //Notify user of error
                NotifyIcon.NotifyIconNotify(5000, "THS Discord Blocker Error", "Error while killing Discord. Error info has been logged.", ToolTipIcon.Error);
                Logger.Log(ex.Message + " " + ex.HelpLink);
            }
        }
    }
}
