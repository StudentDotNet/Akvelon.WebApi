using Akvelon.Data.Status;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Akvelon.Data.Entities
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        [Required]
        public ProjectStatus Status { get; set; }
        
        [Required]
        public int Priority { get; set; }
        
        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}
