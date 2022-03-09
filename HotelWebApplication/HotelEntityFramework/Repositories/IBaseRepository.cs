using HotelEntityFramework.Models;

namespace HotelEntityFramework.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        T Get(long id);
        void Save(T model);
    }
}