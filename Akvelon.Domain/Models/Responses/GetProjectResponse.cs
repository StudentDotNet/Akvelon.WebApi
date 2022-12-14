using System;

namespace Akvelon.Domain.Models.Responses
{
    public class GetProjectResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string StartDate { get; set; }

        public string CompletionDate { get; set; }

        public string Status { get; set; }

        public int Priority { get; set; }
    }
}
