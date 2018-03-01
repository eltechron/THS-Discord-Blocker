using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;
namespace THS_Disocrd_Blocker_Configurator
{
    class FileHandler
    {
        public static string AppdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\THSDiscordBlocker";
        public static string SettingsFile = AppdataFolder + @"\config.xml";

        public static bool CreateFolder()
        {
            Directory.CreateDirectory(AppdataFolder);
            File.Create(SettingsFile);
            return true;
        }

        public static bool SaveConfig(bool enabled, string discord)
        {
            XmlDocument xdoc = new XmlDocument();
            if (!File.Exists(discord))
            {
                MessageBox.Show("Discord file not valid");
                return false;
            }
            string contents;
            if (enabled)
            {
                contents = @"<ths-discord-config>
                            <enabled>true</enabled>
                            <path>" + discord + @"</path>
                            </ths-discord-config>";
            }
            else
            {
                contents = @"<ths-discord-config>
                            <enabled>false</enabled>
                            <path>" + discord + @"</path>
                            </ths-discord-config>";
            }
            xdoc.LoadXml(contents);
            xdoc.Save(SettingsFile);
            return true;
        }
    }
}
