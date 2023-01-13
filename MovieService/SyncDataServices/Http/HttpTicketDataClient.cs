using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MovieService.Dtos;

namespace MovieService.SyncDataServices.Http
{
    public class HttpTicketDataClient : ITicketDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpTicketDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }


        public async Task SendMovieToTicket(MovieReadDto plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5113/api/t/movies/", httpContent);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to TicketService was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync POST to TicketService was NOT OK!");
            }
        }
    }
}