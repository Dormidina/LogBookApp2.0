using Projekt_Abschluss.Models;
using Projekt_Abschluss.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

    public partial class TaskColumnsView : UserControl
    {
        public List<TaskModel> Tasks { get; set; }
        private ObservableCollection<TaskModel>[] StatusTaskList = new ObservableCollection<TaskModel>[5];
        private ListView[] StatusListView = new ListView[5];
        public EditTaskView EditTaskView { get; set; }


        public TaskColumnsView()
        {
            InitializeComponent();
            StatusListView[0] = TaskBlockedListView;
            StatusListView[1] = TaskReadyListView;
            StatusListView[2] = TaskInProgressListView;
            StatusListView[3] = TaskTestListView;
            StatusListView[4] = TaskDoneListView;
        }

        public void SetTasks(List<TaskModel> tasks)
        {
            StatusTaskList[0] = new ObservableCollection<TaskModel>(tasks.Where(task => task.Status == 0));
            StatusTaskList[1] = new ObservableCollection<TaskModel>(tasks.Where(task => task.Status == 1));
            StatusTaskList[2] = new ObservableCollection<TaskModel>(tasks.Where(task => task.Status == 2));
            StatusTaskList[3] = new ObservableCollection<TaskModel>(tasks.Where(task => task.Status == 3));
            StatusTaskList[4] = new ObservableCollection<TaskModel>(tasks.Where(task => task.Status == 4));

            StatusListView[0].ItemsSource = StatusTaskList[0];
            StatusListView[1].ItemsSource = StatusTaskList[1];
            StatusListView[2].ItemsSource = StatusTaskList[2];
            StatusListView[3].ItemsSource = StatusTaskList[3];
            StatusListView[4].ItemsSource = StatusTaskList[4];
        }

        private async void MoveTaskClickButton(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string parameter = button.Tag as string;
                int destination = int.Parse(parameter.Split(',')[0]);
                int origin = int.Parse(parameter.Split(',')[1]);

                // Take Task
                var selectedTask = (TaskModel)StatusListView[origin].SelectedItem;
                if (selectedTask != null)
                {
                    // Remove Task
                    StatusTaskList[origin].Remove(selectedTask);
                    // Add Task
                    StatusTaskList[destination].Add(selectedTask);

                    var taskRepository = new TaskRepository();
                    await taskRepository.UpdateStatusAsync(selectedTask.TaskID, destination);
                    selectedTask.Status = destination;
                }
                               

            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            var selectedTask = listView.SelectedItem as TaskModel;
            if (selectedTask != null)
            {

            }
        }
    }



}
