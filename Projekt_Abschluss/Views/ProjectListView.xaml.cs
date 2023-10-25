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
    
    public partial class ProjectListView : UserControl
    {
        
        public ProjectListView()
        {
            InitializeComponent();
            GetAllProjects();
            TaskColumnsView.EditTaskView = DetailsTaskView;

            if (LogInHelper.Session.IsAdmin == false)
            {
                CreateUserButton.Visibility = Visibility.Collapsed;

            }
        }

        private void CreateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Create new Project",
                Content = new CreateProjectView()
            };

            window.ShowDialog();
            GetAllProjects();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Create new User",
                Content = new CreateUserView()

            };
            
            window.ShowDialog();

        }

        private async void GetAllProjects()
        {
            ProjectRepository projectRepository = new ProjectRepository();
            var projects = await projectRepository.GetAllAsync();
            ProjektList_DataGrid.ItemsSource = projects;
        }

        private async void ProjektList_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProjectModel selectedProject = (ProjectModel)ProjektList_DataGrid.SelectedItem;

            if (selectedProject != null)
            {
                TaskRepository taskRepository = new TaskRepository();
                var task = await taskRepository.GetAllTaskAsync(selectedProject.ProjectID);
                TaskColumnsView.SetTasks(task);
            }


        }

        
    }
}
