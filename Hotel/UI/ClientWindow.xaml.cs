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
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        HotelDbContext hotelDbContext;
        Client selectedClient;

        /// <summary>
        /// Constructor of ClientWindow Class
        /// </summary>
        public ClientWindow()
        {
            InitializeComponent();
            hotelDbContext = new HotelDbContext();
            UpdateItems();
        
        }

        

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectedClient();
            SetTextBoxes();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields())
            {
                Client client = PrepareNewClient();
                if (checkIdNuberUnique(client))
                {
                    hotelDbContext.Clients.Add(client);
                    hotelDbContext.SaveChanges();
                    selectedClient = client;
                    UpdateItems();
                   
                }
                else
                {
                    MessageBox.Show("Podany numer dowodu istnieje już w bazie danych", "Błąd unikalności");
                }
            }
            else
            {
                MessageBox.Show("Nie wszystkie pola zostały wypełnione","Wypełnij wszystkie pola");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClient != null)
            {
                if (CheckFields())
                {
                    UpdateTempClient();
                    try
                    {
                        hotelDbContext.Update(selectedClient);
                        hotelDbContext.SaveChanges();
                        UpdateItems();
                    }
                    catch (DbUpdateException ex)
                    {
                        MessageBox.Show("Podany numer dowodu istnieje już w bazie danych", "Błąd unikalności");
                    }

                }
                else
                {
                    MessageBox.Show("Nie wszystkie pola zostały wypełnione", "Wypełnij wszystkie pola");
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClient != null)
            {
                hotelDbContext.Clients.Remove(selectedClient);
                hotelDbContext.SaveChanges();
                UpdateItems();
            }
            else
            {
                MessageBox.Show("Nie wybrano rekordu do usuniecia", "Nie wybrano klienta");
            }
        }

        private void UpdateItems()
        {
            ClientDataGrid.ItemsSource = hotelDbContext.Clients.ToList();
        }

        private Client PrepareNewClient()
        {
            Client client = new Client();
            client.FirstName = FirstNameTextBox.Text;
            client.LastName = LastNameTextBox.Text;
            client.IdNumber = IdNumberTextBox.Text;
            client.PhoneNumber = PhoneNumberTextBox.Text;
            return client;
        }

        private void UpdateTempClient()
        {
            selectedClient.FirstName = FirstNameTextBox.Text;
            selectedClient.LastName = LastNameTextBox.Text;
            selectedClient.IdNumber = IdNumberTextBox.Text;
            selectedClient.PhoneNumber = PhoneNumberTextBox.Text;
        }

        private bool CheckFields()
        {
            if (!FirstNameTextBox.Text.Trim().Equals("") &&
                !LastNameTextBox.Text.Trim().Equals("") &&
                !IdNumberTextBox.Text.Trim().Equals("") &&
                !PhoneNumberTextBox.Text.Trim().Equals(""))
            {
                return true;
            }
            return false;
        }

        private void SetTextBoxes()
        {
            if (selectedClient != null)
            {
                FirstNameTextBox.Text = selectedClient.FirstName;
                LastNameTextBox.Text = selectedClient.LastName;
                IdNumberTextBox.Text = selectedClient.IdNumber;
                PhoneNumberTextBox.Text = selectedClient.PhoneNumber;
            }
            else
            {
                FirstNameTextBox.Text = "";
                LastNameTextBox.Text = "";
                IdNumberTextBox.Text = "";
                PhoneNumberTextBox.Text = "";
            }
        }

        private void UpdateSelectedClient()
        {
            try
            {
                selectedClient = (Client)ClientDataGrid.SelectedItem;
            }
            catch (Exception ex)
            {
                selectedClient = null;
            }
        }

        private bool checkIdNuberUnique(Client client)
        {
            foreach (var c in hotelDbContext.Clients)
            {
                if (c.IdNumber.Equals(client.IdNumber))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
