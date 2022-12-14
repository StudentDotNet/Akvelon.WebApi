using Akvelon.Data.Status;
using System;
using System.ComponentModel.DataAnnotations;

namespace Akvelon.Domain.Models.Requests
{
    public class TaskRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "You should fill out a name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should fill out a description")]
        [MaxLength(50)]
        public string Description { get; set; }

        [EnumDataType(typeof(TaskStatus), ErrorMessage = "Status is required")]
        public TaskStatus Status { get; set; }

        public int Priority { get; set; }
    }
}
