using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace UIBrowser
{
    public class App : Application
    {
        #region WindowsAPI
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int WS_SHOWNORMAL = 1;
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        #endregion

        #region 全局变量

        #endregion

        [STAThread]
        public static void Main(string[] args)
        {
          
            App app = new App();
            try
            {
                bool ret = false;
                System.Threading.Mutex mutex = new System.Threading.Mutex(true, System.Windows.Forms.Application.ProductName, out ret);
                if (ret)
                {
                    app.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    {
                        Source = new Uri("pack://application:,,,/Panuon.UI.Silver;component/Control.xaml", UriKind.Absolute)
                    });
                    app.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    {
                        Source = new Uri("pack://application:,,,/UIBrowser;component/Resources/Styles.xaml", UriKind.Absolute)
                    });
                    MainWindow mainWindow = new MainWindow();
                    app.Run(mainWindow);
                }
                else
                {
                    var result = MessageBoxX.Show("系统已经在运行", "警告", Application.Current.MainWindow, MessageBoxButton.OK, new MessageBoxXConfigurations()
                    {
                        MessageBoxIcon = MessageBoxIcon.Warning,
                        ButtonBrush = "#F1C825".ToColor().ToBrush(),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            SetForegroundWindow(instance.MainWindowHandle);
        }
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }
            return null;
        }
        public App()
        {
            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }
        //全局捕获错误（UI线程）
        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                Console.WriteLine(e.Exception.Message);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // 全局捕获错误（非UI线程）
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                if (e.ExceptionObject is System.Exception)
                {
                    Console.WriteLine(e.ExceptionObject.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
    }
}
