using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelBooking.DAL.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected DbSet<T> dbSet;
        protected HotelBookingDbContext context;

        public BaseRepository(HotelBookingDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public virtual T Get(long id)
        {
            return dbSet.SingleOrDefault(x => x.Id == id);
        }

        public virtual void Save(T model)
        {
            if (model.Id > 0)
            {
                dbSet.Update(model);
            }
            else
            {
                dbSet.Add(model);
            }

            context.SaveChanges();
        }

        public virtual void Remove(T model)
        {
            context.Remove(model);
            context.SaveChanges();
        }

        public virtual void Remove(long id)
        {
            var model = Get(id);
            Remove(model);
        }
    }
}