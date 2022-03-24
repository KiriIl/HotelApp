using HotelBooking.DAL.Models;

namespace HotelBooking.DAL.Repositories.IRepositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        T Get(long id);
        void Save(T model);
    }
}