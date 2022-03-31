using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Repositories.IRepositories;

namespace HotelBooking.BLL.Services
{
    public class BookingService : IBookingService
    {
        private IMapper _mapper;
        private IBookingRepository _bookingRepository;

        public BookingService(
            IMapper mapper,
            IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }
        public void BookingApartment(BookingDTO booking)
        {
            //check for occupation
            _bookingRepository.Save(_mapper.Map<BookingDataModel>(booking));
        }
    }
}