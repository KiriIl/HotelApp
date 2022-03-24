using HotelBooking.DAL.Models;

namespace HotelBooking.DAL.Repositories
{
    class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(MyContext context) : base(context) {}
    }
}