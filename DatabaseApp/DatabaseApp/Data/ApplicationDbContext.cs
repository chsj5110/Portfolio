using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DatabaseApp.Models;
using System.Reflection.Emit;

namespace DatabaseApp.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			/*builder.Entity<OrderModel>(entity =>
			{
				entity.HasKey(e => e.Id);
			});*/

			// 문자열 데이터 타입 변경 (nvarchar -> varchar)
			foreach (var property in builder.Model.GetEntityTypes()
				.SelectMany(t => t.GetProperties())
				.Where(p => p.ClrType == typeof(string)))
			{
				// MySQL에서는 varchar(255)로 기본 설정 변경
				property.SetColumnType("varchar(255)");
			}

		}

		public DbSet<OrderModel> GetOrderModels { get; set; } = null!;

		public DbSet<TodoModel> GetTodoModels { get; set; } = null!;
	}

}
