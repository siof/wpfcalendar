using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    public class Day
    {
        private DateTime date_;
        private List<Task> taskList_;

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
    }
}
