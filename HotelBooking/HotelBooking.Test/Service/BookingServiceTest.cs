using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Repositories.IRepositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HotelBooking.Test.Service
{
    class BookingServiceTest
    {
        private BookingService _bookingService;
        private Mock<IBookingRepository> _mockBookingRepository;
        private Mock<INotificationRepository> _mockNotificationRepository;
        private Mock<IMapper> _mockMapper;
        private BookingDataModel booking1;
        private BookingDataModel booking2;


        [SetUp]
        public void Setup()
        {
            _mockBookingRepository = new Mock<IBookingRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockNotificationRepository = new Mock<INotificationRepository>();
            _bookingService = new BookingService(_mockMapper.Object, _mockBookingRepository.Object,_mockNotificationRepository.Object);

            booking1 = new BookingDataModel
            {
                Id = 1,
                Apartment = new ApartmentDataModel() { Id = 1 },
                //01.04.2022 09:00
                ArrivalDate = new DateTime(2022, 4, 1, 9, 0, 0),
                //08.01.2022 06.00
                DepartureDate = new DateTime(2022, 4, 8, 6, 0, 0),
            };

            booking2 = new BookingDataModel
            {
                Id = 2,
                Apartment = new ApartmentDataModel() { Id = 1 },
                //15.04.2022 09:00
                ArrivalDate = new DateTime(2022, 4, 15, 9, 0, 0),
                //22.04.2022 06:00
                DepartureDate = new DateTime(2022, 4, 22, 6, 0, 0),
            };
        }

        [Test]
        [TestCase("2022-03-30 9:00:00", "2022-04-01 6:00:00")]
        [TestCase("2022-04-08 9:00:00", "2022-04-15 6:00:00")]
        [TestCase("2022-04-22 9:00:00", "2022-04-27 6:00:00")]
        public void ApartmentIsEmpty_ReturnTrue(DateTime arrivalDate, DateTime departureDate)
        {
            var bookingDTO = new BookingDTO
            {
                Apartment = new ApartmentDTO() { Id = 1 },
                ArrivalDate = arrivalDate,
                DepartureDate = departureDate,
            };

            var bookingDataModel = new BookingDataModel()
            {
                Apartment = new ApartmentDataModel() { Id = 1 },
                ArrivalDate = bookingDTO.ArrivalDate,
                DepartureDate = bookingDTO.DepartureDate,
            };

            List<BookingDataModel> list = new List<BookingDataModel>() { booking1, booking2 };

            _mockBookingRepository.Setup(x => x.GetReservationsByApartmentId(1)).Returns(list);

            _mockMapper.Setup(x => x.Map<BookingDataModel>(bookingDTO)).Returns(bookingDataModel);

            var result = _bookingService.BookingApartment(bookingDTO);

            Assert.AreEqual(result, true);
        }

        [Test]
        [TestCase("2022-03-30 9:00:00", "2022-04-02 6:00:00")]
        [TestCase("2022-04-07 9:00:00", "2022-04-15 6:00:00")]
        [TestCase("2022-04-07 9:00:00", "2022-04-16 6:00:00")]
        [TestCase("2022-04-21 9:00:00", "2022-04-27 6:00:00")]
        [TestCase("2022-04-02 9:00:00", "2022-04-05 6:00:00")]
        [TestCase("2022-04-14 9:00:00", "2022-04-23 6:00:00")]
        [TestCase("2022-04-15 9:00:00", "2022-04-22 6:00:00")]
        public void ApartmentIsNotEmty_ReturnsFalse(DateTime arrivalDate, DateTime departureDate)
        {
            var bookingDTO = new BookingDTO
            {
                Apartment = new ApartmentDTO() { Id = 1 },
                ArrivalDate = arrivalDate,
                DepartureDate = departureDate,
            };

            var bookingDataModel = new BookingDataModel()
            {
                Apartment = new ApartmentDataModel() { Id = 1 },
                ArrivalDate = bookingDTO.ArrivalDate,
                DepartureDate = bookingDTO.DepartureDate,
            };

            List<BookingDataModel> list = new List<BookingDataModel>() { booking1, booking2 };

            _mockBookingRepository.Setup(x => x.GetReservationsByApartmentId(1)).Returns(list);

            _mockMapper.Setup(x => x.Map<BookingDataModel>(bookingDTO)).Returns(bookingDataModel);

            var result = _bookingService.BookingApartment(bookingDTO);

            Assert.AreEqual(result, false);
        }
    }
}