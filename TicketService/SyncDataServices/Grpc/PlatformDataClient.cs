// using System;
// using System.Collections.Generic;
// using AutoMapper;
// using CommandsService.Models;
// using Grpc.Net.Client;
// using Microsoft.Extensions.Configuration;
// using MovieService;

// namespace CommandsService.SyncDataServices.Grpc
// {
//     public class MovieDataClient : IMovieDataClient
//     {
//         private readonly IConfiguration _configuration;
//         private readonly IMapper _mapper;

//         public MovieDataClient(IConfiguration configuration, IMapper mapper)
//         {
//             _configuration = configuration;
//             _mapper = mapper;
//         }

//         public IEnumerable<Movie> ReturnAllMovies()
//         {
//             Console.WriteLine($"--> Calling GRPC Service {_configuration["GrpcMovie"]}");
//             var channel = GrpcChannel.ForAddress(_configuration["GrpcMovie"]);
//             var client = new GrpcMovie.GrpcMovieClient(channel);
//             var request = new GetAllRequest();

//             try
//             {
//                 var reply = client.GetAllMovies(request);
//                 return _mapper.Map<IEnumerable<Movie>>(reply.Movie);
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"--> Couldnot call GRPC Server {ex.Message}");
//                 return null;
//             }
//         }
//     }
// }