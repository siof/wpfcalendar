using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    enum TaskRepeatType
    {
        TASK_REPEAT_NONE    = 0,
        TASK_REPEAT_DAILY   = 1,
        TASK_REPEAT_WEEKLY  = 2,
        TASK_REPEAT_MONTHLY = 3,
        TASK_REPEAT_YEARLY  = 4
    }

    class RepeatableTask : Task
    {
        private TaskRepeatType taskRepeatType_ = TaskRepeatType.TASK_REPEAT_NONE;
        private DateTime repeatStart_;
        private DateTime repeatEnd_;

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

        public DateTime RepeatEnd
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
