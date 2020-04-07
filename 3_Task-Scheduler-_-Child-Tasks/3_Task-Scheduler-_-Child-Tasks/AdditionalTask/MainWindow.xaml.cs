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
            this.IsEnabled = false;
            int k = int.Parse(txtResult1.Text); 
            Task.Factory.StartNew(() => FindLastFibonacciNumber(k),TaskCreationOptions.LongRunning)
                .ContinueWith(t =>
                {
                    txtResult2.Text = t.Result.ToString();
                    this.IsEnabled = true;
                }, TaskScheduler.FromCurrentSynchronizationContext()); 
        }

        private static double FindLastFibonacciNumber(int number)
        {
            Func<int, double> fib = null;
            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;
            return fib.Invoke(number);

        }
    }
}
