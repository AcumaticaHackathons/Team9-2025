using System.Collections;
using System.Linq;
using CommonServiceLocator;
using LS.EfficiencyMonitor;
using Microsoft.Extensions.Hosting;
using PX.Data;
using PX.Objects.CR;
using PX.Objects.EP;
using PX.SM;

namespace PX.Objects.SO
{
    public class SOOrderEntry_Extension : PXGraphExtension<PX.Objects.SO.SOOrderEntry>
    {
        public static bool IsActive() => true;

        public PXSelectOrderBy<AlertLog, OrderBy<Desc<AlertLog.createdDateTime>>> logs;

        [PXCopyPasteHiddenView]
        public PXFilter<PopUpFilter> PopUpFilter;

        #region Actions

        public PXAction<SOOrder> ReportDelay;

        [PXUIField(DisplayName = "Report Delay", MapEnableRights = PXCacheRights.Select,
            MapViewRights = PXCacheRights.Select)]
        [PXButton(CommitChanges = true, DisplayOnMainToolbar = false)]
        [PXProcessButton]
        protected virtual IEnumerable reportDelay(PXAdapter adapter)
        {
            if (PopUpFilter.AskExt() != WebDialogResult.OK) return adapter.Get();

            PXLongOperation.StartOperation(this, () =>
            {
                Alert_Log logGraph = PXGraph.CreateInstance<Alert_Log>();
                LogStatus(logGraph);

                SendNotificationEmail(logGraph);
            });

            return adapter.Get();
        }

        private static void SendNotificationEmail(Alert_Log logGraph)
        {
            var      erpTrans         = logGraph.LicenseTran.SelectMain();
            CpuUtilizationMonitorService monitor =
                ServiceLocator.Current.GetInstance<IHostedService>(nameof(CpuUtilizationMonitorService)) as
                    CpuUtilizationMonitorService;
            CpuUsage              cpuUsage              = monitor.GetLast15MinutesCpu();
            NotificationGenerator notificationGenerator = new();
            notificationGenerator.To      = "kyle@contou.com";
            notificationGenerator.Subject = "Users Are Reporting Delays in Responsiveness";
            string body = "<html>"                                                                        +
                          "<body>"                                                                        +
                          "<h2>User Experience Degraded</h2>"                                             +
                          "<p><strong>Threshold Reached:</strong> User Reports in the last 5 minutes</p>" +
                          "<hr>"                                                                          +
                          "<p>Users have been reporting delays in the Acumatica Application.</p>"         +
                          "<p>Over the last 15 minutes:</p>"                                              +
                          "<hr>"                                                                          +
                          $"<p><strong>Average CPU Utilization:</strong> {cpuUsage.AvgUsage}</p>"         +
                          $"<p><strong>Max CPU Utilization:</strong> {cpuUsage.MaxUsage}</p>"             +
                          $"<p><strong>Min CPU Utilization:</strong> {cpuUsage.MinUsage}</p>"             +
                          "<br>"                                                                          +
                          "<p><strong>ERP Transactions in the Last 5 Minutes:</strong></p>"               +
                          "<ul>";

            foreach (var tranGroup in erpTrans.GroupBy(g => g.TransactionType + "," + g.ScreenID + "," + g.ActionName))
            {
                string[] splits = tranGroup.Key.Split(',');
                body +=
                    $"<li><strong>Transaction Type:</strong> {splits[0]} | <strong>Screen ID:</strong> {splits[1]} | <strong>Action Name:</strong> {splits[2]} | <strong>Transaction Count:</strong> {tranGroup.Sum(g => g.TranCount.GetValueOrDefault())}</li>";
            }

            body += "</ul>"                                                                              +
                    "<br>"                                                                               +
                    "<p><strong>Long running transactions when this incident was recorded:</strong></p>" +
                    "<ul>";

            foreach (SMPerformanceInfo process in logGraph.CurrentProcesses.SelectMain())
                body +=
                    $"<li><strong>Screen ID:</strong> {process.UrlToScreen} | <strong>User:</strong> {process.UserId} | <strong>Run Time (ms):</strong> {process.RequestCpuTimeMs}</li>";

            var cause                  = string.Empty;
            int apiTransactions        = erpTrans.Count(t => t.TransactionType == "A");
            int uiTransactions         = erpTrans.Count(t => t.TransactionType == "U");
            int backgroundTransactions = erpTrans.Count(t => t.TransactionType == "S");

            if (apiTransactions        > 0) cause += " (API Transactions)";
            if (uiTransactions         > 0) cause += " (UI Transactions)";
            if (backgroundTransactions > 0) cause += " (Background Processes)";

            body += "</ul>"                                          +
                    "<br>"                                           +
                    $"<p><strong>Likely Cause:</strong> {cause}</p>" +
                    "</body>"                                        +
                    "</html>";


            notificationGenerator.Body = body;
            foreach (CRSMEmail log in notificationGenerator.Send())
            {
            }
        }

        #endregion

        private static void LogStatus(Alert_Log logGraph)
        {
            AlertLog log = new()
            {
                USERID     = logGraph.Accessinfo.UserName,
                Status     = 0,
                StatusDesc = ""
            };

            logGraph.DetailsView.Insert(log);
            logGraph.Save.Press();
        }
    }
}