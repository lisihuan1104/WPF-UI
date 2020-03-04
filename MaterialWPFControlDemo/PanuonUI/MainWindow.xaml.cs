using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PanuonUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowX, IComponentConnector
    {
        private string _message = "This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.";
        public MainWindow()
        {
            InitializeComponent();
            imageCuter.ImageSource = GetBitmapImage("D:\\timg.jpg");
        }
        private BitmapImage GetBitmapImage(string path)
        {
            if (File.Exists(path))
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, System.IO.FileShare.ReadWrite))
                {
                    byte[] b = new byte[stream.Length];
                    stream.Read(b, 0, b.Length);
                    stream.Close();
                    stream.Dispose();
                    BitmapImage _bitmapImage = new BitmapImage();
                    _bitmapImage.BeginInit();
                    _bitmapImage.CacheOption = BitmapCacheOption.None;
                    _bitmapImage.StreamSource = new MemoryStream(b);
                    _bitmapImage.EndInit();
                    _bitmapImage.Freeze();
                    return _bitmapImage;

                }
            }
            else
            {
                return null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Notice.Show("This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.", "Notice", 3);
            //var result = MessageBoxX.Show("Infomation", "Infomation", Application.Current.MainWindow, MessageBoxButton.YesNo);
        }

        private void WindowX_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private CancellationTokenSource cancellationTokenSource;
        private void CtripHoteDataSynchrByTask()
        {
            cancellationTokenSource = new CancellationTokenSource();
            Task thread = new Task(() =>
            {
                int getDataIndex = 1;
                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    Console.WriteLine($"开始获取第 {getDataIndex} 页数据....\n");
                    Thread.Sleep(1000);
                    getDataIndex++;
                }

                if (cancellationTokenSource.IsCancellationRequested)
                {
                    Console.WriteLine($"取消同步数据\n");
                }
            });
            thread.Start();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CtripHoteDataSynchrByTask();
            //MessageBoxX.Show(ColorPicker.Text, "系统提示", this, MessageBoxButton.OK, new MessageBoxXConfigurations()
            //{
            //    ShowInTaskbar = false,
            //    OKButton="确定",
            //    ButtonBrush = "#FF3675DF".ToColor().ToBrush(),
            //});

            //var result = MessageBoxX.Show("是否裁剪？", "系统提示", this, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
            //{
            //    MessageBoxIcon = MessageBoxIcon.Warning,
            //    WindowStartupLocation=WindowStartupLocation.CenterOwner,
            //    ShowInTaskbar=false,
            //    ButtonBrush = "#FF4C4C".ToColor().ToBrush(),
            //});
            //if (result == MessageBoxResult.Yes)
            //{
            //    BitmapSource bitmap = imageCuter.GetCutImage();
            //    image.Source = bitmap;
            //}
        }

        private void ColorPicker_SelectedBrushChanged(object sender, SelectedBrushChangedEventArgs e)
        {
            grid.Background = ColorPicker.Text.ToColor().ToBrush();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
        public string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        private static void CryptographyTest()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] publicKeyBytes = rsa.ExportCspBlob(false);
            byte[] privateKeyBytes = rsa.ExportCspBlob(true);
            Console.WriteLine(Convert.ToBase64String(publicKeyBytes));
            Console.WriteLine(Convert.ToBase64String(privateKeyBytes));

        }
        public byte[] RSAEncrypt(string xmlPublicKey)
        {
            try
            {

                byte[] RadomBytes = Guid.NewGuid().ToByteArray();

                string aa = Convert.ToBase64String(RadomBytes);
                //sFD4N9pnMEmErdA3a7vY7g
                byte[] test = System.Text.Encoding.Default.GetBytes("sFD4N9pnMEmErdA3a7vY7g==");
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                RSAParameters paraPub = ConvertFromPublicKey(xmlPublicKey);
                provider.ImportParameters(paraPub);
                RadomBytes = provider.Encrypt(test, true);
                return RadomBytes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static RSAParameters ConvertFromPublicKey(string pemFileConent)
        {
 
            byte[] keyData = Convert.FromBase64String(pemFileConent);
            if (keyData.Length < 162)
            {
                throw new ArgumentException("pem file content is incorrect.");
            }
            byte[] pemModulus = new byte[128];
            byte[] pemPublicExponent = new byte[3];
            Array.Copy(keyData, 29, pemModulus, 0, 128);
            Array.Copy(keyData, 159, pemPublicExponent, 0, 3);
            RSAParameters para = new RSAParameters();
            para.Modulus = pemModulus;
            para.Exponent = pemPublicExponent;
            return para;
        }
        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string key1 = "BgIAAACkAABSU0ExAAQAAAEAAQDR9on9ukkHLsMzIYHPub7iD2+aZhGuyr6h0CNw6WjnJxBjxXENmRNQQ8E5SCY8Rvyo9nN7TP8+OSsiM1f5zCh2cSY4EsPNEHID6M4pCNq30Lz01rWN342SZtxt5m6WAl5VnFLREnUWmbaZuQyjXEh1lLR2Zm9sycGleKODAQYy6w==";

            string key2 = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCghPCWCobG8nTD24juwSVataW7iViRxcTkey/B792VZEhuHjQvA3cAJgx2Lv8GnX8NIoShZtoCg3Cx6ecs+VEPD2fBcg2L4JK7xldGpOJ3ONEAyVsLOttXZtNXvyDZRijiErQALMTorcgi79M5uVX9/jMv2Ggb2XAeZhlLD28fHwIDAQAB";
             RSAEncrypt(key2);
            //CryptographyTest();
            Console.WriteLine("FFF");
            //var handler = PendingBox.Show("请稍等...", "数据正在上传", true, Application.Current.MainWindow, new PendingBoxConfigurations()
            //{
            //    LoadingForeground = "#5DBBEC".ToColor().ToBrush(),
            //    ButtonBrush = "#5DBBEC".ToColor().ToBrush(),
            //    LoadingSize = 50,
            //    PendingBoxStyle = PendingBoxStyle.Classic,
            //    FontSize = 14,
            //});
            //handler.Cancel += delegate
            //{
            //    handler.Close();
            //};

            //await Task.Delay(2000);
            //handler.UpdateMessage("Almost complete (2/2)...");
            //await Task.Delay(2000);
            //handler.Close();
        }
    }
}
