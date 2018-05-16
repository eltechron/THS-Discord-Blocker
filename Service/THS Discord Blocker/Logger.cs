///
/// THS Discord Blocker
/// Written by Liesel Downes
/// Licensed under the MIT License
/// 

using System;
using System.IO;

namespace THS_Discord_Blocker
{
    public class Logger
    {
        //Paths
        /*Service AppData*/ public static string AppdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\THSDiscordBlocker";
        /*Service Log (In appdata)*/ public static string LogPath = AppdataFolder + @"\thsblocker.log";

        public static void Log(string Input)
        {
            using (FileStream Writer = new FileStream(LogPath, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter Stream = new StreamWriter(Writer))
                {
                    string LogLine = string.Format("TIME {0}: {1}",
                        DateTime.Now.ToLongTimeString() + DateTime.Now.ToLongDateString(), Input);
                    Stream.WriteLine(LogLine);
                }
            }
        }
    }
}