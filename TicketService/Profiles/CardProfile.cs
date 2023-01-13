using AutoMapper;
using TicketService.Dtos;
using TicketService.Models;

namespace TicketService.Profiles
{
    public class CardProfile:Profile 
    {
        public CardProfile()
        {
            CreateMap<Movie,MovieReadDto>();
            CreateMap<Card,CardReadDto>();
            CreateMap<CardReadDto,Card>();


        }
    }
}
