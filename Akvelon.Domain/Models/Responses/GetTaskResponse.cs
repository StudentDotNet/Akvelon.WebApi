using System;

namespace Akvelon.Domain.Models.Responses
{
    public class GetTaskResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public int Priority { get; set; }
    }
}
