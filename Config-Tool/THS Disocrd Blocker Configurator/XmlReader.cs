using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
namespace THS_Disocrd_Blocker_Configurator
{
    class XmlReader
    {
        public static Return ReadXml()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(FileHandler.SettingsFile);
            XmlNode enabledNode = xdoc.DocumentElement.SelectSingleNode("/ths-discord-blocker/enabled");
            string enabled = enabledNode.InnerText;
            XmlNode pathNode = xdoc.DocumentElement.SelectSingleNode("/ths-discord-blocker/path");
            string path = pathNode.InnerText;
            if (enabled == "true")
            {
                Return r = new Return();
                r.enabled = true;
                r.path = path;
                return r;
            }
            else
            {
                Return r = new Return();
                r.enabled = false;
                r.path = path;
                return r;
            }
        }

        public class Return
        {
            public bool enabled { get; set; }
            public string path { get; set; }
        }
    }
}
