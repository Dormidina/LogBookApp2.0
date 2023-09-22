using Projekt_Abschluss.Models;
using Projekt_Abschluss.Repositories;
using System.Windows;
using System.Windows.Controls;

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
            var existsUser = await userRepository.ExistsAsync(userModel);
            if (existsUser)
            {
                MessageBox.Show("User Already Exists");
            }
            else
            {
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
            

            

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }
    }
}
