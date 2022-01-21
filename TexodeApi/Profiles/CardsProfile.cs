using AutoMapper;
using TexodeApi.Dtos;
using TexodeApi.Models;

namespace TexodeApi.Profiles
{
    public class CardsProfile : Profile
    {
        public CardsProfile()
        {
            CreateMap<Card, CardReadDto>();
            CreateMap<CardCreateDto, Card>();
            CreateMap<CardUpdateDto, Card>();
            CreateMap<Card, CardUpdateDto>();
        }
    }
}