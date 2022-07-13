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
using Hotel.UI;
using Hotel.DBUtils;
namespace Hotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ReservationWindow reservationWindow;
        ClientWindow clientWindow;
        RoomWindow roomWindow;

        /// <summary>
        /// Constructor of MainWindow Class
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        public override void EndInit()
        {
            base.EndInit();
        }
        private void ReservationButton_Click(object sender, RoutedEventArgs e)
        {
            reservationWindow = new ReservationWindow();
            reservationWindow.ShowDialog();
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            clientWindow = new ClientWindow();
            clientWindow.ShowDialog();
        }

        private void RoomButton_Click(object sender, RoutedEventArgs e)
        {
            roomWindow = new RoomWindow();
            roomWindow.ShowDialog();
        }
    }
}
