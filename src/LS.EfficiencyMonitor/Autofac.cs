using Autofac;
using Microsoft.Extensions.Hosting;

namespace LS.EfficiencyMonitor
{
    public class EfficiencyAutofac  : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register MyHostedService as IHostedService
            builder.RegisterType<CpuUtilizationMonitorService>()
                   .As<IHostedService>()
                   .SingleInstance();  // This makes it singleton, adjust as needed
        }
    }
}
