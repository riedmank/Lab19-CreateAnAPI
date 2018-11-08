using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CreateAnAPI.Data;

namespace CreateAnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoesController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TodoesController(TodoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Todos
        /// </summary>
        /// <returns>Returns Todos</returns>
        [HttpGet]
        public IEnumerable<Todo> GetTodos()
        {
            var result = _context.Todos;
            return result;
        }

        /// <summary>
        /// Gets specific Todo
        /// </summary>
        /// <param name="id">Todo ID</param>
        /// <returns>Returns Todo</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        /// <summary>
        /// Updates Todo
        /// </summary>
        /// <param name="id">Todo ID</param>
        /// <param name="todo">Todo Update information</param>
        /// <returns>Returns nothing</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo([FromRoute] int id, [FromBody] Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todo.ID)
            {
                return BadRequest();
            }

            _context.Entry(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
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
        /// Creates a Todo
        /// </summary>
        /// <param name="todo">Todo to be Created</param>
        /// <returns>Returns Todo that was Created</returns>
        [HttpPost]
        public async Task<IActionResult> PostTodo([FromBody] Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodo", new { id = todo.ID }, todo);
        }

        /// <summary>
        /// Deletes a Todo
        /// </summary>
        /// <param name="id">Todo ID</param>
        /// <returns>Returns Ok</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        private bool TodoExists(int id)
        {
            return _context.Todos.Any(e => e.ID == id);
        }
    }
}