using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace MaterialWPFControlDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Button信息
        /// </summary>
        public class BtnInfo : ViewModelBase
        {
            private double _value = 0;
            public double value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                    OnPropertyChanged("value");
                }
            }
        }
        public BtnInfo btnInfo { get; set; }

        public class TextInfo : ViewModelBase
        {
            private string _name;
            public string name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                    OnPropertyChanged("name");
                }
            }
        }

        public TextInfo textInfo { get; set; }


        public class MusinInfo
        {
            public string title { get; set; }
        }

        public List<MusinInfo> musinInfos { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            btnInfo = new BtnInfo();
            textInfo = new TextInfo();
            musinInfos = new List<MusinInfo>();
            for (int i = 1; i < 1000; i++)
            {
                MusinInfo musinInfo = new MusinInfo();
                musinInfo.title = i.ToString();
                musinInfos.Add(musinInfo);
            }
            this.DataContext = this;
        }
       
        public string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }
        public byte[] hexToBytes(String src)
        {
            int l = src.Length / 2;
            String str;
            byte[] ret = new byte[l];

            for (int i = 0; i < l; i++)
            {
                str = src.Substring(i * 2, 2);
                ret[i] = Convert.ToByte(str, 16);
            }
            return ret;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (btnInfo.value < 100)
            {
                btnInfo.value += 10;
            }
            else
            {
                btnInfo.value = 0;
            }
        }

        private void SnackbarMessage_ActionClick(object sender, RoutedEventArgs e)
        {
            SnackbarUnsavedChanges.IsActive = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void BtnChangeSave_Click(object sender, RoutedEventArgs e)
        {
            SnackbarUnsavedChanges.IsActive = true;
        }

        private void BtnDialogHost_Click(object sender, RoutedEventArgs e)
        {
            DialogHost.IsOpen = true;
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            materialDrawerHost.IsLeftDrawerOpen = true;
        }

        private void BtnLocationExit_Click(object sender, RoutedEventArgs e)
        {
            materialDrawerHost.IsLeftDrawerOpen = false;
        }
    }
}
