using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDBApp
{
    internal class Task(string iTaskTitle, string iTaskDescription, string iTaskAuthor)
    {
        public int TaskId { get; set; }
        public string TaskTitle { get; set; } = iTaskTitle;
        public string TaskAuthorId { get; set; } = iTaskAuthor;
        public string TaskDescription { get; set; } = iTaskDescription;
        public string TaskUser = "No user assigned"; // This is optional and can be added later to set who should work on the task.
        public bool TaskCompleted { get; set; } = false;
        public DateTime TaskCreatedDate { get; set; } = DateTime.Now;
        public DateTime? TaskDeadline { get; set; } // This is optional and can be used to set expected time required to finish the task.


        public string GetTimeLeft()
        {
            if (!TaskDeadline.HasValue)
            {
                return "No deadline";
            }

            TimeSpan timeLeft = TaskDeadline.Value - DateTime.Now;

            if (timeLeft.TotalSeconds <= 0)
            {
                return "Deadline passed";
            }

            int daysLeft = (int)timeLeft.TotalDays;
            int hoursLeft = timeLeft.Hours;

            return $"{daysLeft} days and {hoursLeft} hours left";
        }
    }
    
}
