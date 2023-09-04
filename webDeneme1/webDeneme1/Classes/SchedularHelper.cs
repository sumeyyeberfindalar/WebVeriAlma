using Quartz;
using Quartz.Impl;
using WebVeriAlma.Pages.Classes;

namespace WebVeriAlma.Classes
{
    public static class SchedularHelper
    {
        public static async void SchedulerInMinute()
        {
            var _scheduler = await new StdSchedulerFactory().GetScheduler();
            await _scheduler.Start();

            var getHtmlofPageJob = JobBuilder.Create<GetHtmlJob>()
                .WithIdentity("ShowDateTimeJob")
                .Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("ShowDateTimeJob")
                .StartNow()
                .WithSimpleSchedule(builder => builder.WithIntervalInMinutes(1).RepeatForever()) //.WithCronSchedule("*/1 * * * *")
                .Build();

            var result = await _scheduler.ScheduleJob(getHtmlofPageJob, trigger);
    
        }
        public static async void SchedulerInOneHour()
        {
            var _scheduler = await new StdSchedulerFactory().GetScheduler();
            await _scheduler.Start();

            var getHtmlofPageJob = JobBuilder.Create<GetHtmlJob>()
                .WithIdentity("ShowDateTimeJob")
                .Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("ShowDateTimeJob")
                .StartNow()
                .WithSimpleSchedule(builder => builder.WithIntervalInHours(1).RepeatForever()) //.WithCronSchedule("*/1 * * * *")
                .Build();

            var result = await _scheduler.ScheduleJob(getHtmlofPageJob, trigger);

        }
        public static async void SchedulerInThreeHours()
        {
            var _scheduler = await new StdSchedulerFactory().GetScheduler();
            await _scheduler.Start();

            var getHtmlofPageJob = JobBuilder.Create<GetHtmlJob>()
                .WithIdentity("ShowDateTimeJob")
                .Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("ShowDateTimeJob")
                .StartNow()
                .WithSimpleSchedule(builder => builder.WithIntervalInHours(3).RepeatForever()) //.WithCronSchedule("*/1 * * * *")
                .Build();

            var result = await _scheduler.ScheduleJob(getHtmlofPageJob, trigger);

        }
        public static async void SchedulerInDay()
        {
            var _scheduler = await new StdSchedulerFactory().GetScheduler();
            await _scheduler.Start();

            var getHtmlofPageJob = JobBuilder.Create<GetHtmlJob>()
                .WithIdentity("ShowDateTimeJob")
                .Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("ShowDateTimeJob")
                .StartNow()
                .WithSimpleSchedule(builder => builder.WithIntervalInHours(24).RepeatForever()) //.WithCronSchedule("*/1 * * * *")
                .Build();

            var result = await _scheduler.ScheduleJob(getHtmlofPageJob, trigger);

        }
    }
}
