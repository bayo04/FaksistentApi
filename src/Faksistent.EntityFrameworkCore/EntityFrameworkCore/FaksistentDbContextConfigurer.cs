using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Faksistent.EntityFrameworkCore
{
    public static class FaksistentDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FaksistentDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FaksistentDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
