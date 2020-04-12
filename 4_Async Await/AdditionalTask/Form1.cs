using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdditionalTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            button1.Enabled = false;
            string text;
            text = await Task<string>.Run(() => GenerateAnswer());
            text += $" Выполнено в потоке { Thread.CurrentThread.ManagedThreadId}";
            textBox_answer.Text = text;
            button1.Enabled = true;
        }

        private string GenerateAnswer()
        {
            Thread.Sleep(10000);
            return "Hellow word!";
        }
    }
}
