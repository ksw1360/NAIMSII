using System;
using System.IO;
using System.Windows;
using DevExpress.Xpf.Core;
using NAIMS2.Common.Utils;
using log4net;

namespace NAIMS2.Operator
{
    public partial class App : Application
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(App));

        protected override void OnStartup(StartupEventArgs e)
        {
            // Log4Net 설정 로드
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            if (!File.Exists(configPath))
            {
                MessageBox.Show($"log4net.config not found at: {configPath}");
            }
            log4net.Config.XmlConfigurator.Configure(new FileInfo(configPath));

            // 로그 폴더 생성
            string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }

            Logger.Info("============= Application Started =============");

            // DevExpress 설정
            CompatibilitySettings.UseLightweightThemes = true;
            base.OnStartup(e);
        }
    }
}