using HotelBooking.BLL.Services.IServices;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Threading.Tasks;

namespace HotelBooking.BLL.Quartz
{
    public class NotificationJob : IJob
    {
        private IServiceScopeFactory _serviceProvider;

        public NotificationJob(IServiceScopeFactory serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<INotificationService>();

                service.UpdateNotifications();

                return Task.CompletedTask;
            }
        }
    }
}