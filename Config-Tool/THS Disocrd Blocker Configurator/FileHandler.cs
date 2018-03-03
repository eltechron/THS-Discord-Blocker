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
        public static string EnabledFile = AppdataFolder + @"\enabled.cfg";
        public static string PathFile = AppdataFolder + @"\path.cfg";

        public static bool CreateFolder()
        {
            Directory.CreateDirectory(AppdataFolder);
            File.Create(EnabledFile);
            File.Create(PathFile);
            return true;
        }

        public static bool SaveConfigEnabled(bool input)
        {
            if (input)
            {
                File.WriteAllText(EnabledFile, "true");
            }
            else
            {
                File.WriteAllText(EnabledFile, "false");
            }
            return true;
        }

        public static bool SaveConfigPath(string input)
        {
            if (!File.Exists(input))
            {
                MessageBox.Show("File doesn't exist (" + input + ")");
                return false;
            }
            else if (!input.EndsWith(".exe"))
            {
                MessageBox.Show("Not an executable file");
                return false;
            }
            File.WriteAllText(PathFile, input);
            return true;
        }
    }
}
