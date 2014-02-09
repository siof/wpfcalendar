using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    internal class TaskItem : System.Windows.Controls.ListBoxItem
    {
        public TaskItem(Task task)
        {
            Content = task;
            ToolTip = task.ToolTip;
        }

        public Task TaskData
        {
            get
            {
                return Content as Task;
            }
        }

        public override string ToString()
        {
            return (Content as Task).ToString();
        }
    }
}
