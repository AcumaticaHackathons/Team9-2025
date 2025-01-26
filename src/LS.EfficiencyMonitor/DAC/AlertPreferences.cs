using System;
using PX.Data;
using PX.Data.BQL;
using PX.SM;

namespace LS.EfficiencyMonitor;

[PXCacheName("User Alert Preferences")]
[Serializable]
public class AlertPreferences : PXBqlTable, IBqlTable
{
    #region AlertBasedOnUserReport

    [PXDBBool]
    [PXUIField(DisplayName = "Alert Based on User Report")]
    public virtual bool? AlertBasedOnUserReport { get; set; }

    public abstract class alertBasedOnUserReport : BqlBool.Field<alertBasedOnUserReport>
    {
    }

    #endregion

    #region UserReportThreshold

    [PXDBInt]
    [PXUIField(DisplayName = "User Report Threshold")]
    public virtual int? UserReportThreshold { get; set; }

    public abstract class userReportThreshold : BqlInt.Field<userReportThreshold>
    {
    }

    #endregion

    #region UserReportThresholdTime

    [PXDBInt]
    [PXUIField(DisplayName = "User Report Threshold Time")]
    public virtual int? UserReportThresholdTime { get; set; }

    public abstract class userReportThresholdTime : BqlInt.Field<userReportThresholdTime>
    {
    }

    #endregion

    #region AlertBasedOnUtilization

    [PXDBBool]
    [PXUIField(DisplayName = "Alert Based on Utilization")]
    public virtual bool? AlertBasedOnUtilization { get; set; }

    public abstract class alertBasedOnUtilization : BqlBool.Field<alertBasedOnUtilization>
    {
    }

    #endregion

    #region CpuThreshold

    [PXDBInt]
    [PXUIField(DisplayName = "Cpu Threshold")]
    public virtual int? CpuThreshold { get; set; }

    public abstract class cpuThreshold : BqlInt.Field<cpuThreshold>
    {
    }

    #endregion

    #region CpuThresholdTime

    [PXDBInt]
    [PXUIField(DisplayName = "Cpu Threshold Time")]
    public virtual int? CpuThresholdTime { get; set; }

    public abstract class cpuThresholdTime : BqlInt.Field<cpuThresholdTime>
    {
    }

    #endregion

    #region NotificationTemplateID

    [PXDBInt]
    [PXSelector(typeof(Notification.notificationID), DescriptionField = typeof(Notification.name))]
    [PXUIField(DisplayName = "User Experience Issue Notification Template ID")]
    public virtual int? NotificationTemplateID { get; set; }

    public abstract class notificationTemplateID : BqlInt.Field<notificationTemplateID>
    {
    }

    #endregion
}