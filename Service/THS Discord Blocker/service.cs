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
        public static void serviceInit()
        {
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
                MessageBox.Show("Heights network detected");
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
            string AppdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\THSDiscordBlocker";
            string discordPath = AppdataFolder + @"\path.cfg";
            
            if (!File.Exists(discordPath))
            {
                MessageBox.Show("Config corrupt, run config tool again");
                Environment.Exit(-1);
            }

            string path = File.ReadAllText(discordPath);

            if (!path.EndsWith(".exe"))
            {
                MessageBox.Show("Not an executable file");
                Environment.Exit(-1);
            }

            Process.Start(path, "--processStart Discord.exe");
        }
    }
}

