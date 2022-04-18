using HotelBooking.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.BLL.Quartz
{
    public class QuartzJobRunner : IJob
    {
        private readonly IServiceScopeFactory serviceProvider;

        public QuartzJobRunner(IServiceScopeFactory serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var jobType = context.JobDetail.JobType;
                var job = scope.ServiceProvider.GetRequiredService(jobType) as IJob;

                await job.Execute(context);
            }
        }
    }
}