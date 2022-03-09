using HotelEntityFramework.Models;

namespace HotelEntityFramework.Repositories
{
    class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(MyContext context) : base(context) {}
    }
}