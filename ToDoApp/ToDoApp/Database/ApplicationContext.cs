using System;

using Microsoft.EntityFrameworkCore;
using ToDoApp.Helpers;
using ToDoApp.Models;

namespace ToDoApp.Database
{
    public class ApplicationContext : DbContext
    {
        private readonly string _databasePath;

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ToDoItem>(entity =>
                {
                    entity.Property(x => x.Status)
                    .HasConversion(
                        v => v.ToString(),
                        v => (ToDoStatus)Enum.Parse(typeof(ToDoStatus), v));

                    entity.ToTable(Constants.ToDoItems)
                    .HasKey(x => x.Id);
                });
        }
    }
}
