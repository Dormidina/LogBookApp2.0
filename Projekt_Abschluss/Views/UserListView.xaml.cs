using Projekt_Abschluss.Helpers;
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

    public partial class UserListView : UserControl
    {
        
        public UserListView()
        {
            InitializeComponent();
            GetAllUsers();         



        }

        private async void GetAllUsers()
        {            
            UserRepository userRepository = new UserRepository();
            var users = await userRepository.GetAllAsync();
            UserList_DataGrid.ItemsSource = users;
           
        }

        private void UserButtonEditClick(object sender, RoutedEventArgs e)
        {
            Button buttonEdit = (Button)e.OriginalSource;
            DataGridRow dataGridRow = VisualTreeHelpers.FindAncestor<DataGridRow>(buttonEdit);
            UserDataGridModel user = dataGridRow.DataContext as UserDataGridModel;


            Window window = new Window
            {
                Title = "Edit User",
                Content = new UserEditView(user)

            };

            window.ShowDialog();
            GetAllUsers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Create new User",
                Content = new CreateUserView()

            };

            window.ShowDialog();
            GetAllUsers();
        }
    }
}
