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
using TodoList.Views;
using TodoList.Controls;

namespace TodoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string[] Scopes = { TasksService.Scope.TasksReadonly };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuButtonThreeBarsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            btnShowHideTaskMenu.Click += new RoutedEventHandler(showHideTaskListMenu_Click);
        }

        #region Loaded Methods
        private void btnAllTask_Loaded(object sender, RoutedEventArgs e)
        {
            btnAllTask.ButtonLabel = "All Tasks";
            btnAllTask.ButtonCount = "5";
            btnAllTask.Click += new RoutedEventHandler(showAllTasks_Click);
        }

        private void btnTodayTask_Loaded(object sender, RoutedEventArgs e)
        {
            btnTodayTask.ButtonLabel = "Today";
            btnTodayTask.ButtonCount = "8";
            btnTodayTask.Click += new RoutedEventHandler(showTodayTasks_Click);
        }

        private void btnWeekTask_Loaded(object sender, RoutedEventArgs e)
        {
            btnWeekTask.ButtonLabel = "Next 7 Days";
            btnWeekTask.ButtonCount = "6";
            btnWeekTask.Click += new RoutedEventHandler(showWeekTasks_Click);
        }

        private void TaskListViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            TaskListViewModel taskListViewModelObject = new TaskListViewModel();
            taskListViewModelObject.LoadTaskLists();
            string temp = "Changed";
            App.Current.Resources["AllTasksCount"] = temp;

            //TaskListViewControl.btnHideTaskListViewControl.Click += new RoutedEventHandler(showHideTaskListMenu_Click);
            //TaskListViewControl.btnAll.Click += new RoutedEventHandler(showAllTasks_Click);
            //TaskListViewControl.btnAll.DataContext = taskListViewModelObject.AllTasksCount;
            //TaskListViewControl.btnToday.Click += new RoutedEventHandler(showTodayTasks_Click);
            //TaskListViewControl.btnNextWeek.Click += new RoutedEventHandler(showWeekTasks_Click);
            TaskListViewControl.Click += new RoutedEventHandler(showTaskListTasks_Click);
            TaskListViewControl.DataContext = taskListViewModelObject;
            
        }

        private void TaskViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            TaskViewModel taskViewModelObject = new TaskViewModel();
            taskViewModelObject.LoadAllTasks();
            //TaskViewControl.Click += new RoutedEventHandler(showAllGoupTasks_Click);
            TaskViewControl.DataContext = taskViewModelObject;
        }
        #endregion

        #region Click Methods
        private void showAllTasks_Click(object sender, RoutedEventArgs e)
        {
            lblCurrentPanel.Content = "All Tasks";
            TaskViewModel taskViewModelObject = new TaskViewModel();
            taskViewModelObject.LoadAllTasks();
            TaskViewControl.DataContext = taskViewModelObject;
        }

        private void showTodayTasks_Click(object sender, RoutedEventArgs e)
        {
            lblCurrentPanel.Content = "Today";
            TaskViewModel taskViewModelObject = new TaskViewModel();
            taskViewModelObject.LoadTodaysTasks();
            TaskViewControl.DataContext = taskViewModelObject;
        }

        private void showWeekTasks_Click(object sender, RoutedEventArgs e)
        {
            lblCurrentPanel.Content = "Next 7 Days";
            TaskViewModel taskViewModelObject = new TaskViewModel();
            taskViewModelObject.LoadWeekTasks();
            TaskViewControl.DataContext = taskViewModelObject;
        }

        private void showTaskListTasks_Click(object sender, RoutedEventArgs e)
        {
            lblCurrentPanel.Content = ((Models.TaskList)((Button)e.Source).DataContext).Title;
            TaskViewModel taskViewModelObject = new TaskViewModel();
            taskViewModelObject.Color = ((Models.TaskList)((Button)e.Source).DataContext).Color;
            taskViewModelObject.LoadTasks(((Models.TaskList)((Button)e.Source).DataContext).Id);
            TaskViewControl.DataContext = taskViewModelObject;
        }

        private void showHideTaskListMenu_Click(object sender, RoutedEventArgs e)
        {
            Thickness hideLeft = new Thickness(-250, 0, 0, 0);
            if (TaskListViewPanel.Margin == hideLeft)
            {
                ShowHideMenu("sbShowTaskMenu", btnShowHideTaskMenu, TaskListViewPanel, lblCurrentPanel);
            }
            else
            {
                ShowHideMenu("sbHideTaskMenu", btnShowHideTaskMenu, TaskListViewPanel, lblCurrentPanel);
            }
            
        }
        #endregion

        private void ShowHideMenu(string storyboard, MenuButtonThreeBarsUserControl btnShow, DockPanel pnl, Label opnl)
        {
            Storyboard sb = Resources[storyboard] as Storyboard;
            sb.Begin(pnl);

            if (storyboard.Contains("Show"))
            {
                //btnShow.Visibility = System.Windows.Visibility.Collapsed;
                opnl.Margin = new Thickness(250, 0, 0, 0);
            }
            else if (storyboard.Contains("Hide"))
            {
                //btnShow.Visibility = System.Windows.Visibility.Visible;
                opnl.Margin = new Thickness(0, 0, 0, 0);
            }
        }

        
    }
}
