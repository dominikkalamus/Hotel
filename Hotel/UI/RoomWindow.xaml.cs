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
using Hotel.DBUtils;
using Hotel.DataModels;
using Microsoft.EntityFrameworkCore;
namespace Hotel.UI
{
    /// <summary>
    /// Interaction logic for RoomWindow.xaml
    /// </summary>
    public partial class RoomWindow : Window
    {
        HotelDbContext hotelDbContext;
        List<RoomModel> roomModels;
        RoomModel selectedRoom;

        /// <summary>
        /// Constructor of RoomWindow Class
        /// </summary>
        public RoomWindow()
        {
            InitializeComponent();
            hotelDbContext = new HotelDbContext();
            UpdateSourceModel();
            SetComboBoxData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                Room room = new Room();
                room.RoomNumber = Int32.Parse(RoomNumberTextBox.Text);
                room.RoomPrice = Double.Parse(RoomPriceTextBox.Text);
                room.RoomQualityId = ((RoomQuality)QualityComboBox.SelectedItem).RoomQualityId;
                room.RoomStatusId = ((RoomStatus)StatusComboBox.SelectedItem).StatusId;
                hotelDbContext.Rooms.Add(room);
                hotelDbContext.SaveChanges();
                UpdateSourceModel();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                if (RoomDataGrid.SelectedItem != null && selectedRoom != null)
                {
                    Room room = hotelDbContext.Rooms.Where(e => e.RoomId == selectedRoom.RoomId).Single();
                    room.RoomNumber = Int32.Parse(RoomNumberTextBox.Text);
                    room.RoomPrice = Double.Parse(RoomPriceTextBox.Text);
                    room.RoomQualityId = ((RoomQuality)QualityComboBox.SelectedItem).RoomQualityId;
                    room.RoomStatusId = ((RoomStatus)StatusComboBox.SelectedItem).StatusId;
                    hotelDbContext.Rooms.Update(room);
                    hotelDbContext.SaveChanges();
                    UpdateSourceModel();
                }
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRoom!=null)
            {
                Room room = hotelDbContext.Rooms.Where(e => e.RoomId == selectedRoom.RoomId).Single();
                hotelDbContext.Rooms.Remove(room);
                hotelDbContext.SaveChanges();
                UpdateSourceModel();
                selectedRoom = null;
            }
        }

        private void UpdateSourceModel()
        {
            roomModels = new List<RoomModel>();
            List<Room> rooms = hotelDbContext.Rooms.ToList();
            foreach (var r in rooms)
            {
                SetRoomModel(r);
            }
            RoomDataGrid.ItemsSource = roomModels;
        }

        private void SetRoomModel(Room r)
        {
            RoomModel roomModel = new RoomModel();
            roomModel.RoomId = r.RoomId;
            roomModel.RoomNumber = r.RoomNumber;
            roomModel.RoomPrice = r.RoomPrice;
            roomModel.RoomQualityId = r.RoomQualityId;
            roomModel.RoomQuatityName = hotelDbContext.RoomQualities.Where(e => e.RoomQualityId == r.RoomQualityId).Single().Quality;
            roomModel.RoomStatusId = r.RoomStatusId;
            roomModel.RoomStatusName = hotelDbContext.RoomStatuses.Where(e => e.StatusId == r.RoomStatusId).Single().Status;
            roomModels.Add(roomModel);
        }

        private void SetComboBoxData()
        {
            StatusComboBox.ItemsSource = hotelDbContext.RoomStatuses.ToList();
            QualityComboBox.ItemsSource = hotelDbContext.RoomQualities.ToList();
        }

        private bool CheckRoomNumber()
        {
            try
            {
                Int32.Parse(RoomNumberTextBox.Text);
                return true;
            }
            catch (Exception e)
            {

            }
            return false;
        }

        private bool CheckRoomPrice()
        {
            try
            {
                Double.Parse(RoomPriceTextBox.Text);
                return true;
            } catch (Exception e)
            {

            }
            return false;
        }

        private bool CheckFields()
        {
            if (RoomPriceTextBox.Text != null && !RoomPriceTextBox.Text.Trim().Equals("")
                && RoomNumberTextBox.Text != null && !RoomNumberTextBox.Text.Trim().Equals("")
                && StatusComboBox.SelectedItem != null && QualityComboBox.SelectedItem != null)
            {
                return true;
            }
            return false;
        }


        private bool ValidateFields()
        {
            if (CheckFields())
            {
                if (CheckRoomNumber())
                {
                    if (CheckRoomPrice())
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Wprowadzono nieprawidłową cenę", "Nieprawidłowa cena");
                    }
                }
                else
                {
                    MessageBox.Show("Podany numer pokoju jest nieprawidłowy", "Nieprawidłowy numer pokoju");
                }
            }
            else
            {
                MessageBox.Show("Nie wszystkie dane zostały wprowadzone", "Brak wypełnionych danych");
            }
            return false;
        }

        private void RoomDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoomDataGrid.SelectedItem != null)
            {
                selectedRoom = RoomDataGrid.SelectedItem as RoomModel;
                RoomNumberTextBox.Text = selectedRoom.RoomNumber.ToString();
                RoomPriceTextBox.Text = selectedRoom.RoomPrice.ToString();
                QualityComboBox.SelectedItem = hotelDbContext.RoomQualities.Where(e => e.RoomQualityId == selectedRoom.RoomQualityId).Single();
                StatusComboBox.SelectedItem = hotelDbContext.RoomStatuses.Where(e => e.StatusId == selectedRoom.RoomStatusId).Single();
            }
        }
    }
}
