using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    public enum TaskRepeatType
    {
        [DescriptionAttribute("Disabled")]
        TASK_REPEAT_NONE = 0,

        [DescriptionAttribute("Daily")]
        TASK_REPEAT_DAILY = 1,

        [DescriptionAttribute("Weekly")]
        TASK_REPEAT_WEEKLY = 2,

        [DescriptionAttribute("Monthly")]
        TASK_REPEAT_MONTHLY = 3,

        [DescriptionAttribute("Yearly")]
        TASK_REPEAT_YEARLY = 4,

        TASK_REPEAT_COUNT = 5
    }

    public class RepeatableTask : Task
    {
        private TaskRepeatType taskRepeatType_ = TaskRepeatType.TASK_REPEAT_NONE;
        private DateTime repeatStart_ = DateTime.MinValue;
        private DateTime? repeatEnd_ = null;

        public RepeatableTask(Task t)
        {
            Name = t.Name;
            Localization = t.Localization;
            Description = t.Description;
            StartTime = t.StartTime;
            EndTime = t.EndTime;
        }

        public TaskRepeatType RepeatType
        {
            get
            {
                return taskRepeatType_;
            }

            set
            {
                taskRepeatType_ = value;
            }
        }

        public DateTime RepeatStart
        {
            get
            {
                return repeatStart_;
            }

            set
            {
                repeatStart_ = value;
            }
        }

        public DateTime? RepeatEnd
        {
            get
            {
                return repeatEnd_;
            }

            set
            {
                repeatEnd_ = value;
            }
        }
    }
}
