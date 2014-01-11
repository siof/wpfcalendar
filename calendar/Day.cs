using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    public class Day
    {
        private DateTime date_ = DateTime.MinValue;
        private List<Task> taskList_ = new List<Task>();

        public Day()
        {
            
        }

        public Day(DateTime date)
        {
            date_ = date;
        }

        public DateTime Date
        {
            get
            {
                return date_;
            }

            set
            {
                date_ = value;
            }
        }

        public List<Task> TaskList
        {
            get
            {
                return taskList_;
            }

            set
            {
                taskList_ = value;
            }
        }

        public bool HasTask(Task task)
        {
            return taskList_.Contains(task);
        }

        public bool AddTask(Task task)
        {
            if (HasTask(task))
                return false;

            taskList_.Add(task);

            return true;
        }

        public bool RemoveTask(Task task)
        {
            return taskList_.Remove(task);
        }

        public bool RemoveTask(string taskName)
        {
            return taskList_.RemoveAll(x => x.Name == taskName) > 0 ? true : false;
        }
    }
}
