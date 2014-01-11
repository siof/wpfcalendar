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
        private List<Day> daysList_;

        public MainWindow()
        {
            InitializeComponent();
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

        private void btnRemoveTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            TaskDataWindow win = new TaskDataWindow();

            if (win.ShowDialog() == true)
            {
                Task newTask = win.SavedTask;
            }
        }
    }
}
