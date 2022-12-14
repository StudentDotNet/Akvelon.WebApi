using Akvelon.Data.Status;

namespace Akvelon.Domain.Models
{
    public class QueryParameters
    {
        public string SearchQuery { get; set; }
        public string OrderBy { get; set; }
        public ProjectStatus? Status { get; set; }
        public TaskStatus? TaskStatus { get; set; }
    }
}
