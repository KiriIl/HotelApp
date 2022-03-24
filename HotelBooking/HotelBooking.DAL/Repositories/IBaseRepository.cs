using HotelBooking.DAL.Models;

namespace HotelBooking.DAL.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        T Get(long id);
        void Save(T model);
    }
}