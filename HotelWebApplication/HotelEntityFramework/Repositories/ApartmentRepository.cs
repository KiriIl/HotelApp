using HotelEntityFramework.Models;

namespace HotelEntityFramework.Repositories
{
    class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(MyContext context) : base(context) {}
    }
}