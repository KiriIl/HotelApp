using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Threading.Tasks;

namespace HotelBooking.BLL.Quartz
{
    public class QuartzJobRunner : IJob
    {
        private IServiceScopeFactory _serviceProvider;

        public QuartzJobRunner(IServiceScopeFactory serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var jobType = context.JobDetail.JobType;
                var job = scope.ServiceProvider.GetRequiredService(jobType) as IJob;

                await job.Execute(context);
            }
        }
    }
}