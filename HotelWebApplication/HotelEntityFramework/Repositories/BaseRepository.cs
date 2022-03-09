using HotelEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelEntityFramework.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected DbSet<T> dbSet;
        protected MyContext context;

        public BaseRepository(MyContext context)
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
    }
}