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

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateTotalMemoryInfo();
        }
        async void UpdateTotalMemoryInfo()
        {
            while (true)
            {
                TB_2.Text = GC.GetTotalMemory(true).ToString();
                await Task.Delay(500);
            }
        }
        async void CreateObjectsAsync(int objectCount)
        {
            List<object> objectsList = new List<object>();
            for (int i = 0; i < objectCount; i++)
            {
                objectsList.Add(new object());
                await Task.Delay(1000);
            }
            TB_1.Text = $"Create {objectsList.Count()}objects";
        }
        private void Button250_Click(object sender, RoutedEventArgs e)
        {
            Button250.IsEnabled = false;
            CreateObjectsAsync(250);
            Button250.IsEnabled = true;
        }

        private void Button400_Click(object sender, RoutedEventArgs e)
        {
            Button400.IsEnabled = false;
            CreateObjectsAsync(400);
            Button400.IsEnabled = true;
        }

        private void Button1000_Click(object sender, RoutedEventArgs e)
        {
            Button1000.IsEnabled = false;
            CreateObjectsAsync(1000);
            Button1000.IsEnabled = true;
        }
    }
}
