using EF_DBContext_Internal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF_DBContext_Internal
{
    internal class Program
    {

        public static string GetConnectionStr()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("AppSetting.json")
                .Build();
            return config.GetSection("SqlConnectionStr").Value ?? "";
        }
        static void Main(string[] args)
        {

            using (AppDBContext context = new AppDBContext())
            {


                foreach (var item in context.Book)
                {
                    Console.WriteLine(item);
                }

            }





            //DBContextExternal();
            //DBContextDepndencyInjection();
            //DBContextFactory();




        }

        /// <summary>
        /// using DBContextOptionsBuilder
        /// </summary>
        public static void DBContextExternal()
        {
            var OpBuilder = new DbContextOptionsBuilder();
            OpBuilder.UseSqlServer(GetConnectionStr());

            var option = OpBuilder.Options;


            using (AppDBContext context = new AppDBContext(option))
            {

                foreach (var book in context.Book)
                {
                    Console.WriteLine(book.ToString());
                }

            }
        }
        /// <summary>
        /// Using Dependency Injection
        /// </summary>
        public static void DBContextDepndencyInjection()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<AppDBContext>(op => op.UseSqlServer(GetConnectionStr()));

            IServiceProvider provider = services.BuildServiceProvider();

            using (var context = provider.GetService<AppDBContext>())
            {
                foreach (var item in context!.Book)
                {
                    Console.WriteLine(item);
                }


            }


        }
        /// <summary>
        /// using DBCOntext Factory
        /// </summary>
        public static void DBContextFactory()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContextFactory<AppDBContext>
                (optionBuilder => optionBuilder.UseSqlServer(GetConnectionStr()));

            IServiceProvider provider = services.BuildServiceProvider();

            IDbContextFactory<AppDBContext>? AppContextFactory = provider.GetService<IDbContextFactory<AppDBContext>>();

            using (AppDBContext context = AppContextFactory!.CreateDbContext())
            {
                foreach (var item in context.Book)
                {
                    Console.WriteLine(item);
                }

            }

        }
    }
}
