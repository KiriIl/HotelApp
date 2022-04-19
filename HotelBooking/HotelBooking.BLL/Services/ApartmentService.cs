using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.DAL.DataModels;
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

        public void SaveApartment(ApartmentDTO apartment)
        {
            var apartmentDM = _mapper.Map<ApartmentDataModel>(apartment);
            _apartmentRepository.Save(apartmentDM);
        }

        public ApartmentDTO Get(long apartmentId)
        {
            return _mapper.Map<ApartmentDTO>(_apartmentRepository.Get(apartmentId));
        }

        public List<ApartmentDTO> GetAllApartments()
        {
            return _mapper.Map<List<ApartmentDTO>>(_apartmentRepository.GetAll());
        }
    }
}