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

namespace calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Day> daysList_ = new List<Day>();

        public MainWindow()
        {
            InitializeComponent();

            dtDateToShow.SelectedDate = DateTime.Now;
        }

        public List<Day> DaysList
        {
            get
            {
                return daysList_;
            }

            set
            {
                daysList_ = value;
            }
        }

        private Day GetSelectedDay()
        {
            return daysList_.Find(x => x.Date.Equals(dtDateToShow.SelectedDate));
        }

        private void RefreshTaskList()
        {
            lbTasks.Items.Clear();
            Day tmpDay = GetSelectedDay();

            if (tmpDay != null)
            {
                foreach (Task task in tmpDay.TaskList)
                    lbTasks.Items.Add(task);
            }
        }

        private void btnRemoveTask_Click(object sender, RoutedEventArgs e)
        {
            Day tmpDay = GetSelectedDay();

            if (tmpDay != null)
            {
                tmpDay.RemoveTask((Task)lbTasks.SelectedItem);
                RefreshTaskList();

                if (!tmpDay.HasTasks())
                    RemoveDay(tmpDay);
            }
        }

        private Day GetOrCreateSelectedDay()
        {
            Day tmpDay = GetSelectedDay();
            if (tmpDay == null && dtDateToShow.SelectedDate.HasValue)
            {
                tmpDay = new Day(dtDateToShow.SelectedDate.Value);
                daysList_.Add(tmpDay);
            }

            return tmpDay;
        }

        private void RemoveDay(Day day)
        {
            daysList_.Remove(day);
        }

        private void AddTask(Task task)
        {
            Day tmpDay = GetOrCreateSelectedDay();
            tmpDay.AddTask(task);
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            if (!dtDateToShow.SelectedDate.HasValue)
                return;

            TaskDataWindow win = new TaskDataWindow(dtDateToShow.SelectedDate.Value);

            if (win.ShowDialog() == true)
                AddTask(win.SavedTask);

            RefreshTaskList();
        }

        private void dtDateToShow_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshTaskList();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            if (!dtDateToShow.SelectedDate.HasValue || lbTasks.SelectedItem == null)
                return;

            TaskDataWindow win = new TaskDataWindow(dtDateToShow.SelectedDate.Value, (Task)lbTasks.SelectedItem);

            win.ShowDialog();
            RefreshTaskList();
        }
    }
}
