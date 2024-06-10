using Microsoft.EntityFrameworkCore;

namespace MirTechTest.Models;

public class ApplicationContext : DbContext
{
	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
		Database.EnsureCreated();
	}
	
	public DbSet<Staff> Staffs { get; set; }
}