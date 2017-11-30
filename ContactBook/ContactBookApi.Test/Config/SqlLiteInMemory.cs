using ContactBookApi.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ContactBookApi.Test.Config
{
    public class SqlLiteInMemory
    {
        //https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/sqlite
        //https://github.com/JonPSmith/EfCoreInAction/tree/Chapter04
        public static ContactBookContext GetTestContext()
        {
            var context = new ContactBookContext(CreateDbContextOptions<ContactBookContext>());
            context.Database.EnsureCreated();
            return context;
        }

        private static DbContextOptions<T> CreateDbContextOptions<T>() where T: DbContext
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            connection.Open();

            var builder = new DbContextOptionsBuilder<T>()
                .UseSqlite(connection)
                .Options;

            return builder;
        }
    }
}
