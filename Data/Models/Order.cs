namespace Data.Models;

public class Order
{
	public int Id { get; set; }
	public string Customer { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<OrderItem> Items { get; set; } = [];
}
