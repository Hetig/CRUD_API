using CRUD_API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CRUD_API.Database
{
	public class AppDbContext:DbContext
	{
		public DbSet<Resident> Residents;
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Get, "http://testlodtask20172.azurewebsites.net/task");
			request.Headers.Add("Cookie", "ARRAffinity=214d255fc28990f631f4a021400d47570fb2a2a87cf88d7ee26b1d13b99029fa");
			var response = client.Send(request);
			response.EnsureSuccessStatusCode();
			var jsonString = response.Content.ReadAsStringAsync().Result;

			var residents = JsonConvert.DeserializeObject<List<Resident>>(jsonString);
			modelBuilder.Entity<Resident>().HasData(residents);
		}
	}
}
