using Akvelon.Data.Entities;
using Akvelon.Data.Status;
using Microsoft.EntityFrameworkCore;
using System;

namespace Akvelon.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "DocumentService App",
                    StartDate = new DateTime(2011, 6, 1),
                    CompletionDate = new DateTime(2012, 2, 1),
                    Status = ProjectStatus.Completed,
                    Priority = 1,
                },
                new Project
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Name = "DocumentService Api",
                    StartDate = new DateTime(2011, 7, 5),
                    CompletionDate = new DateTime(2012, 11, 11),
                    Status = ProjectStatus.Completed,
                    Priority = 1,
                },
                new Project
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Name = "Search Service Api",
                    StartDate = new DateTime(2011, 6, 1),
                    Status = ProjectStatus.NotStarted,
                    Priority = 2,
                },
                new Project
                {
                    Id = Guid.Parse("d28888e9-2ba9-474a-a40f-e38cb54f9b35"),
                    Name = "Auth Service",
                    StartDate = new DateTime(11, 12, 1),
                    CompletionDate = new DateTime(12, 12, 1),
                    Status = ProjectStatus.Active,
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Configure service for importing pdf document",
                    Description = "Configure service for importing pdf document",
                    Status = TaskStatus.Done,
                    Priority = 1,
                    ProjectId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450")
                }, 
                new Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Cover the service with unit test",
                    Description = "Cover the service with unit test",
                    Status = TaskStatus.InProgress,
                    Priority = 2,
                    ProjectId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450")
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Deploy service in the Azure Cloud",
                    Description = "Deploy service in the Azure Cloud",
                    Status = TaskStatus.ToDo,
                    Priority = 3,
                    ProjectId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450")
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Implementing UI part for document service",
                    Description = "Implementing UI part for document service",
                    Status = TaskStatus.Done,
                    Priority = 1,
                    ProjectId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Testing UI",
                    Description = "Manuially Testing of the UI",
                    Status = TaskStatus.InProgress,
                    Priority = 1,
                    ProjectId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Integration testing",
                    Description = "Integration testing",
                    Status = TaskStatus.ToDo,
                    Priority = 1,
                    ProjectId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Configure Elastic Search",
                    Description = "Configure Elastic Search",
                    Status = TaskStatus.Done,
                    Priority = 1,
                    ProjectId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09")
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Create index for document",
                    Description = "Create index for document",
                    Status = TaskStatus.InProgress,
                    Priority = 2,
                    ProjectId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09")
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Implement searching using Nest sdk",
                    Description = "",
                    Status = TaskStatus.ToDo,
                    Priority = 3,
                    ProjectId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09")
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Name = "Investigate how to integrate Identity Server",
                    Description = "",
                    Status = TaskStatus.ToDo,
                    Priority = 1,
                    ProjectId = Guid.Parse("d28888e9-2ba9-474a-a40f-e38cb54f9b35")
                });
        }
    }
}
