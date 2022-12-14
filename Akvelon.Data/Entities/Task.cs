using Akvelon.Data.Status;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akvelon.Data.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public TaskStatus Status { get; set; }

        [Required]
        public int Priority { get; set; }

        [ForeignKey("ProjectId")]
        public Guid ProjectId { get; set; }
    }
}
