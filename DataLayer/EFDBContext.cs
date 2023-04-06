using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class EFDBContext : DbContext
	{
		public DbSet<Entities.Directory> Directory { get; set; }
		public DbSet<Entities.Material> Material { get; set; }

		public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) {  }
	}
}

