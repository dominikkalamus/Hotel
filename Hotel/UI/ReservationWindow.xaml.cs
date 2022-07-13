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
using System.Diagnostics;
using Hotel.DBUtils;
using Hotel.DataModels;
using Microsoft.EntityFrameworkCore;
namespace Hotel.UI
{
    /// <summary>
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    public partial class ReservationWindow : Window
    {
        HotelDbContext hotelDbContext;
        List<ReservationModel> reservationModels;
        Reservation selectedReservation;

        /// <summary>
        /// Constructor of ReservationWindow Class
        /// </summary>
        public ReservationWindow()
        {
            InitializeComponent();
            hotelDbContext = new HotelDbContext();
            UpdateDataSource();
            SetComboBoxes();

        }

        private void UpdateDataSource()
        {
            List<Reservation> reservations = hotelDbContext.Reservations.ToList();
            reservationModels = new List<ReservationModel>();
            foreach (var r in reservations)
            {
                SetReservationModel(r);
            }
            ReservationDataGrid.ItemsSource = reservationModels;
        }

        void SetComboBoxes()
        {
            DaysComboBox.ItemsSource = GenerateDaysList(1, 30);
            AddsComboBox.ItemsSource = hotelDbContext.Adds.ToList();
            ClientComboBox.ItemsSource = hotelDbContext.Clients.ToList();
            RoomComboBox.ItemsSource = hotelDbContext.Rooms.ToList();
            BoardingComboBox.ItemsSource = hotelDbContext.Boardings.ToList();
        }

        private void ReservationDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReservationDataGrid.SelectedItem!=null)
            {
                ReservationModel reservationModel = ReservationDataGrid.SelectedItem as ReservationModel;
                if (reservationModel != null && reservationModel.ReservationId > 0)
                {
                    selectedReservation = hotelDbContext.Reservations.Where(e => e.ReservationId == reservationModel.ReservationId).First();
                    Client client = hotelDbContext.Clients.Where(e => e.ClientId == selectedReservation.ClientId).Single();
                    ClientComboBox.SelectedItem = client;
                    Room room = hotelDbContext.Rooms.Where(e => e.RoomId == selectedReservation.RoomId).Single();
                    RoomComboBox.SelectedItem = room;
                    Boarding boarding = hotelDbContext.Boardings.Where(e => e.BoardingId == selectedReservation.BoardingId).Single();
                    BoardingComboBox.SelectedItem = boarding;
                    Add add = hotelDbContext.Adds.Where(e => e.AddId == selectedReservation.AddId).Single();
                    AddsComboBox.SelectedItem = add;
                    DatePicker.SelectedDate = selectedReservation.Date;
                    DaysComboBox.SelectedItem = selectedReservation.Days;
                }
            }
        }

        private List<int> GenerateDaysList(int begin, int end)
        {
            List<int> days = new List<int>();
            for (int i=begin;i<=end;i++)
            {
                days.Add(i);
            }
            return days;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedReservation!=null)
            {
                hotelDbContext.Remove(selectedReservation);
                hotelDbContext.SaveChanges();
                UpdateDataSource();
                selectedReservation = null;

            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValues())
            {
                if (CheckDate())
                {
                    Reservation reservation = CreateReservation();
                    hotelDbContext.Add(reservation);
                    hotelDbContext.SaveChanges();
                    UpdateDataSource();
                }
                else
                {
                    MessageBox.Show("Data nie może być wcześniejsza niż dzień dzisiejszy","Zła data");
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano wszystkich danych, koniecznych do rezerwacji", "Brakujące dane");
            }
        }

        private bool CheckValues()
        {
            if (ClientComboBox.SelectedItem!=null &&
                RoomComboBox.SelectedItem!=null &&
                BoardingComboBox.SelectedItem!=null && 
                AddsComboBox.SelectedItem!=null &&
                DatePicker.SelectedDate!=null &&
                DaysComboBox.SelectedItem!=null)
            {
                return true;
            }
            return false;
        }

        private bool CheckDate()
        {
            DateOnly date = new DateOnly();
            DateOnly dateFromCombo = new DateOnly(DatePicker.SelectedDate.Value.Year, DatePicker.SelectedDate.Value.Month, DatePicker.SelectedDate.Value.Day);
            if (date <= dateFromCombo)
            {
                return true;
            }
            return false;
        }

        private void SetReservationModel(Reservation r)
        {
            ReservationModel reservationModel = new ReservationModel();
            Add add = hotelDbContext.Adds.Where(e => e.AddId == r.AddId).Single();
            Room room = hotelDbContext.Rooms.Where(e => e.RoomId == r.RoomId).Single();
            Boarding boarding = hotelDbContext.Boardings.Where(e => e.BoardingId == r.BoardingId).Single();
            Client client = hotelDbContext.Clients.Where(e => e.ClientId == r.ClientId).Single();
            reservationModel.ReservationId = r.ReservationId;
            reservationModel.ReservationDate = r.Date;
            reservationModel.ReservationDays = r.Days;
            reservationModel.ClientId = r.ClientId;
            reservationModel.RoomId = r.RoomId;
            reservationModel.AddId = r.AddId;
            reservationModel.BoardingId = r.BoardingId;
            reservationModel.FirstName = client.FirstName;
            reservationModel.LastName = client.LastName;
            reservationModel.PhoneNumber = client.PhoneNumber;
            reservationModel.IdNumber = client.IdNumber;
            reservationModel.RoomNumber = room.RoomNumber;
            reservationModel.RoomPrice = room.RoomPrice;
            reservationModel.AddName = add.AddName;
            reservationModel.AddPrice = add.AddPrice;
            reservationModel.BoardingName = boarding.BoardingName;
            reservationModel.BoardingPrice = boarding.BoardingPrice;
            reservationModel.Price = reservationModel.ReservationDays * (reservationModel.RoomPrice + reservationModel.BoardingPrice + reservationModel.AddPrice);
            reservationModels.Add(reservationModel);
        }

        private Reservation CreateReservation()
        {
            Reservation reservation = new Reservation();
            reservation.ClientId = ((Client)ClientComboBox.SelectedItem).ClientId;
            reservation.AddId = ((Add)AddsComboBox.SelectedItem).AddId;
            reservation.BoardingId = ((Boarding)BoardingComboBox.SelectedItem).BoardingId;
            reservation.RoomId = ((Room)RoomComboBox.SelectedItem).RoomId;
            reservation.Date = (DateTime)DatePicker.SelectedDate;
            reservation.Days = (int)DaysComboBox.SelectedItem;
            return reservation;
        }
    }
}
