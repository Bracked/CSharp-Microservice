using AutoMapper;
using CardsService.Data;
using Microsoft.AspNetCore.Mvc;
using TicketService.Dtos;

namespace TicketsService.Controllers
{
    [Route("api/t/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase 
    {
        private readonly ICardRepo _repository;
        private readonly IMapper _mapper;

        public MoviesController(ICardRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

       [HttpGet]
        public ActionResult<IEnumerable<MovieReadDto>> GetMovies()
        {
            Console.WriteLine("--> Getting Movies from CommandsService");

            var movieItem = _repository.GetAllMovies();

            return Ok(_mapper.Map<IEnumerable<MovieReadDto>>(movieItem));
        }


        public ActionResult TestInboundConnection(){
            Console.WriteLine("--> Inbound Post # Ticket Service");
            return Ok("Inbound test of from  Movies Contoller");

        }
    }
}