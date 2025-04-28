namespace Data.Models;

public class OrderRequest
{
	public int Id { get; set; }
	public string Customer { get; set; } = null!;
	public decimal ExpectedRevenue { get; set; }
	public int ExpirationYear { get; set; }

	public OrderRequestMetaData MetaData { get; set; } = null!;


}

public class OrderRequestMetaData
{
	public DateOnly CreatedAt { get; set; }
	public OrderRequestMetaDataUser? Contact { get; set; }
}

public class OrderRequestMetaDataUser
{
	public string Email { get; set; } = "";
	public string Phone { get; set; } = "";
}
