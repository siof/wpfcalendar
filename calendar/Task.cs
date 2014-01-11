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
        private string location_ = "";
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

        public string Location
        {
            get
            {
                return location_;
            }

            set
            {
                location_ = value;
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

        public string GetTooltip()
        {
            string tmpStr;
            tmpStr = "Name: " + Name + "\n";
            tmpStr += "Location: " + Location + "\n";
            tmpStr += "Start time: " + startTime_.TimeOfDay.ToString() + "\n";
            tmpStr += "End time: " + endTime_.TimeOfDay.ToString() + "\n";
            tmpStr += "Description: " + Description + "\n";
            tmpStr += "Repeatable: " + (this is RepeatableTask).ToString();

            return tmpStr;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
