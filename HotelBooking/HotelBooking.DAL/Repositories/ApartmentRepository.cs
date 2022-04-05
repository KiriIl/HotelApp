using AutoMapper;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace HotelBooking.DAL.Repositories
{
    public class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        private IMapper _mapper;
        public ApartmentRepository(
            HotelBookingDbContext context,
            IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public override Apartment Get(long id)
        {
            var apartment = dbSet.Select(x => new Apartment
            {
                Id = x.Id,
                Cost = x.Cost,
                Info = x.Info,
                RoomsCount = x.RoomsCount,
                RoomType = x.RoomType,
            }).SingleOrDefault();

            return apartment;
        }

        public List<ApartmentDataModel> GetAll()
        {
            return _mapper.Map<List<ApartmentDataModel>>(dbSet.ToList());
        }
    }
}