using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using Xceed.Wpf.Toolkit;

namespace calendar
{
    /// <summary>
    /// Interaction logic for TaskDataWindow.xaml
    /// </summary>
    public partial class TaskDataWindow : Window
    {
        private Task tmpTask_ = null;
        private DateTime currentDate_;

        public TaskDataWindow(DateTime currentDate)
        {
            InitializeComponent();

            currentDate_ = currentDate;

            FillRepeatTypeComboBox();
            ShowForRepeatable(false);
        }

        public TaskDataWindow(DateTime currentDate, Task taskToMod)
        {
            InitializeComponent();

            currentDate_ = currentDate;

            FillRepeatTypeComboBox();
            tmpTask_ = taskToMod;

            if (tmpTask_ != null)
            {
                txtName.Text = tmpTask_.Name;
                txtLocation.Text = tmpTask_.Location;
                txtDescription.Text = tmpTask_.Description;
                dtStartTime.Value = taskToMod.StartTime;
                dtEndTime.Value = taskToMod.EndTime;

                if (tmpTask_ is RepeatableTask)
                {
                    dpDueDate.SelectedDate = ((RepeatableTask)tmpTask_).RepeatEnd;
                    cbRepeatType.SelectedIndex = (int)((RepeatableTask)tmpTask_).RepeatType;
                    ShowForRepeatable(true);
                }
                else
                    ShowForRepeatable(false);
            }
        }

        private void ShowForRepeatable(bool show = true)
        {
            dpDueDate.Visibility = lblEndDate.Visibility = show ? Visibility.Visible : Visibility.Hidden;
        }

        private void FillRepeatTypeComboBox()
        {
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

            if (cbRepeatType.HasItems)
                cbRepeatType.SelectedIndex = (int)TaskRepeatType.TASK_REPEAT_NONE;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tmpTask_ == null)
                tmpTask_ = new Task();

            if (cbRepeatType.SelectedIndex != (int)TaskRepeatType.TASK_REPEAT_NONE)
            {
                if ((tmpTask_ is RepeatableTask) == false)
                {
                    Task tempTask = tmpTask_;
                    tmpTask_ = new RepeatableTask(tempTask);
                }

                ((RepeatableTask)tmpTask_).RepeatType = (TaskRepeatType)cbRepeatType.SelectedIndex;
                ((RepeatableTask)tmpTask_).RepeatEnd = dpDueDate.SelectedDate;

                if (((RepeatableTask)tmpTask_).RepeatStart == null)
                    ((RepeatableTask)tmpTask_).RepeatStart = currentDate_;
            }

            tmpTask_.Name = txtName.Text;
            tmpTask_.Location = txtLocation.Text;
            tmpTask_.Description = txtDescription.Text;

            if (dtStartTime.Value.HasValue && dtEndTime.Value.HasValue)
            {
                tmpTask_.StartTime = dtStartTime.Value.Value;
                tmpTask_.EndTime = dtEndTime.Value.Value;
            }

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
                return tmpTask_;
            }
        }

        private void cbRepeatType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowForRepeatable(cbRepeatType.SelectedIndex != (int)TaskRepeatType.TASK_REPEAT_NONE);
        }
    }
}
