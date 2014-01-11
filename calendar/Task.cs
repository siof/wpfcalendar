using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    public class Task
    {
        private string name_ = "";
        private string localization_ = "";
        private string description_ = "";
        private DateTime startTime_;
        private DateTime endTime_;

        public string Name
        {
            get
            {
                return name_;
            }

            set
            {
                name_ = value;
            }
        }

        public string Localization
        {
            get
            {
                return localization_;
            }

            set
            {
                localization_ = value;
            }
        }

        public string Description
        {
            get
            {
                return description_;
            }

            set
            {
                description_ = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return startTime_;
            }

            set
            {
                startTime_ = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return endTime_;
            }

            set
            {
                endTime_ = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
