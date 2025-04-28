using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public partial class MyContext : DbContext
{
	public MyContext()
	{
	}

	public MyContext(DbContextOptions<MyContext> options) : base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
#if DEBUG
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer("server=(local); database=MyContext; Integrated Security=true; Encrypt=false");
		}
#endif
	}

	public virtual DbSet<Order> Orders { get; set; } = null!;
	public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
	public virtual DbSet<OrderRequest> OrderRequests { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Order>(entity =>
		{
			entity.Property(e => e.CreatedAt).HasDefaultValueSql("getutcdate()");
		});

		modelBuilder.Entity<OrderItem>(entity =>
		{
			entity.Property(e => e.Quantity).HasColumnType("decimal(19, 4)");
			entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");

			entity.HasOne(d => d.Order).WithMany(p => p.Items)
				.HasForeignKey(d => d.OrderId)
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_OrderItems_Orders");
		});

		modelBuilder.Entity<OrderRequest>(entity =>
		{
			entity.Property(e => e.ExpectedRevenue).HasColumnType("decimal(20, 4)");
			entity.OwnsOne(e => e.MetaData, builder =>
			{
				builder.ToJson();
				builder.OwnsOne(m => m.Contact);
			});
		});
	}
}
