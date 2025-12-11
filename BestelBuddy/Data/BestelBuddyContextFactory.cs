using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BestelBuddy.Data
{
    public class BestelBuddyContextFactory : IDesignTimeDbContextFactory<BestelBuddyContext>
    {
        public BestelBuddyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BestelBuddyContext>();
            optionsBuilder.UseSqlite("Data Source=bestelbuddy.db");

            return new BestelBuddyContext(optionsBuilder.Options);
        }
    }
}
