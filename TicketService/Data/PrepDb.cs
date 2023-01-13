using System;
using System.Collections.Generic;
using TicketService.Models;
// using CardsService.SyncDataServices.Grpc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CardsService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // var grpcClient = serviceScope.ServiceProvider.GetService<IMovieDataClient>();

                // var Movies = grpcClient.ReturnAllMovies();

                // SeedData(serviceScope.ServiceProvider.GetService<ICardRepo>(), Movies);
            }
        }
        
        private static void SeedData(ICardRepo repo, IEnumerable<Movie> Movies)
        {
            Console.WriteLine("Seeding new Movies...");

            foreach (var plat in Movies)
            {
                if(!repo.ExternalMovieExists(plat.ExternalID))
                {
                    repo.CreateMovie(plat);
                }
                repo.SaveChanges();
            }
        }
    }
}