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
        private bool initialized = false;
        public UserListView()
        {
            InitializeComponent();
            GetAllUsers();
            



        }

        private async void GetAllUsers()
        {
            initialized = false;
            UserRepository userRepository = new UserRepository();
            var users = await userRepository.GetAllAsync();
            UserList_DataGrid.ItemsSource = users;
            initialized = true;
        }

        private void OnChecked(object sender, RoutedEventArgs e)
        {
            if (initialized)
            {
                CheckBox checkBox = (CheckBox)e.OriginalSource;
                DataGridRow dataGridRow = VisualTreeHelpers.FindAncestor<DataGridRow>(checkBox);
                var user = (UserDataGridModel)dataGridRow.DataContext;
            }
            
        }

        
    }
}
