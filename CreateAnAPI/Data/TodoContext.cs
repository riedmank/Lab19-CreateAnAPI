using CreateAnAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateAnAPI.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoList>().HasData(
                new TodoList
                {
                    ID = 1,
                    ListTitle = "tasks",
                    Todoes = new List<Todo>()
                });

            modelBuilder.Entity<Todo>().HasData(
                new Todo
                {
                    ID = 1,
                    Title = "write code",
                    IsDone = false,
                    TodoListID = 1
                },
                new Todo
                {
                    ID = 2,
                    Title = "squish the cat",
                    IsDone = true,
                    TodoListID = 1
                },
                new Todo
                {
                    ID = 3,
                    Title = "wash dishes",
                    IsDone = false,
                    TodoListID = 1
                });
        }
    }
}
