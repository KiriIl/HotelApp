using HotelBooking.DAL.Models;

namespace HotelBooking.DAL.Repositories
{
    class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(MyContext context) : base(context) {}
    }
}