using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace CEFMemeAlerts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MemeAlertsWindow maw = new MemeAlertsWindow();

        public MainWindow()
        {
            InitializeComponent();
            Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            maw.Close();
        }

        private void StartClick_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(LinkBox.Text.ToString(), @"^https:\/\/memealerts\.com\/r\/.*"))
            {
                SaveLink(LinkBox.Text.ToString());
                maw.Browser.Address = LinkBox.Text;
                maw.Show();
                StartButton.IsEnabled = false;
                StopButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Ссылка не верна или отсутствует", "Ссылка не верна", MessageBoxButton.OK, MessageBoxImage.Error);
                LinkBox.Text = string.Empty;
            }
        }

        private void StopClick_Click(object sender, RoutedEventArgs e)
        {
            maw.Browser.Address = "about:blank";
            maw.Hide();   
            StopButton.IsEnabled = false;
            StartButton.IsEnabled = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void SaveLink(string link)
        {
            string path = "configFile";
            if (!File.Exists(path) || File.ReadAllText(path) != link)
            {
                File.WriteAllText(path, link);
            }
        }
    }
}

    //Здесь зарыта кость samSayona
    // .-.                .-.
    //(   `-._________. -'   )
    //     >= _______ =<
    //(   , -'`       `'-,   )
    // `-'                `-'