namespace DatabaseApp.Models
{
	public class TodoModel
	{
		public int Id { get; set; }
		public string Username { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public bool IsDone { get; set; } = false;

		public DateTime TargetDate { get; set; }
	}
}
