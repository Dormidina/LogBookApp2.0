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

    public partial class EditTaskView : UserControl
    {
        private TaskModel task;
        public TaskModel Task
        {
            get { return task; }
            set { task = value;
                TaskName.Text = task.Name;
                TaskDescription.Text = task.Description;
                TaskEstimatedTime.Text = task.EstimatedTime.ToString();
                TaskRealTime.Text = task.RealTime.ToString();
                TaskPriority.Text = task.Priority.ToString();
                TaskDateStart.Text = task.DateStart.ToString();
                TaskDateEnd.Text = task.DateEnd.ToString();
                TaskStatus.Text = task.Status.ToString();
                TaskWorker.Text = task.UserName;
            }
        }

        public List<string> Users { get; set; }

        public EditTaskView()
        {
            InitializeComponent();
            var repository = new UserRepository();            
            Users = repository.GetAllNames();
            TaskWorker.ItemsSource = Users;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
