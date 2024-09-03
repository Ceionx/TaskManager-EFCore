using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDBApp.Models
{
    public class Task(string iTaskAuthor)
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [MaxLength(25)]
        public string TaskTitle { get; set; } = null!;

        public string TaskAuthorId { get; set; } = iTaskAuthor;

        [Required]
        public string TaskDescription { get; set; } = null!;

        public string TaskUser { get; set; } = "No user assigned"; // This is optional and can be added later to set who should work on the task.
        
        public bool TaskCompleted { get; set; } = false;
        
        public DateTime TaskCreatedDate { get; set; } = DateTime.Now;

        public DateTime? TaskDeadline { get; set; } // This is optional and can be used to set expected time required to finish the task.

        public ICollection<Skill> RequiredSkills { get; set; } = new List<Skill>();

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
