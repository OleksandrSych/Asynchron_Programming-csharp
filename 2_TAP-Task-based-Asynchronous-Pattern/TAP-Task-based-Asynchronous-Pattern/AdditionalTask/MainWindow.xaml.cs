using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AdditionalTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            DispleyStars();
        }
        private void DispleyStars()
        {
            Task.Run(() =>
            {
                Dispatcher.Invoke(() => {
                    txtResult.Text = string.Empty;
                    btnStart.IsEnabled = false;
                    });
                for (int i = 0; i < 100; i++)
                {
                    Dispatcher.Invoke(() => txtResult.Text += '*');
                    Thread.Sleep(300);
                }
                Dispatcher.Invoke(() => btnStart.IsEnabled = true);
            });
        }
    }
}
