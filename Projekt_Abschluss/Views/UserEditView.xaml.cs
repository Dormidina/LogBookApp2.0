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
    
    public partial class UserEditView : UserControl
    {
        private UserDataGridModel user;
        public UserEditView(UserDataGridModel user)
        {
            InitializeComponent();
            this.user = user;
            UserName.Text = user.Name;
            AdminCheck.IsChecked = user.IsAdmin;
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            UserCreateUpdateModel userModel = new UserCreateUpdateModel
            {
                Name = UserName.Text,                
                IsAdmin = AdminCheck.IsChecked.GetValueOrDefault(false)
            };



            UserRepository userRepository = new UserRepository();
            var updated = await userRepository.UpdateAsync(userModel);

            if (updated)
            {

                MessageBox.Show("User Update successfully");
                
            }
            else
            {
                MessageBox.Show("Error Updating User");
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
