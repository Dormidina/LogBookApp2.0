﻿using Projekt_Abschluss.Helpers;
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

    public partial class LoggingView : UserControl
    {
        public MainWindow MainWindow { get; set; }
        public LoggingView(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private async void LoggingButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            UserLogInModel user = new UserLogInModel
            {
                Name = UserTextBox.Text,
                Password = PasswordPasswordBox.Password
            };

            UserRepository repository = new UserRepository();

            var userLogIn = await repository.LogInAsync(user);
            

            if (userLogIn != null)
            {
                LogInHelper.Session = userLogIn;
                MainWindow.LoggingSuccess();
            }
            else
            {
                MessageBox.Show("Logging Error");
            }




        }
    }
}
