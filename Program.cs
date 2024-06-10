using Microsoft.EntityFrameworkCore;
using MirTechTest.Models;

namespace MirTechTest;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		//Определяем контекст и подключение к бд
		builder.Services.AddDbContext<ApplicationContext>(options =>
		{
			//TODO: Раскомментировать строчку ниже, когда будет работать MSSQL и закомментировать UseInMemory
			//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			options.UseInMemoryDatabase("MirTechTest");
		});
		// Add services to the container.

		builder.Services.AddControllersWithViews();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();
		app.UseRouting();


		app.MapControllerRoute(
			name: "default",
			pattern: "{controller}/{action=Index}/{id?}");

		app.MapFallbackToFile("index.html");

		app.Run();
	}
}