using Hangfire;
using SignalAppTrial.Application.Abstract;
using SignalAppTrial.Model.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalAppTrial.Application.BackgroundJobs.Schedules
{
    public static class ReccuringJobs
    {
        public static void GetAll(AppConfig appConfig)
        {
            var cron = appConfig.GetCron;
            RecurringJob.AddOrUpdate<ICoinGeckoService>(nameof(ICoinGeckoService), job => job.GetAll(), cron, TimeZoneInfo.Local);
        }
    }
}
