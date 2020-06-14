using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Module;

namespace ToDoApp.Core
{
    /// <summary>
    /// ToDo Db上下文
    /// </summary>
    public class ToDoContext : DbContext
    {
        private string databasePath;

        public ToDoContext(string databasePath)
        {
            this.databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

        public DbSet<Checklist> Checklists { get; set; }

        public DbSet<ChecklistDetail> ChecklistDetails { get; set; }
    }
}
