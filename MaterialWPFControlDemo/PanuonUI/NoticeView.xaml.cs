using Panuon.UI.Silver;
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

namespace PanuonUI
{
    /// <summary>
    /// NoticeView.xaml 的交互逻辑
    /// </summary>
    public partial class NoticeView : UserControl
    {
        #region Identity
        private string _message = "This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.";
        private string _message2 = "This is a test message.";
        #endregion

        public NoticeView()
        {
            InitializeComponent();
        }

        private void BtnNonIcon_Click(object sender, RoutedEventArgs e)
        {
            Notice.Show("This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.", "Notice", 3);
        }

        private void BtnError_Click(object sender, RoutedEventArgs e)
        {
            Notice.Show("This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.", "Notice", 3, MessageBoxIcon.Error);
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            Notice.Show("This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.", "Notice", 3, MessageBoxIcon.Info);

        }

        private void BtnSuccess_Click(object sender, RoutedEventArgs e)
        {
            Notice.Show("This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.", "Notice", 3, MessageBoxIcon.Success);
        }

        private void BtnWarning_Click(object sender, RoutedEventArgs e)
        {
            Notice.Show("This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.", "Notice", 3, MessageBoxIcon.Warning);
        }
    }
}
