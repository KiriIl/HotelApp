﻿using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;

namespace HotelBooking.DAL.Repositories
{
    class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(MyContext context) : base(context) {}
    }
}