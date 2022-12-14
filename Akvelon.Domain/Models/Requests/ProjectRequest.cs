using Akvelon.Data.Status;
using System.ComponentModel.DataAnnotations;

namespace Akvelon.Domain.Models.Requests
{
    public class ProjectRequest
    {
        [Required(ErrorMessage = "You should fill out a name")]
        [MaxLength(50)]
        public string Name { get; set; }

        public string StartDate { get; set; }

        public string CompletionDate { get; set; }

        [EnumDataType(typeof(ProjectStatus), ErrorMessage = "Status is required")]
        public ProjectStatus Status { get; set; }

        public int Priority { get; set; }
    }
}
