using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.DAL.Repositories.IRepositories;
using System.Collections.Generic;

namespace HotelBooking.BLL.Services
{
    public class NotificationService : INotificationService
    {
        private IMapper _mapper;
        private INotificationRepository _notificationRepository;

        public NotificationService(
            IMapper mapper,
            INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        public List<NotificationDTO> GetNotificationsByUserId(long id)
        {
            return _mapper.Map<List<NotificationDTO>>(_notificationRepository.GetByUser(id));
        }
    }
}