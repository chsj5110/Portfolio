namespace DatabaseApp.Models
{
	public class OrderModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Price { get; set; } = string.Empty;
		public string Category { get; set; } = string.Empty;

		public DateTime OrderDate { get; set; }
	}
}
