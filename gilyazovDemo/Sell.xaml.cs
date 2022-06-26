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
    /// Логика взаимодействия для Sell.xaml
    /// </summary>
    public partial class Sell : Window
    {
        Window _window;
        public Sell(Window window)
        {
            InitializeComponent();
            RefreashGrid();
            _window = window;
        }

        private void QRBtn_Click(object sender, RoutedEventArgs e)
        {
            QrCode qr = new QrCode((sender as Button).DataContext as Order, _window);
            qr.Show();
            this.Close();
        }

        private void StatusBtn_Click(object sender, RoutedEventArgs e)
        {
            Order order = (sender as Button).DataContext as Order;
            OrderStatusChange OSC = new OrderStatusChange(order, _window);
            OSC.Show();
            this.Close();
        }

        private void RefreashGrid()
        {
            using (SkiResortEntities db = new SkiResortEntities())
            {
                OrdersGrid.ItemsSource = db.Orders.ToList();
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _window.Show();
            this.Close();
        }
    }
}
