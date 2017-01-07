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
using TodoList.Models;

namespace TodoList.ViewModels
{
    class TaskListViewModel : ViewModelBase
    {
        static string[] Scopes = { TasksService.Scope.TasksReadonly };
        static string ApplicationName = "TodoListApp";

        public ObservableCollection<TaskList> TaskLists { get; set; }

        public void LoadTaskList()
        {
            UserCredential credential;
            using (var stream = new FileStream("Properties/client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = System.IO.Path.Combine(credPath, ".credentials/tasks-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                System.Windows.MessageBox.Show("Credential file saved to: " + credPath);
            }

            // Create Google Tasks API service.
            var service = new TasksService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            TasklistsResource.ListRequest listRequest = service.Tasklists.List();
            listRequest.MaxResults = 10;

            // List task lists.
            IList<Google.Apis.Tasks.v1.Data.TaskList> gTaskLists = listRequest.Execute().Items;

            if (gTaskLists != null && gTaskLists.Count > 0)
            {
                ObservableCollection<TaskList> taskLists = new ObservableCollection<TaskList>();
                foreach (var gtList in gTaskLists)
                {
                    taskLists.Add(new TaskList { Id = gtList.Id, Title = gtList.Title, Color = "#FFBB1E1E" });

                }
                TaskLists = taskLists;
            }
            else { System.Windows.MessageBox.Show("No task lists found."); }

        }

    }
}
