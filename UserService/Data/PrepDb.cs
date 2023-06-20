using UserService.Models;

namespace UserService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }

        private static void SeedData(AppDbContext appDbContext)
        {
            if (!appDbContext.Users.Any())
            {
                Console.WriteLine("---> Seeding data...");

                appDbContext.Users.AddRange(
                    new User() { UserId = 12345, UserName = "vulinmb", Password = "test123", Name = "Zoran", LastName = "Jovanovic" },
                    new User() { UserId = 12346, UserName = "vulinmc", Password = "test123", Name = "Bojan", LastName = "Srtefanovic" },
                    new User() { UserId = 12347, UserName = "vulinmd", Password = "test123", Name = "Dusan", LastName = "Vulin" },
                    new User() { UserId = 12348, UserName = "vulinmg", Password = "test123", Name = "Dragan", LastName = "Rakic" },
                    new User() { UserId = 12349, UserName = "vulinmh", Password = "test123", Name = "Jovan", LastName = "Mikic" }
                );

                appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> We already have data!");
            }
        }
    }
}