using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;
using System.Collections.Generic;

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

        public ApartmentDTO Get(long id)
        {
            return _mapper.Map<ApartmentDTO>(_mapper.Map<ApartmentDataModel>(_apartmentRepository.Get(id)));
        }

        public List<ApartmentDTO> GetAllApartments()
        {
            return _mapper.Map<List<ApartmentDTO>>(_apartmentRepository.GetAll());
        }
    }
}