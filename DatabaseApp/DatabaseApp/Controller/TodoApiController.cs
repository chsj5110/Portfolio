using DatabaseApp.Data;
using DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace TodoApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TodosController : ControllerBase
	{
		private readonly IConfiguration _config;

		public TodosController(IConfiguration config)
		{
			_config = config;
		}

		[HttpGet]
		public async Task<ActionResult<List<TodoModel>>> GetTodos()
		{
			var todos = new List<TodoModel>();
			using (MySqlConnection conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection")))
			{
				MySqlCommand cmd = new MySqlCommand("GetTodos", conn);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				await conn.OpenAsync();
				using (var reader = await cmd.ExecuteReaderAsync())
				{
					while (await reader.ReadAsync())
					{
						todos.Add(new TodoModel
						{
							Id = reader.GetInt32("Id"),
							Username = reader.GetString("Username"),
							Description = reader.GetString("Description"),
							IsDone = reader.GetBoolean("IsDone"),
							TargetDate = reader.GetDateTime("TargetDate")
						});
					}
				}
			}
			return Ok(todos);
		}

		[HttpGet("users/{username}")]
		public async Task<ActionResult<List<TodoModel>>> GetTodosByUsername(string username)
		{
			var todos = new List<TodoModel>();
			using (MySqlConnection conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection")))
			{
				MySqlCommand cmd = new MySqlCommand("GetTodosByUsername", conn);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@username_param", username);
				await conn.OpenAsync();
				using (var reader = await cmd.ExecuteReaderAsync())
				{
					while (await reader.ReadAsync())
					{
						todos.Add(new TodoModel
						{
							Id = reader.GetInt32("Id"),
							Username = reader.GetString("Username"),
							Description = reader.GetString("Description"),
							IsDone = reader.GetBoolean("IsDone"),
							TargetDate = reader.GetDateTime("TargetDate")
						});
					}
				}
			}
			return Ok(todos);
		}

		[HttpPost]
		public async Task<ActionResult<TodoModel>> CreateTodo(TodoModel todo)
		{
			using (MySqlConnection conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection")))
			{
				MySqlCommand cmd = new MySqlCommand("CreateTodo", conn);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@username_param", todo.Username);
				cmd.Parameters.AddWithValue("@description_param", todo.Description);
				cmd.Parameters.AddWithValue("@isdone_param", todo.IsDone);
				cmd.Parameters.AddWithValue("@targetdate_param", todo.TargetDate);

				await conn.OpenAsync();
				await cmd.ExecuteNonQueryAsync();
			}
			return CreatedAtAction(nameof(GetTodos), new { id = todo.Id }, todo);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateTodo(int id, TodoModel todo)
		{
			using (MySqlConnection conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection")))
			{
				MySqlCommand cmd = new MySqlCommand("UpdateTodo", conn);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id_param", id);
				cmd.Parameters.AddWithValue("@username_param", todo.Username);
				cmd.Parameters.AddWithValue("@description_param", todo.Description);
				cmd.Parameters.AddWithValue("@isdone_param", todo.IsDone);
				cmd.Parameters.AddWithValue("@targetdate_param", todo.TargetDate);

				await conn.OpenAsync();
				await cmd.ExecuteNonQueryAsync();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTodo(int id)
		{
			using (MySqlConnection conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection")))
			{
				MySqlCommand cmd = new MySqlCommand("DeleteTodo", conn);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id_param", id);

				await conn.OpenAsync();
				await cmd.ExecuteNonQueryAsync();
			}
			return NoContent();
		}
	}
}
