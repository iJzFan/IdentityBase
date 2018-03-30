#if DEBUG

namespace IdentityBase.EntityFramework.MySql
{
    using System.Reflection;
    using IdentityBase.EntityFramework.Configuration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// DesignTimeDbContextFactory required for the EF Migration tools 
    /// </summary>
    public class DesignTimeDbContextFactory :
        IDesignTimeDbContextFactory<MigrationDbContext>
    {
        public MigrationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MigrationDbContext> dbBuilder
                = new DbContextOptionsBuilder<MigrationDbContext>();

            string connString =
                "Server=192.168.99.251;database=identitybase;uid=root;pwd=123.abc;";

            string migrationsAssembly = typeof(DesignTimeDbContextFactory)
                .GetTypeInfo().Assembly.GetName().Name;

            dbBuilder.UseMySql(connString,
                o => o.MigrationsAssembly(migrationsAssembly));

            var options = new EntityFrameworkOptions();

            return new MigrationDbContext(dbBuilder.Options, options);
        }
    }
}

#endif
