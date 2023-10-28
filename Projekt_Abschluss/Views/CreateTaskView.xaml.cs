using Projekt_Abschluss.Models;
using Projekt_Abschluss.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public partial class CreateTaskView : UserControl
    {      
       
        public List<string>? Users { get; set; }
        public List<ShowProjectsModel>? Projects { get; set; }
        public CreateTaskView()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                var userRepository = new UserRepository();
                var projectRepository = new ProjectRepository();

                Users = userRepository.GetAllNames();
                Projects = projectRepository.GetAllProjects();

                ProjectBox.ItemsSource = Projects;
                TaskWorker.ItemsSource = Users;
            }

        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProjectBox.SelectedItem == null)
            {
                MessageBox.Show("Project is required to create a new Task");
                return;
            }
            if (string.IsNullOrEmpty(TaskName.Text))
            {
                MessageBox.Show("Name is required to create a new Task");
                return;
            }
            if (string.IsNullOrEmpty(TaskDescription.Text))
            {
                MessageBox.Show("Description is required to create a new Task");
                return;
            }
            
            CreateTaskModel task = new CreateTaskModel();

            task.Name = TaskName.Text;
            task.Description = TaskDescription.Text;
            task.EstimatedTime = TaskEstimatedTime.Value;
            task.RealTime = TaskRealTime.Value;
            task.Priority = TaskPriority.Value ?? 0;
            task.DateStart = TaskDateStart.SelectedDate;
            task.DateEnd = TaskDateEnd.SelectedDate;
            task.Status = TaskStatus.Value ?? 0;
            task.UserName = (string?)TaskWorker?.SelectedItem;
            task.ProjectID = (int)ProjectBox.SelectedValue;

            TaskRepository taskRepository = new TaskRepository();
            

            if(await taskRepository.CreateTaskAsync(task))
            {
                MessageBox.Show("Task created!");

                Window parentWindow = Window.GetWindow(this);
                parentWindow?.Close();
            }
            else
            {
                MessageBox.Show("Error creating Task, please check all assigments");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }
    }
}
