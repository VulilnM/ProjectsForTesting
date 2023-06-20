using UserService.Models;

namespace UserService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }

        private static void SeedData(AppDbContext appDbContext)
        {
            if(!appDbContext.Users.Any())
            {
                Console.WriteLine("---> Seeding data...");

                appDbContext.Users.AddRange(
                    new User() {UserId=12345, UserName="vulinmb", Name="Zoran", LastName="Jovanovic"},
                    new User() {UserId=12346, UserName="vulinmc", Name="Bojan", LastName="Srtefanovic"},
                    new User() {UserId=12347, UserName="vulinmd", Name="Dusan", LastName="Vulin"},
                    new User() {UserId=12348, UserName="vulinmg", Name="Dragan", LastName="Rakic"},
                    new User() {UserId=12349, UserName="vulinmh", Name="Jovan", LastName="Mikic"}
                );
            }
            else
            {
                Console.WriteLine("---> We already have data!");
            }
        }
    }
}