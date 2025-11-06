using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CefSharp;
using CefSharp.Wpf;

namespace CEFMemeAlerts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Настройки CEF
            var settings = new CefSettings
            {
                // Опционально: настройте кэш, если нужен
                CachePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };
            settings.CefCommandLineArgs.Add("autoplay-policy", "no-user-gesture-required");
            // Инициализация CEF
            Cef.Initialize(settings);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            // Очистка ресурсов CEF при закрытии приложения
            Cef.Shutdown();
        }
    }
}
