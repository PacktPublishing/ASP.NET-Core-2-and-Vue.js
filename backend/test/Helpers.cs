using backend.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace test
{
    public static class Helpers
    {
        public static ApplicationDbContext GetDbContext(params object[] seedData)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;

            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();
            if (seedData != null && seedData.Length > 0)
            {
                context.AddRange(seedData);
                context.SaveChanges();
            }
            return context;
        }
    }
}