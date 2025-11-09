using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

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
            Loaded += MainWindow_Loaded;
            Closed += MainWindow_Closed;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string path = "configFile";
            if (File.Exists(path) && !IsFileEmpty(path))
                LinkBox.Text = File.ReadAllText(path);
        }

        private bool IsFileEmpty(string path)
        {
            FileInfo file = new FileInfo(path);
            return file.Length == 0;
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

        private void SaveLink(string link)
        {
            string path = "configFile";
            if (!File.Exists(path) || File.ReadAllText(path) != link)
            {
                File.WriteAllText(path, link);
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
    }
}

    //Здесь зарыта кость samSayona
    // .-.                .-.
    //(   `-._________. -'   )
    //     >= _______ =<
    //(   , -'`       `'-,   )
    // `-'                `-'