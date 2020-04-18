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
        private CancellationTokenSource cts;
        private IProgress<int> progress;
        public MainWindow()
        {
            InitializeComponent();
            this.cts = new CancellationTokenSource();
            this.progress = new Progress<int>(UpdateProgressBar);
        }
        private async void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(TB_number.Text, out int num);
            TB_result.Clear();
            if (num < 1)
                return;

            this.ButtonStart.IsEnabled = false;
            this.ProgressBar1.Visibility = Visibility.Visible;
            try
            { 
                    int requestResults = await FactorialAsync(num, this.cts.Token, this.progress); 
                    this.TB_result.Text = requestResults.ToString(); 
            }
            catch (OperationCanceledException ex)
            { 
                this.TB_result.Text = "Вы отменили выполнение операции. Попробуйте еще раз..";
            }
            catch (Exception ex)
            { 
                this.TB_result.Text = $"Произошла ошибка \"{ex.GetType()}\". Сообщение: \"{ex.Message}\"{Environment.NewLine}"; 
            }
            finally
            {
                this.ButtonStart.IsEnabled = true;
                this.ProgressBar1.Value = 0;
                this.ProgressBar1.Visibility = Visibility.Hidden;
            }
        }
        private void ButtonCansel_Click(object sender, RoutedEventArgs e)
        {
            this.cts.Cancel();
            this.cts = new CancellationTokenSource();

            this.ProgressBar1.Value = 0;
            this.ProgressBar1.Visibility = Visibility.Hidden;
        }
        private void UpdateProgressBar(int value)
        {
            this.ProgressBar1.Value = value;
        }
        public async Task<int> FactorialAsync(int num, CancellationToken cancellationToken = default, IProgress<int> progress = null)
        {
            cancellationToken.ThrowIfCancellationRequested();
            int result = 1;
            for (int i = 1; i <= num; i++)
            {
                cancellationToken.ThrowIfCancellationRequested(); 
                result *= i;
                await Task.Delay(500);
                progress?.Report((i * 100) / num);
            }  
            return result;
        }
    }
}
