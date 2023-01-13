using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieService.AsyncDataServices;
using MovieService.Data;
using MovieService.Dtos;
using MovieService.Models;
using MovieService.SyncDataServices.Http;

namespace MovieService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepo _repository;
        private readonly IMapper _mapper;
        private readonly ITicketDataClient _ticketDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public MoviesController(
            IMovieRepo repository, 
            IMapper mapper,
            ITicketDataClient ticketDataClient,
            IMessageBusClient messageBusClient)
        {
            _repository = repository;
            _mapper = mapper;
            _ticketDataClient = ticketDataClient;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieReadDto>> GetMovies()
        {
            Console.WriteLine("--> Getting Movies....");

            var MovieItem = _repository.GetAllMovies();

            return Ok(_mapper.Map<IEnumerable<MovieReadDto>>(MovieItem));
        }

        [HttpGet("{id}", Name = "GetMovieById")]
        public ActionResult<MovieReadDto> GetMovieById(int id)
        {
            var MovieItem = _repository.GetMovieById(id);
            if (MovieItem != null)
            {
                return Ok(_mapper.Map<MovieReadDto>(MovieItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<MovieReadDto>> CreateMovie(MovieCreateDto MovieCreateDto)
        {
            var MovieModel = _mapper.Map<Movie>(MovieCreateDto);
            _repository.CreateMovie(MovieModel);
            _repository.SaveChanges();

            var MovieReadDto = _mapper.Map<MovieReadDto>(MovieModel);

            // Send Sync Message
            try
            {
                await _ticketDataClient.SendMovieToTicket(MovieReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            //Send Async Message
            try
            {
                var MoviePublishedDto = _mapper.Map<MoviePublishedDto>(MovieReadDto);
                MoviePublishedDto.Event = "Movie_Published";
                _messageBusClient.PublishNewMovie(MoviePublishedDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetMovieById), new { Id = MovieReadDto.Id}, MovieReadDto);
        }
    }
}