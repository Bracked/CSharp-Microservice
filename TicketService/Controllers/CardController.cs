using System;
using System.Collections.Generic;
using AutoMapper;
using CardsService.Data;
using Microsoft.AspNetCore.Mvc;
using TicketService.Dtos;
using TicketService.Models;

namespace TicketService.Controllers
{
    [Route("api/t/movies/{movieId}/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardRepo _repository;
        private readonly IMapper _mapper;

        public CardsController(ICardRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CardReadDto>> GetCardsForMovie(int MovieId)
        {
            Console.WriteLine($"--> Hit GetCardsForMovie: {MovieId}");

            if (!_repository.MovieExits(MovieId))
            {
                return NotFound();
            }

            var Cards = _repository.GetCardsForMovie(MovieId);

            return Ok(_mapper.Map<IEnumerable<CardReadDto>>(Cards));
        }

        [HttpGet("{cardId}", Name = "GetCardForMovie")]
        public ActionResult<CardReadDto> GetCardForMovie(int MovieId, int CardId)
        {
            Console.WriteLine($"--> Hit GetCardForMovie: {MovieId} / {CardId}");

            if (!_repository.MovieExits(MovieId))
            {
                return NotFound();
            }

            var Cards = _repository.GetCard(MovieId, CardId);

            if(Cards == null)
            {
                return NotFound();
            }
            

            return Ok(_mapper.Map<CardReadDto>(Cards));
        }

        [HttpPost]
        public ActionResult<CardReadDto> CreateCardForMovie(int MovieId, CardCreateDto CardDto)
        {
             Console.WriteLine($"--> Hit CreateCardForMovie: {MovieId}");

            if (!_repository.MovieExits(MovieId))
            {
                return NotFound();
            }

            var card = _mapper.Map<Card>(CardDto);

            _repository.CreateCard(MovieId, card);
            _repository.SaveChanges();

            var CardReadDto = _mapper.Map<CardReadDto>(card);

            return CreatedAtRoute(nameof(GetCardForMovie),
                new {MovieId = MovieId, CardId = CardReadDto.Id}, CardReadDto);
        }

    }


}