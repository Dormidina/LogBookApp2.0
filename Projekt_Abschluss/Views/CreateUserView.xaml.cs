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
    
    public partial class CreateUserView : UserControl
    {
        public CreateUserView()
        {
            InitializeComponent();
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            UserModel userModel = new UserModel
            {
                Name = UserName.Text,
                Password = UserPassword.Password
            };

            UserRepository userRepository = new UserRepository();
            var created = await userRepository.CreateAsync(userModel);

            if (created)
            {
                MessageBox.Show("User Created succesfully");
            }
            else
            {
                MessageBox.Show("Error creating User");
            }

            CancelButton_Click(sender, e);

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }
    }
}
