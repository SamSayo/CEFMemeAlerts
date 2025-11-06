using CefSharp;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace CEFMemeAlerts
{
    /// <summary>
    /// Interaction logic for MemeAlertsWindow.xaml
    /// </summary>
    public partial class MemeAlertsWindow : Window
    {
        public MemeAlertsWindow()
        {
            InitializeComponent();
            this.Loaded += MemeAlertsWindow_Loaded;
            //Browser.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;
        }

        private void OnIsBrowserInitializedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var browser = (IWebBrowser)sender;
            if (browser.IsBrowserInitialized)
            {
                // Открывает DevTools в отдельном окне (включая Console)
                browser.ShowDevTools();
            }
        }
        
        //Нажатие сквозь окна
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TRANSPARENT = 0x00000020;
        private const int WS_EX_LAYERED = 0x00080000;

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        private void MemeAlertsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT | WS_EX_LAYERED);
        }
    }
}
