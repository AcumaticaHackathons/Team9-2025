using LS.EfficiencyMonitor;
using PX.Data;
using System.Collections;

namespace PX.Objects.SO
{
    public class SOOrderEntry_Extension : PXGraphExtension<PX.Objects.SO.SOOrderEntry>
    {
        public static bool IsActive() => true;

        public PXSelectOrderBy<AlertLog, OrderBy<Desc<AlertLog.createdDateTime>>> logs;

        #region Actions
        public PXAction<SOOrder> ReportDelay;
        [PXUIField(DisplayName = "Report Delay", MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select)]
        [PXButton(CommitChanges = true, DisplayOnMainToolbar = false)]
        [PXProcessButton]
        protected virtual IEnumerable reportDelay(PXAdapter adapter)
        {
            LogStatus();
            
            return adapter.Get();
        }
        #endregion

        private void LogStatus()
        {
            Alert_Log logGraph = PXGraph.CreateInstance<Alert_Log>();

            AlertLog log = new AlertLog
            {
                USERID = Base.Accessinfo.UserName,
                Status = 0,
                StatusDesc = "",              
            };

            logGraph.DetailsView.Insert(log);
            logGraph.Persist();
        }
    }
}