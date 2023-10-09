using Projekt_Abschluss.Repositories;
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

namespace Projekt_Abschluss.Views
{
    
    public partial class ClientsListView : UserControl
    {
        public ClientsListView()
        {
            InitializeComponent();
            GetAllClients();
        }

        private async void GetAllClients()
        {
            ClientRepository clientRepository = new ClientRepository();
            var clients = await clientRepository.GetAllAsync();
            DatagridClients.ItemsSource = clients;
        }

        private void CreateClientButton_Click(object sender, RoutedEventArgs e)
        {

            Window window = new Window
            {
                Title = "Create new Client",
                Content = new CreateClientView()
            };

            window.ShowDialog();
            GetAllClients();

        }

        
    }
}
