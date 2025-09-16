using INDWalks.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.API.Data
{
    public class INDWalksDbContext: DbContext
    {
        public INDWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {

        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Regions> Regions { get; set; }

        public DbSet<Walks> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = 1,
                    Name="Easy"
                },
                new Difficulty()
                {
                    Id = 2,
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = 3,
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }

    }
}
