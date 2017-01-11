using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Tasks.v1;
using Google.Apis.Util.Store;
using MyToolkit.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Connections;
using TodoList.Models;

namespace TodoList.ViewModels
{
    class TaskListViewModel : ViewModelBase
    {
        public ObservableCollection<TaskList> TaskLists { get; set; }
        public int AllTasksCount { get; set; }

        public void LoadTaskLists()
        {
            IList<Google.Apis.Tasks.v1.Data.TaskList> gTaskLists = GoogleTasksAPIConnection.GetTaskLists();
            int countAll = 0;
            if (gTaskLists != null && gTaskLists.Count > 0)
            {
                ObservableCollection<TaskList> taskLists = new ObservableCollection<TaskList>();
                foreach (var gtList in gTaskLists)
                {
                    IList<Google.Apis.Tasks.v1.Data.Task> gTasks = GoogleTasksAPIConnection.GetTasks(gtList.Id);
                    taskLists.Add(new TaskList { Id = gtList.Id, Title = gtList.Title, Color = "#FFBB1E1E", Count = gTasks.Count });
                    countAll += gTasks.Count;
                }
                TaskLists = taskLists;
                AllTasksCount = countAll;
            }
            else { System.Windows.MessageBox.Show("No task lists found."); }

        }

    }
}
