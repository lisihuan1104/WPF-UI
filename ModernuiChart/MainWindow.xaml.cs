using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ModernuiChart
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        public class MainViewModel
        {
            private readonly ObservableCollection<Population> _populations = new ObservableCollection<Population>();
            public ObservableCollection<Population> Populations
            {
                get
                {
                    return _populations;
                }
            }

            public MainViewModel()
            {
                _populations.Add(new Population() { Name = "China", Count = 1340 });
                _populations.Add(new Population() { Name = "India", Count = 1220 });
                _populations.Add(new Population() { Name = "United States", Count = 309 });
                _populations.Add(new Population() { Name = "Indonesia", Count = 240 });
                _populations.Add(new Population() { Name = "Brazil", Count = 195 });
                _populations.Add(new Population() { Name = "Pakistan", Count = 174 });
                _populations.Add(new Population() { Name = "Nigeria", Count = 158 });
            }
        }
        public class Population : INotifyPropertyChanged
        {
            private string _name = string.Empty;
            private int _count = 0;

            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }

            public int Count
            {
                get
                {
                    return _count;
                }
                set
                {
                    _count = value;
                    NotifyPropertyChanged("Count");
                }

            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
                }
            }
        }
    }
}
