using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;

namespace HotelBooking.BLL.Services
{
    public class ApartmentService : IApartmentService
    {
        private IMapper _mapper;
        private IApartmentRepository _apartmentRepository;

        public ApartmentService(
            IMapper mapper,
            IApartmentRepository apartmentRepository)
        {
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
        }

        public void CreateApartment(ApartmentDTO apartment)
        {
            var apartmentDM = _mapper.Map<ApartmentDataModel>(apartment);
            _apartmentRepository.Save(_mapper.Map<Apartment>(apartmentDM));
        }
    }
}