using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDBApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(14)]
        public string Password { get; set; } = null!;

        // Navigation property for skills
        public ICollection<Skill> Skillset { get; set; } = new List<Skill>();

        // Navigation properties for tasks
        public ICollection<Task> CreatedTasks { get; set; } = new List<Task>();
        public ICollection<Task> AssignedTasks { get; set; } = new List<Task>();

    }
}
