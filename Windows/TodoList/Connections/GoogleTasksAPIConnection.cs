using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Tasks.v1;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodoList.Connections
{
    class GoogleTasksAPIConnection
    {
        private static string[] Scopes = { TasksService.Scope.TasksReadonly };
        private static string ApplicationName = "TodoListApp";
        private static TasksService service;

        private static void Connect()
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
                //System.Windows.MessageBox.Show("Credential file saved to: " + credPath);
            }

            // Create Google Tasks API service.
            service = new TasksService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public static IList<Google.Apis.Tasks.v1.Data.TaskList> GetTaskLists()
        {
            if (service == null)
                Connect();

            // Define parameters of request.
            TasklistsResource.ListRequest listRequest = service.Tasklists.List();

            // List tasklists.
            IList<Google.Apis.Tasks.v1.Data.TaskList> gTaskLists = listRequest.Execute().Items;

            return gTaskLists;
        }

        public static IList<Google.Apis.Tasks.v1.Data.Task> GetTasks(string taskListId)
        {
            if (service == null)
                Connect();

            TasksResource.ListRequest listRequest = service.Tasks.List(taskListId);

            IList<Google.Apis.Tasks.v1.Data.Task> gTasks = listRequest.Execute().Items;

            return gTasks;
        }
    }
}
