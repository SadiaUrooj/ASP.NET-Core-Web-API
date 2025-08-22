using NZWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext //inherets from the DbContext class
    {
        //defining the constructor
        //passing the DbContextOptions as later On we want to pass our own connections through the Program.cs
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        //DbSets: collection of entities in the dtabase
        //all of these properties represents our collections in the database
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }


        //Seeding 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed the data for difficulties
            //Easy, Medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("ed7bbcd4-ca54-4749-8b3e-3c8b79c09a4f"),
                    Name="Easy"
                },
                 new Difficulty()
                {
                    Id = Guid.Parse("bd5d44d6-a676-4d3d-8a85-6e2a2e4fd3ac"),
                    Name="Medium"
                },
                  new Difficulty()
                {
                    Id = Guid.Parse("2ad7ea2d-88b2-4edb-9bf1-9d25e09e2bd8"),
                    Name="Hard"
                }
            };

            //Seed difficulities to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("cb4edee6-7438-451b-8aaa-b2346645a39c"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://image.pexels.com/photos/auckland"
                },
                new Region
                {
                    Id = Guid.Parse("66909005-8015-406b-8018-bf84cae00995"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://image.pexels.com/photos/nelson"
                },
                 new Region
                {
                    Id = Guid.Parse("278f3905-dfe6-4504-854f-60aeaf7c9d41"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://image.pexels.com/photos/wellington"
                }
            };


            //insert the regions data inside the region table
            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
