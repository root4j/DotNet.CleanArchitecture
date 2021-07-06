using Microsoft.EntityFrameworkCore;

namespace DotNet.CleanArchitecture.Model.Tests.Common
{
    public class TestDbContext
    {

        public static AppDbContext GetDatabase(string databaseName)
        {
            var connection = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: databaseName)
                    .Options);
            return connection;
        }
    }
}