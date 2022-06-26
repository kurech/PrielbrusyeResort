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
using System.Windows.Shapes;

namespace gilyazovDemo
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        bool canclose = false;

        public int resultCaptcha = 0;

        public int firstNum = 0;
        public int secondNum = 0;

        public string res = "";
        public Captcha()
        {
            InitializeComponent();
            UpdateCapcha();
        }

        public void CheckCapcha()
        {
            resultCaptcha = firstNum + secondNum;
            if (int.Parse(txtResult.Text) == resultCaptcha)
            {
                canclose = true;
                this.Close();
                UpdateCapcha();
            }
            else
            {
                MessageBox.Show("Неверно!");
                UpdateCapcha();
            }
        }

        public void UpdateCapcha()
        {
            txtCapcha.Clear();
            txtResult.Clear();
            Random rnd = new Random();
            firstNum = rnd.Next(1, 9);
            secondNum = rnd.Next(1, 9);
            txtCapcha.Text += firstNum.ToString() + "+" + secondNum.ToString() + "=";
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            CheckCapcha();
        }

        private void Window_Closed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!canclose) e.Cancel = true;
        }
    }
}
