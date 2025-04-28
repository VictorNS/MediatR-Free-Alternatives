using Data;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
optionsBuilder
	.UseSqlServer("server=(local); database=MyContext; Integrated Security=true; Encrypt=false")
	.EnableSensitiveDataLogging()
	.LogTo(message => System.Diagnostics.Debug.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Debug);

using var context = new MyContext(optionsBuilder.Options);
await context.Database.MigrateAsync();
