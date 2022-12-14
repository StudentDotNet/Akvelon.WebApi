using Akvelon.Data.Entities;
using System.Linq;

namespace Akvelon.Domain.Extension
{
    public static class SortExtensions
    {
        public static IQueryable<Project> ApplySort(this IQueryable<Project> collection, string query)
        {
            switch (query)
            {
                case "Name":
                    collection = collection.OrderBy(p => p.Name);
                    break;
                case "StartDate":
                    collection = collection.OrderBy(p => p.StartDate);
                    break;
                case "CompletionDate":
                    collection = collection.OrderBy(p => p.CompletionDate);
                    break;
                case "Status":
                    collection = collection.OrderBy(p => p.Status);
                    break;
                case "Priority":
                    collection = collection.OrderBy(p => p.Priority);
                    break;
            }
            return collection;
        }

        public static IQueryable<Task> ApplySort(this IQueryable<Task> collection, string query)
        {
            switch (query)
            {
                case "Name":
                    collection = collection.OrderBy(p => p.Name);
                    break;
                case "Description":
                    collection = collection.OrderBy(p => p.Description);
                    break;
                case "Status":
                    collection = collection.OrderBy(p => p.Status);
                    break;
                case "Priority":
                    collection = collection.OrderBy(p => p.Priority);
                    break;
            }
            return collection;
        }
    }
}
