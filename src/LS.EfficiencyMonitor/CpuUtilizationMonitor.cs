﻿using Microsoft.Extensions.Hosting;
using PX.SM;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace LS.EfficiencyMonitor
{
    public class CpuUtilizationMonitorService : IHostedService
    {
        private Timer _monitoringTimer;
        private readonly List<int> _cpuUtilizationHistory = new(MaxHistorySize);
        private const int MaxHistorySize = 3600;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _monitoringTimer = new Timer(GetUtilization, _cpuUtilizationHistory,2000,2000);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _monitoringTimer.Dispose();
        }

        public void GetUtilization(object state)
        {
            List<int> history = (List<int>)state;
            // Get the type of PXPerformanceMonitor
            Type type = typeof(PXPerformanceMonitor);

            // Get the internal static property 'CPUUtilization' using reflection
            PropertyInfo propertyInfo = type.GetProperty("CPUUtilization", BindingFlags.NonPublic | BindingFlags.Static);

            if (propertyInfo != null)
            {
                // Get the value of the property
                object value = propertyInfo.GetValue(null); // For static properties, pass null for the object parameter

                // Assuming the property is of type int, cast the value to int
                int cpuUtilization = (int)value;
                if (history.Count == MaxHistorySize)
                {
                    history.RemoveAt(0);
                }
                history.Add(cpuUtilization);
            }
            else
            {
                throw new Exception("Property 'CPUUtilization' not found.");
            }
        }
    }
}
