using AutoMapper;
using EssoOtomationProject.DTOs;
using EssoOtomationProject.Models;

namespace EssoOtomationProject.Mappers
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<RegisterDto, User>().ReverseMap();
        }
    }
}
