using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.DAL.Models;
using HotelBooking.WebApplication.PL.Models;

namespace HotelBooking.WebApplication.PL.Automapper
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