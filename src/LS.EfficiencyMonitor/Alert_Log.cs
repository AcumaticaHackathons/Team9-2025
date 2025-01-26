using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Data.Licensing.SM;
using PX.SM;

namespace LS.EfficiencyMonitor
{
    public class Alert_Log : PXGraph<Alert_Log>
    {
        public PXSave<AlertLog>      Save;
        public PXCancel<AlertLog>    Cancel;

        [PXFilterable]
        public PXSelectOrderBy<AlertLog, OrderBy<Desc<AlertLog.createdDateTime>>> DetailsView;

        public SelectFrom<SMLicenseERPTranDetailsAction>.View LicenseTran;

        protected IEnumerable licenseTran()
        {
            return SelectFrom<SMLicenseERPTranDetailsAction>
                  .Where<SMLicenseERPTranDetailsAction.date.IsLessEqual<P.AsDateTime>>.View.Select(this,
                       DateTime.UtcNow.AddMinutes(-5));
        }

        public SelectFrom<SMPerformanceInfo>.View CurrentProcesses;

        protected IEnumerable currentProcesses()
        {
            Type performanceMonitorType = typeof(PXPerformanceMonitor);

            // Get the SamplesInProgress property using reflection
            PropertyInfo samplesInProgressProperty =
                performanceMonitorType.GetProperty("SamplesInProgress", BindingFlags.Public | BindingFlags.Static);

            // Ensure that the property is not null and is accessible
            if (samplesInProgressProperty != null)
            {
                // Get the value of SamplesInProgress (this assumes it's static, otherwise you'd need an instance)
                object samplesInProgress = samplesInProgressProperty.GetValue(null); // null for static property

                // Now, you need to reflect over the KeysExt method
                MethodInfo keysExtMethod = samplesInProgress.GetType().GetMethod("KeysExt");

                // Ensure the method is found
                if (keysExtMethod != null)
                {
                    // Invoke the KeysExt method
                    object keysExtResult = keysExtMethod.Invoke(samplesInProgress, null); // Pass parameters if needed

                    // Now, you should be able to process the result further as needed, for example:
                    var orderedList = ((IEnumerable<PXPerformanceInfo>)keysExtResult)
                                     .OrderByDescending(info => info.StartTime)
                                     .ToList();
                    return orderedList;
                }
            }

            return Array.Empty<PXPerformanceInfo>();
        }
    }
}