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

            dpDateToShow.DisplayDate = DateTime.Now;
            dpDateToShow.SelectedDate = DateTime.Now;
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
            return daysList_.Find(x => x.Date.Equals(dpDateToShow.SelectedDate.Value));
        }

        private void ShowTaskList()
        {
            RefreshTaskList();
        }

        private void RefreshTaskList()
        {
            lbTasks.Items.Clear();
            Day tmpDay = GetSelectedDay();

            if (tmpDay != null)
            {
                foreach (Task task in tmpDay.TaskList)
                    lbTasks.Items.Add(task.Name);
            }
        }

        private void btnRemoveTask_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            TaskDataWindow win = new TaskDataWindow();

            if (win.ShowDialog() == true)
            {
                Task newTask = win.SavedTask;

                Day tmpDay = GetSelectedDay();
                if (tmpDay == null)
                {
                    tmpDay = new Day(dpDateToShow.SelectedDate.Value);
                    daysList_.Add(tmpDay);
                }

                tmpDay.AddTask(newTask);
            }

            ShowTaskList();
        }

        private void dpDateToShow_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshTaskList();
        }
    }
}
