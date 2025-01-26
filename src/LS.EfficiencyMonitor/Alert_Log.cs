using System;
using LS.EfficiencyMonitor;
using PX.Data;

namespace LS.EfficiencyMonitor
{
    public class Alert_Log : PXGraph<Alert_Log>
    {

        public PXSave<MasterTable> Save;
        public PXCancel<MasterTable> Cancel;
        public PXFilter<MasterTable> MasterView;

        [PXFilterable]
        public PXSelectOrderBy<AlertLog, OrderBy<Desc<AlertLog.createdDateTime>>> DetailsView;

        [Serializable]
        [PXCacheName("Master Table")]
        public class MasterTable : PXBqlTable, IBqlTable
        {
            #region StartDate
            public abstract class startDate : PX.Data.BQL.BqlDateTime.Field<startDate> { }

            [PXDBDate(PreserveTime = true, DisplayMask = "d")]
            [PXUIField(DisplayName = "Start Date")]
            public virtual DateTime? StartDate { get; set; }
            #endregion

            #region EndDate
            public abstract class endDate : PX.Data.BQL.BqlDateTime.Field<endDate> { }
            [PXDefault(typeof(AccessInfo.businessDate))]
            [PXDBDate(PreserveTime = true, DisplayMask = "d")]
            [PXUIField(DisplayName = "End Date")]
            public virtual DateTime? EndDate { get; set; }
            #endregion
        }
    }
}