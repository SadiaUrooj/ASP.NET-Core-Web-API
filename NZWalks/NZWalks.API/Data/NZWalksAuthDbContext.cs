using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //seeding the data into the db
            var readerRoleId = "23183c8f-f0a0-42da-969c-6df221262e58";
            var writerRoleId = "a278cb2f-e6a9-48cc-aff1-9e29d9ec92bb";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id =readerRoleId,
                    ConcurrencyStamp= readerRoleId,
                    Name = "Reader",
                    NormalizedName= "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id =writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name = "Writer",
                    NormalizedName= "Writer".ToUpper()
                }
            };
            //now seeding the roles too the builder object
            //HasData to provide the list of the data
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
