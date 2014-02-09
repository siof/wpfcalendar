using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Task> tasksList_ = new List<Task>();
        private ObservableCollection<Task> visibleTaskList_ = new ObservableCollection<Task>();

        public MainWindow()
        {
            InitializeComponent();

            dtDateToShow.SelectedDate = DateTime.Now;
        }

        public ObservableCollection<Task> Tasks
        {
            get
            {
                return visibleTaskList_;
            }
        }

        private List<Task> GetTasksForSelectedDay()
        {
            return tasksList_.FindAll(x => x.Date.Equals(dtDateToShow.SelectedDate));
        }

        private void btnRemoveTask_Click(object sender, RoutedEventArgs e)
        {
            if (lbTasks.SelectedItem != null)
            {
                tasksList_.Remove(lbTasks.SelectedItem as Task);
                visibleTaskList_.Remove(lbTasks.SelectedItem as Task);
            }
        }

        private void PrepareTasksForSelectedDay()
        {
            visibleTaskList_.Clear();
            List<Task> tmpList = GetTasksForSelectedDay();

            tmpList.Sort(delegate(Task a, Task b)
                {
                    if (a.StartTime == null && b.StartTime == null)
                        return 0;

                    if (a.StartTime == null)
                        return -1;

                    if (b.StartTime == null)
                        return 1;

                    return a.StartTime.CompareTo(b.StartTime);
                });

            foreach (var task in tmpList)
                visibleTaskList_.Add(task);
        }

        private void AddTask(Task task)
        {
            tasksList_.Add(task);
            PrepareTasksForSelectedDay();
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            if (!dtDateToShow.SelectedDate.HasValue)
                return;

            TaskDataWindow win = new TaskDataWindow(dtDateToShow.SelectedDate.Value);

            if (win.ShowDialog() == true)
                AddTask(win.SavedTask);
        }

        private void dtDateToShow_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            PrepareTasksForSelectedDay();
        }

        private void ShowModificationWindow(DateTime date, Task task)
        {
            TaskDataWindow win = new TaskDataWindow(date, task);

            win.ShowDialog();
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            if (!dtDateToShow.SelectedDate.HasValue || lbTasks.SelectedItem == null)
                return;

            ShowModificationWindow(dtDateToShow.SelectedDate.Value, lbTasks.SelectedItem as Task);
        }

        private void lbTasks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!dtDateToShow.SelectedDate.HasValue || lbTasks.SelectedItem == null)
                return;

            ShowModificationWindow(dtDateToShow.SelectedDate.Value, lbTasks.SelectedItem as Task);
        }
    }
}
