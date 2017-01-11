using MyToolkit.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TodoList.Connections;
using TodoList.Models;

namespace TodoList.ViewModels
{
    class TaskViewModel : ViewModelBase
    {
        public ObservableCollection<Models.Task> Tasks { get; set; }
        public string Color { get; set; }

        public void LoadTasks(string taskList)
        {
            IList<Google.Apis.Tasks.v1.Data.Task> gTasks = GoogleTasksAPIConnection.GetTasks(taskList);

            if (gTasks != null && gTasks.Count > 0)
            {
                ObservableCollection<Models.Task> tasks = new ObservableCollection<Models.Task>();
                foreach (var gTask in gTasks)
                {
                    if (gTask.Status != "completed" && gTask.Title != "")
                    {
                        tasks.Add(new Task { Id = gTask.Id, Title = gTask.Title, ParentId = gTask.Parent });
                    }
                }
                Tasks = tasks;
            }
            else { System.Windows.MessageBox.Show("No tasks found."); }
        }

        public void LoadAllTasks()
        {

            IList<Google.Apis.Tasks.v1.Data.Task> gTasks;
            ObservableCollection<Models.Task> tasks = new ObservableCollection<Models.Task>();

            IList<Google.Apis.Tasks.v1.Data.TaskList> gTaskLists = GoogleTasksAPIConnection.GetTaskLists();

            if (gTaskLists != null && gTaskLists.Count > 0)
            {
                ObservableCollection<TaskList> taskLists = new ObservableCollection<TaskList>();
                foreach (var gtList in gTaskLists)
                {
                    gTasks = GoogleTasksAPIConnection.GetTasks(gtList.Id);

                    if (gTasks != null && gTasks.Count > 0)
                    {
                        foreach (var gTask in gTasks)
                        {
                            if (gTask.Status != "completed" && gTask.Title != "")
                            {
                                tasks.Add(new Task { Id = gTask.Id, Title = gTask.Title, ParentId = gTask.Parent });
                            }
                        }
                    }
                }
                Tasks = tasks;
            }
            else { System.Windows.MessageBox.Show("No tasks found."); }
        }

        public void LoadTodaysTasks()
        {
            IList<Google.Apis.Tasks.v1.Data.Task> gTasks;
            ObservableCollection<Models.Task> tasks = new ObservableCollection<Models.Task>();

            IList<Google.Apis.Tasks.v1.Data.TaskList> gTaskLists = GoogleTasksAPIConnection.GetTaskLists();

            if (gTaskLists != null && gTaskLists.Count > 0)
            {
                ObservableCollection<TaskList> taskLists = new ObservableCollection<TaskList>();
                foreach (var gtList in gTaskLists)
                {
                    gTasks = GoogleTasksAPIConnection.GetTasks(gtList.Id);

                    if (gTasks != null && gTasks.Count > 0)
                    {
                        foreach (var gTask in gTasks)
                        {
                            if (gTask.Status != "completed" && gTask.Title != "" && (!gTask.Due.HasValue || gTask.Due.Value.Date <= DateTime.Now.Date))
                            {
                                tasks.Add(new Task { Id = gTask.Id, Title = gTask.Title, ParentId = gTask.Parent });
                            }
                        }
                    }
                }
                Tasks = tasks;
            }
            else { System.Windows.MessageBox.Show("No tasks found."); }
        }

        public void LoadWeekTasks()
        {
            IList<Google.Apis.Tasks.v1.Data.Task> gTasks;
            ObservableCollection<Models.Task> tasks = new ObservableCollection<Models.Task>();
            DateTime endDate = DateTime.Now.Date.AddDays(7).Date;
            IList<Google.Apis.Tasks.v1.Data.TaskList> gTaskLists = GoogleTasksAPIConnection.GetTaskLists();

            if (gTaskLists != null && gTaskLists.Count > 0)
            {
                ObservableCollection<TaskList> taskLists = new ObservableCollection<TaskList>();
                foreach (var gtList in gTaskLists)
                {
                    gTasks = GoogleTasksAPIConnection.GetTasks(gtList.Id);

                    if (gTasks != null && gTasks.Count > 0)
                    {
                        foreach (var gTask in gTasks)
                        {
                            if (gTask.Status != "completed" && gTask.Title != "" && (!gTask.Due.HasValue || gTask.Due.Value.Date <= endDate))
                            {
                                tasks.Add(new Task { Id = gTask.Id, Title = gTask.Title, ParentId = gTask.Parent });
                            }
                        }
                    }
                }
                Tasks = tasks;
            }
            else { System.Windows.MessageBox.Show("No tasks found."); }
        }
    }
}
