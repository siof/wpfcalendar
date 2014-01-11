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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Reflection;

namespace calendar
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class TaskDataWindow : Window
    {
        private Task tmpTask = null;

        public TaskDataWindow()
        {
            InitializeComponent();

            for (TaskRepeatType i = TaskRepeatType.TASK_REPEAT_NONE; i < TaskRepeatType.TASK_REPEAT_COUNT; ++i)
            {
                FieldInfo fi = i.GetType().GetField(i.ToString());

                if (fi != null)
                {
                    object[] attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);

                    if (attrs != null && attrs.Length > 0)
                        cbRepeatType.Items.Add(((DescriptionAttribute)attrs[0]).Description);
                }
            }
        }

        public TaskDataWindow(Task taskToMod)
        {
            InitializeComponent();

            for (TaskRepeatType i = TaskRepeatType.TASK_REPEAT_NONE; i < TaskRepeatType.TASK_REPEAT_COUNT; ++i)
            {
                FieldInfo fi = i.GetType().GetField(i.ToString());

                if (fi != null)
                {
                    object[] attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);

                    if (attrs != null && attrs.Length > 0)
                        cbRepeatType.Items.Add(((DescriptionAttribute)attrs[0]).Description);
                }
            }

            tmpTask = taskToMod;

            if (tmpTask != null)
            {
                txtName.Text = tmpTask.Name;
                txtLocation.Text = tmpTask.Localization;
                txtDescription.Text = tmpTask.Description;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tmpTask == null)
                tmpTask = new Task();

            tmpTask.Name = txtName.Text;
            tmpTask.Localization = txtLocation.Text;
            tmpTask.Description = txtDescription.Text;

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public Task SavedTask
        {
            get
            {
                return tmpTask;
            }
        }
    }
}
