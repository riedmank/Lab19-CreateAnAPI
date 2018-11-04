using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CreateAnAPI.Data;
using CreateAnAPI.Models;

namespace CreateAnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : Controller
    {
        private readonly TodoDbContext _context;

        public TodoListsController(TodoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all TodoLists
        /// </summary>
        /// <returns>Returns all Todo Lists</returns>
        [HttpGet]
        public IEnumerable<TodoList> GetTodoLists()
        {
            return _context.TodoLists;
        }

        /// <summary>
        /// Gets a specific TodoList
        /// </summary>
        /// <param name="id">TodoList ID</param>
        /// <returns>Returns TodoList</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoList = await _context.TodoLists.FindAsync(id);

            if (todoList == null)
            {
                return NotFound();
            }

            return Ok(todoList);
        }

        /// <summary>
        /// Updates TodoList
        /// </summary>
        /// <param name="id">TodoList ID</param>
        /// <param name="todoList">Updated TodoList</param>
        /// <returns>Returns nothing</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList([FromRoute] int id, [FromBody] TodoList todoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoList.ID)
            {
                return BadRequest();
            }

            _context.Entry(todoList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a TodoList
        /// </summary>
        /// <param name="todoList">TodoList to be Created</param>
        /// <returns>Returns TodoList that was Created</returns>
        [HttpPost]
        public async Task<IActionResult> PostTodoList([FromBody] TodoList todoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TodoLists.Add(todoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoList", new { id = todoList.ID }, todoList);
        }

        /// <summary>
        /// Deletes TodoList
        /// </summary>
        /// <param name="id">TodoList ID</param>
        /// <returns>Returns Ok</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }

            _context.TodoLists.Remove(todoList);
            await _context.SaveChangesAsync();

            return Ok(todoList);
        }

        private bool TodoListExists(int id)
        {
            return _context.TodoLists.Any(e => e.ID == id);
        }
    }
}