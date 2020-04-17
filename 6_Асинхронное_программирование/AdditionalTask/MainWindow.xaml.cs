using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        private async void Load_Click(object sender, RoutedEventArgs e)
        {
            TB_text.IsEnabled = false;
            ButtonLoad.IsEnabled = false;
            string url = "https://www.globallogic.com/";
            string txt = await (new HttpClient()).GetStringAsync(url);
            TB_text.IsEnabled = true;
            ButtonLoad.IsEnabled = true;
            TB_text.Text = txt.Trim();
        }
    }
}
