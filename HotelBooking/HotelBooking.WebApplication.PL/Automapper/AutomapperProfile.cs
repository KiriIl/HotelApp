using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using HotelBooking.WebApplication.PL.Models;

namespace HotelBooking.WebApplication.PL.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDataModel>().ReverseMap();
            CreateMap<UserDTO, UserDataModel>().ReverseMap();
            CreateMap<UserDTO, RegistrationViewModel>().ReverseMap();
        }
    }
}