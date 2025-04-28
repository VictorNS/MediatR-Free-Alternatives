using System.Text.Json.Serialization;

namespace Data.Models;

public class OrderItem
{
	public int Id { get; set; }
	public int OrderId { get; set; }
	public string Name { get; set; } = null!;
	public decimal Quantity { get; set; }
	public decimal Price { get; set; }

	[JsonIgnore]
	public virtual Order Order { get; set; } = null!;
}
