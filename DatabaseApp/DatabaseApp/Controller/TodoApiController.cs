using DatabaseApp.Data;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 모든 Todo List 반환
        [HttpGet]
        public async Task<ActionResult<List<TodoModel>>> GetTodos()
        {
            var todos = await _context.GetTodoModels.ToListAsync();

            if (todos == null || !todos.Any())
            {
                return NotFound("No todos found");
            }

            return Ok(todos);
        }

        // 특정 사용자에 맞는 Todo List 반환
        [HttpGet("users/{username}")]
        public async Task<ActionResult<List<TodoModel>>> GetTodosByUsername(string username)
        {
            var todos = await _context.GetTodoModels
                                       .Where(todo => todo.Username == username)
                                       .ToListAsync();

            if (todos == null || !todos.Any())
            {
                return NotFound($"No todos found for user {username}");
            }

            return Ok(todos);
        }

        [HttpPost]
        public async Task<ActionResult<TodoModel>> CreateTodo(TodoModel todo)
        {
            _context.GetTodoModels.Add(todo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodos), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, TodoModel todo)
        {
            if (id != todo.Id) return BadRequest();

            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _context.GetTodoModels.FindAsync(id);
            if (todo == null) return NotFound();

            _context.GetTodoModels.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }


}
