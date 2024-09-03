using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDBApp.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; } = null!;

        // Navigation properties
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
