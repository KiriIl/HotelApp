using AutoMapper;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;

namespace HotelBooking.DAL.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        private IMapper _mapper;

        public BookingRepository(
            HotelBookingDbContext context,
            IMapper mapper) : base(context) 
        {
            _mapper = mapper;
        }

        public void Save(BookingDataModel bookingDataModel)
        {
            var bookingModel = _mapper.Map<Booking>(bookingDataModel);
            Save(bookingModel);
        }
    }
}