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
using System.Windows.Media.Animation;
using Google.Apis.Tasks.v1;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Tasks.v1.Data;
using System.Collections.ObjectModel;
using TodoList.ViewModels;

namespace TodoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<TaskList> tLists;
        static string[] Scopes = { TasksService.Scope.TasksReadonly };
        static string ApplicationName = "TodoListApp";
        public MainWindow()
        {
            InitializeComponent();

            //UserCredential credential;
            //using (var stream = new FileStream("Properties/client_secret.json", FileMode.Open, FileAccess.Read))
            //{
            //    string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //    credPath = System.IO.Path.Combine(credPath, ".credentials/tasks-dotnet-quickstart.json");

            //    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            //        GoogleClientSecrets.Load(stream).Secrets,
            //        Scopes,
            //        "user",
            //        CancellationToken.None,
            //        new FileDataStore(credPath, true)).Result;
            //    System.Windows.MessageBox.Show("Credential file saved to: " + credPath);
            //}

            //// Create Google Tasks API service.
            //var service = new TasksService(new BaseClientService.Initializer()
            //{
            //    HttpClientInitializer = credential,
            //    ApplicationName = ApplicationName,
            //});

            //// Define parameters of request.
            //TasklistsResource.ListRequest listRequest = service.Tasklists.List();
            //listRequest.MaxResults = 10;

            //// List task lists.
            //IList<Google.Apis.Tasks.v1.Data.TaskList> taskLists = listRequest.Execute().Items;
            //tLists = new ObservableCollection<TaskList>();
            //if (taskLists != null && taskLists.Count > 0)
            //{
            //    foreach (var taskList in taskLists)
            //    {
            //        TaskList tList = new TaskList(taskList.Id, taskList.Title, "GoogleTask", taskList.SelfLink, taskList.Updated);
            //        IList<Google.Apis.Tasks.v1.Data.Task> tasks = service.Tasks.List(taskList.Id).Execute().Items;
            //        if (tasks != null && tasks.Count > 0)
            //        {
            //            foreach (var task in tasks)
            //            {
            //                if (task.Deleted == null || task.Deleted == false)
            //                {
            //                    (tList.Tasks).Add(new Task(task.Id, task.Title, task.Notes, task.Parent, task.SelfLink, task.Status, task.Hidden, task.Completed, task.Due, task.Updated));
            //            }
            //        }
            //        }
            //    }
            //}
            //else
            //{
            //    System.Windows.MessageBox.Show("No task lists found.");
            //}

            //this.DataContext = tLists;

        }

        private void TaskListViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            TaskListViewModel taskListViewModelObject = new TaskListViewModel();
            taskListViewModelObject.LoadTaskList();

            TaskListViewControl.DataContext = taskListViewModelObject;
        }

        //private void showTaskMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowHideMenu("sbShowTaskMenu", btnHideTaskMenu, btnShowTaskMenu, pnlTaskMenu, pnlMenuHeader);
        //}

        //private void hideTaskMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowHideMenu("sbHideTaskMenu", btnHideTaskMenu, btnShowTaskMenu, pnlTaskMenu, pnlMenuHeader);
        //}

        //private void ShowHideMenu(string storyboard, Button btnHide, Button btnShow, StackPanel pnl, DockPanel opnl)
        //{
        //    Storyboard sb = Resources[storyboard] as Storyboard;
        //    sb.Begin(pnl);

        //    if(storyboard.Contains("Show"))
        //    {
        //        //btnHide.Visibility = System.Windows.Visibility.Visible;
        //        btnShow.Visibility = System.Windows.Visibility.Collapsed;
        //        //pnl.Margin = new Thickness(0);
        //        //opnl.Margin = new Thickness(pnl.Width, 0, 0, 0);
        //    }
        //    else if(storyboard.Contains("Hide"))
        //    {
        //        //btnHide.Visibility = System.Windows.Visibility.Hidden;
        //        btnShow.Visibility = System.Windows.Visibility.Visible;
        //        //pnl.Margin = new Thickness(-(pnl.Width), 0, 0, 0);
        //        //opnl.Margin = new Thickness(0);

        //    }
        //}


    }
}
