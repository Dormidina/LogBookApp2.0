using Projekt_Abschluss.Models;
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
    public partial class CreateClientView : UserControl
    {
        public CreateClientView()
        {
            InitializeComponent();
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientModel model = new ClientModel
                {
                    Name = ClientName.Text,
                    LastName = ClientLastName.Text,
                    Adresse = ClientAdresse.Text,
                    Telephone = ClientTelephone.Text,
                    ZipCode = ClientZipCode.Text
                };

                ClientRepository clientRepository = new ClientRepository();
                var created = await clientRepository.CreateAsync(model);
                if (created)
                {
                    MessageBox.Show("Client created sucessfully");
                    CancelButton_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error creating Client");
                }


            }
            catch
            {
                MessageBox.Show("Error creating Client");
            }
            
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }

        
    }
}
