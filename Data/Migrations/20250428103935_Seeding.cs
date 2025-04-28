using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations;

/// <inheritdoc />
public partial class Seeding : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.InsertData(
			table: "Orders",
			columns: ["Id", "Customer"],
			values: new object[,]
			{
				{ 1, "BMW" },
				{ 2, "Mercedes" },
				{ 3, "FIAT" }
			});

		migrationBuilder.InsertData(
			table: "OrderItems",
			columns: ["Id", "OrderId", "Name", "Quantity", "Price"],
			values: new object[,]
			{
				{ 1, 1, "Gear", 1000, 1.5001M },
				{ 2, 1, "Pedal", 1, 15001M },
				{ 3, 2, "Gear", 1000, 1.7001M },
				{ 4, 2, "Pedal", 1, 17001M },
				{ 5, 3, "Spoiler", 12.34M, 12.34M },
				{ 6, 3, "Sticker", 34.12M, 34.12M },
			});
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{

	}
}
