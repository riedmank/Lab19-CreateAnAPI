using CreateAnAPI.Data;
using CreateAnAPI.Models;
using System;
using Xunit;
using static CreateAnAPI.Program;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Tests that a Todo can be Created
        /// </summary>
        [Fact]
        public async void CanCreateTodo()
        {
            DbContextOptions<TodoDbContext> options =
                new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase("GetTodoName")
                .Options;

            using (TodoDbContext context = new TodoDbContext(options))
            {
                Todo task = new Todo();
                task.Title = "test";

                context.Todos.Add(task);
                context.SaveChanges();

                var taskTitle = await context.Todos.FirstOrDefaultAsync(x => x.Title == task.Title);

                Assert.Equal("test", taskTitle.Title);
            }
        }

        /// <summary>
        /// Tests that a Todo can be Read
        /// </summary>
        [Fact]
        public async void CanReadTodo()
        {
            DbContextOptions<TodoDbContext> options =
                new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase("GetTodoName")
                .Options;

            using (TodoDbContext context = new TodoDbContext(options))
            {
                Todo task = new Todo();
                task.Title = "test";

                context.Todos.Add(task);
                context.SaveChanges();

                var taskTitle = await context.Todos.FirstOrDefaultAsync(x => x.Title == task.Title);

                Assert.Equal("test", taskTitle.Title);
            }
        }

        /// <summary>
        /// Tests that a Todo can be Updated
        /// </summary>
        [Fact]
        public async void CanUpdateTodo()
        {
            DbContextOptions<TodoDbContext> options =
                new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase("GetTodoName")
                .Options;

            using (TodoDbContext context = new TodoDbContext(options))
            {
                Todo task = new Todo();
                task.Title = "test";

                context.Todos.Add(task);
                context.SaveChanges();

                task.Title = "update";

                context.Todos.Update(task);
                context.SaveChanges();

                var taskTitle = await context.Todos.FirstOrDefaultAsync(x => x.Title == task.Title);

                Assert.Equal("update", taskTitle.Title);
            }
        }

        /// <summary>
        /// Tests that a Todo can be Deleted
        /// </summary>
        [Fact]
        public async void CanDeleteTodo()
        {
            DbContextOptions<TodoDbContext> options =
                new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase("GetTodoName")
                .Options;

            using (TodoDbContext context = new TodoDbContext(options))
            {
                Todo task = new Todo();
                task.Title = "test";

                context.Todos.Add(task);
                context.SaveChanges();

                context.Todos.Remove(task);
                context.SaveChanges();

                var taskTitle = await context.Todos.ToListAsync();

                Assert.DoesNotContain(task, taskTitle);
            }
        }        

        /// <summary>
        /// Tests that a TodoList can be Created
        /// </summary>
        [Fact]
        public async void CanCreateAList()
        {
            DbContextOptions<TodoDbContext> options =
                new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase("GetTodoListName")
                .Options;

            using (TodoDbContext context = new TodoDbContext(options))
            {
                TodoList list = new TodoList();
                list.ListTitle = "test";

                context.TodoLists.Add(list);
                context.SaveChanges();

                var listContents = await context.TodoLists.FirstOrDefaultAsync(x => x.ListTitle == list.ListTitle);

                Assert.Equal("test", listContents.ListTitle);
            }
        }

        /// <summary>
        /// Tests that a TodoList can be Read
        /// </summary>
        [Fact]
        public async void CanReadAList()
        {
            DbContextOptions<TodoDbContext> options =
                new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase("GetTodoListName")
                .Options;

            using (TodoDbContext context = new TodoDbContext(options))
            {
                TodoList list = new TodoList();
                list.ListTitle = "test";

                context.TodoLists.Add(list);
                context.SaveChanges();

                var listContents = await context.TodoLists.FirstOrDefaultAsync(x => x.ListTitle == list.ListTitle);

                Assert.Equal("test", listContents.ListTitle);
            }
        }

        /// <summary>
        /// Tests that a TodoList can be Updated
        /// </summary>
        [Fact]
        public async void CanUpdateAList()
        {
            DbContextOptions<TodoDbContext> options =
                new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase("GetTodoListName")
                .Options;

            using (TodoDbContext context = new TodoDbContext(options))
            {
                TodoList list = new TodoList();
                list.ListTitle = "test";

                context.TodoLists.Add(list);
                context.SaveChanges();

                list.ListTitle = "update";

                context.TodoLists.Update(list);
                context.SaveChanges();

                var listContents = await context.TodoLists.FirstOrDefaultAsync(x => x.ListTitle == list.ListTitle);

                Assert.Equal("update", listContents.ListTitle);
            }
        }

        /// <summary>
        /// Tests that a TodoList can be Deleted
        /// </summary>
        [Fact]
        public async void CanDeleteAList()
        {
            DbContextOptions<TodoDbContext> options =
                new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase("GetTodoListName")
                .Options;

            using (TodoDbContext context = new TodoDbContext(options))
            {
                TodoList list = new TodoList();
                list.ListTitle = "test";

                context.TodoLists.Add(list);
                context.SaveChanges();

                context.TodoLists.Remove(list);
                context.SaveChanges();

                var listContents = await context.TodoLists.ToListAsync();

                Assert.DoesNotContain(list, listContents);
            }
        }

        /// <summary>
        /// Tests that a Todo can be Added to a TodoList
        /// </summary>
        [Fact]
        public async void CanAddToAList()
        {
            DbContextOptions<TodoDbContext> options =
                new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase("GetTodoListName")
                .Options;

            using (TodoDbContext context = new TodoDbContext(options))
            {
                TodoList list = new TodoList();
                list.Todoes = new List<Todo>();
                list.ListTitle = "test";

                Todo task = new Todo();
                task.Title = "test";

                list.Todoes.Add(task);

                context.TodoLists.Add(list);
                context.SaveChanges();

                var listContents = await context.TodoLists.FirstOrDefaultAsync(x => x.ListTitle == list.ListTitle);

                Assert.Contains(task, listContents.Todoes);
            }
        }

        /// <summary>
        /// Tests that a Todo can be Removed from a TodoList
        /// </summary>
        [Fact]
        public async void CanRemoveFromAList()
        {
            DbContextOptions<TodoDbContext> options =
                new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase("GetTodoListName")
                .Options;

            using (TodoDbContext context = new TodoDbContext(options))
            {
                TodoList list = new TodoList();
                list.Todoes = new List<Todo>();

                Todo task = new Todo();
                task.Title = "test";

                list.Todoes.Add(task);
                list.Todoes.Remove(task);

                context.TodoLists.Add(list);
                context.SaveChanges();

                var listContents = await context.TodoLists.FirstOrDefaultAsync(x => x.ListTitle == list.ListTitle);

                Assert.DoesNotContain(task, listContents.Todoes);
            }
        }
    }
}
