using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieService.Models;

namespace MovieService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if(isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }
            
            if(!context.Movies.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Movies.AddRange(
                    new Movie() {Name="Rambo", DeveloperCompany="Carolco Picture", TicketCost="4$"},
                    new Movie() {Name="Titanic", DeveloperCompany="Paramount Pictures",  TicketCost="10$"},
                    new Movie() {Name="Terminator", DeveloperCompany="Pacific Western Productions",  TicketCost="7$"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}