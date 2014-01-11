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
    public partial class AddTask : Window
    {
        private Task tmpTask = null;

        public AddTask()
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
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
