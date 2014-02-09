using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace calendar
{
    public class Task : INotifyPropertyChanged
    {
        private string name_ = "";
        private string location_ = "";
        private string description_ = "";
        private DateTime startTime_;
        private DateTime endTime_;
        private DateTime date_;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public string Name
        {
            get
            {
                return name_;
            }

            set
            {
                name_ = value;
                NotifyPropertyChanged("Name");
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
                NotifyPropertyChanged("Location");
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
                NotifyPropertyChanged("Description");
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
                NotifyPropertyChanged("StartTime");
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
                NotifyPropertyChanged("EndTime");
            }
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
                NotifyPropertyChanged("");
            }
        }

        public string TaskInfo
        {
            get
            {
                return string.Format("{0}:{1} - {2}{3} in {4}", startTime_.Hour, startTime_.Millisecond, endTime_.Hour, endTime_.Minute, location_);
            }
        }

        public string ToolTip
        {
            get
            {
                return GetTooltip();
            }
        }

        public string GetTooltip()
        {
            string tmpStr;
            tmpStr = "Name: " + Name + "\n";
            tmpStr += "Location: " + Location + "\n";
            tmpStr += "Start time: " + startTime_.Hour + ":" + startTime_.Minute + "\n";
            tmpStr += "End time: " + endTime_.Hour + ":" + endTime_.Minute + "\n";
            tmpStr += "Description: " + Description + "\n";
            tmpStr += "Repeatable: " + (this is RepeatableTask).ToString();

            return tmpStr;
        }
    }
}
