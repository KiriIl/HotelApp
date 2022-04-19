using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBooking.BLL.Quartz
{
    public class QuartzHostedService : IHostedService
    {
        public IScheduler Scheduler { get; set; }

        private ISchedulerFactory _schedulerFactory;
        private IJobFactory _jobFactory;
        private IEnumerable<JobSchedule> _jobSchedules;

        public QuartzHostedService(
            ISchedulerFactory schedulerFactory,
            IJobFactory jobFactory,
            IEnumerable<JobSchedule> jobSchedules)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _jobSchedules = jobSchedules;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;

            foreach (var jobSchedule in _jobSchedules)
            {
                var job = CreateJob(jobSchedule);
                var trigger = CreateTrigger(jobSchedule);

                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }

            await Scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler?.Shutdown(cancellationToken);
        }

        private ITrigger CreateTrigger(JobSchedule jobSchedule)
        {
            return TriggerBuilder
                .Create()
                .WithIdentity($"{jobSchedule.JobType.FullName}.trigger")
                .WithCronSchedule(jobSchedule.CronExpression)
                .WithDescription(jobSchedule.CronExpression)
                .Build();
        }

        private IJobDetail CreateJob(JobSchedule jobSchedule)
        {
            var jobType = jobSchedule.JobType;
            return JobBuilder
                .Create(jobType)
                .WithIdentity(jobType.FullName)
                .WithDescription(jobType.Name)
                .Build();
        }
    }
}