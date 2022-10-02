using AutoMapper;
using EssoOtomationProject.DTOs;
using EssoOtomationProject.Models;

namespace EssoOtomationProject.Mappers
{
    public class LoginProfile:Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginDto, User>();
        }
    }
}
