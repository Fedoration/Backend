using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationLaputin.DbContextBases;
using WebApplicationLaputin.Repositories;

namespace WebApplicationLaputin.BackgroundServices
{
    public class ValuesGenerator : BackgroundService
    {
        private readonly IServiceProvider services;

        public ValuesGenerator(IServiceProvider services)
        {
            this.services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            while (true)
            {
                try
                {
                    using var scope = services.CreateScope();

                    var valveRepository = scope.ServiceProvider.GetRequiredService<ValveRepository>();
                    var valve = valveRepository.GetAll().FirstOrDefault();

                    var consumptionSensorRepository = scope.ServiceProvider.GetRequiredService<SensorRepository>();
                    await consumptionSensorRepository.ChangeValue(1, (valve?.Value ?? 0) * 100);

                    await Task.Delay(10000);
                }
                catch (Exception ex)
                {
                }
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            await base.StopAsync(stoppingToken);
        }
    }
}
