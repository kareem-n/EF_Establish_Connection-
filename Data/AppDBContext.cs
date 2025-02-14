using EF_DBContext_Internal.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF_DBContext_Internal.Data
{
    internal class AppDBContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions OP) : base(OP)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfigurationRoot config = new ConfigurationBuilder()
                                        .AddJsonFile("AppSetting.json")
                                        .Build();

            string connStr = config.GetSection("SqlConnectionStr").Value ?? "";

            optionsBuilder.UseSqlServer(connStr);
        }


    }
}
