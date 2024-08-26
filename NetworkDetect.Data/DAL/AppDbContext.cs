using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetworkDetect.Core.Entities;

namespace NetworkDetect.Data.DAL;

public class AppDbContext : IdentityDbContext<AppUser>
{
	public AppDbContext(DbContextOptions options) : base(options) { }

	public DbSet<Image> Images { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Cart> Carts { get; set; }
}
