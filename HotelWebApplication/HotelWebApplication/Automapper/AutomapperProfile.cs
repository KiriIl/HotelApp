using AutoMapper;
using HotelBLL.DTOModels;
using HotelEntityFramework.Models;
using HotelWebApplication.Models;

namespace HotelWebApplication.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, RegistrationViewModel>().ReverseMap();
        }
    }
}