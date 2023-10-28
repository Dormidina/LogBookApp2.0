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

    public partial class EditTaskView : UserControl
    {
        private TaskModel? task;
        public TaskModel? Task
        {
            get { return task; }
            set { task = value;
                TaskName.Text = task?.Name;
                TaskDescription.Text = task?.Description;
                TaskEstimatedTime.Text = task?.EstimatedTime.ToString();
                TaskRealTime.Text = task?.RealTime.ToString();
                TaskPriority.Text = task?.Priority.ToString();
                TaskDateStart.Text = task?.DateStart.ToString();
                TaskDateEnd.Text = task?.DateEnd.ToString();
                TaskStatus.Text = task?.Status.ToString();
                TaskWorker.SelectedItem = task?.UserName;

                if (task == null)
                {
                    UpdateButton.IsEnabled = false;
                }
                else
                {
                    UpdateButton.IsEnabled = true;
                }
            }
        }

        public List<string>? Users { get; set; }

        public EditTaskView()
        {
            InitializeComponent();
            
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                var repository = new UserRepository();
                Users = repository.GetAllNames();
                TaskWorker.ItemsSource = Users;
            }
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            TaskRepository repository = new TaskRepository();           

            if (Task != null)
            {
                Task.Name = TaskName.Text;
                Task.Description = TaskDescription.Text;
                Task.EstimatedTime = TaskEstimatedTime.Value;
                Task.RealTime = TaskRealTime.Value;
                Task.Priority = TaskPriority.Value ?? 0;
                Task.DateStart = TaskDateStart.SelectedDate;
                Task.DateEnd = TaskDateEnd.SelectedDate;
                Task.Status = TaskStatus.Value ?? 0;
                Task.UserName = (string?)TaskWorker.SelectedItem;

                var updateSuccess = await repository.UpdateTaskAsync(Task);

                if (updateSuccess)
                {
                    MessageBox.Show("Task Updated");
                }
                else
                {
                    MessageBox.Show("Error Updating Task");
                }
            }
            
            
        }
        public void CleanView()
        {
            Task = null;            
        }
    }
}
