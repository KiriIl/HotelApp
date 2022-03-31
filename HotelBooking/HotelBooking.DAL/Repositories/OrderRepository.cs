using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;

namespace HotelBooking.DAL.Repositories
{
    class OrderRepository : BaseRepository<Booking>, IOrderRepository
    {
        public OrderRepository(HotelBookingDbContext context) : base(context) {}
    }
}