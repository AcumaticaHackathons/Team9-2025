#region #Copyright

// ----------------------------------------------------------------------------------
//   COPYRIGHT (c) 2025 CONTOU CONSULTING
//   ALL RIGHTS RESERVED
//   AUTHOR: Kyle Vanderstoep
//   CREATED DATE: 2025/01/25
// ----------------------------------------------------------------------------------

#endregion

using PX.Data;
using PX.Data.BQL.Fluent;

namespace LS.EfficiencyMonitor
{
    public class MonitorSetupMaint : PXGraph<MonitorSetupMaint>
    {
        public PXCancel<AlertPreferences>        Cancel;
        public PXSave<AlertPreferences>          Save;
        public SelectFrom<AlertPreferences>.View Form;
    }
}