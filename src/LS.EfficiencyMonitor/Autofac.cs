using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
