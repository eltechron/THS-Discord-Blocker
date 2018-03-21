using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.IO;
using Microsoft.Win32;

namespace THS_Discord_Blocker_Configurator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string AppdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\THSDiscordBlocker";
        public static string discordPath = AppdataFolder + @"\path.cfg";

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(discordPath))
            {
                string path = File.ReadAllText(discordPath);
                discordPathB.Text = path;
            }
            else
            {
                discordPathB.Text = "Not set";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string givenPath = string.Empty;
            if (ofd.ShowDialog() == true)
            {
                givenPath = ofd.FileName;
            }
            if (!givenPath.EndsWith(".exe"))
            {
                MessageBox.Show("Not an executable file.");
                return;
            }
            try
            {
                Directory.CreateDirectory(AppdataFolder);
                File.WriteAllText(discordPath, givenPath);
                discordPathB.Text = givenPath;
            }
            catch (IOException ie)
            {
                MessageBox.Show("There was an error saving the config. " + ie.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Discord";
            string appdataC = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\DiscordCanary";
            if (Directory.Exists(appdataC))
            {
                if (File.Exists("Update.exe"))
                {
                    System.Diagnostics.Process.Start("Update.exe --processStart DiscordCanary.exe");
                }
            }
            else if (Directory.Exists(appdata))
            {

            }
            else
            {
                MessageBox.Show("Discord could not be found.");
            }
        }
    }
}
