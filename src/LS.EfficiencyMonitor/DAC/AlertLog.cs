/*
 * Developer: VG
 * Tracking ID: BMI-3561
 * Description: Created
 */

using PX.Data;
using System;

namespace LS.EfficiencyMonitor
{
    [PXCacheName("User Alert Log")]
    public class AlertLog : PXBqlTable, IBqlTable
    {
        #region USERID
        [PXDBString(15, IsUnicode = true)]
        [PXUIField(DisplayName = "User ID", Enabled = false)]
        public virtual string USERID { get; set; }
        public abstract class userID : PX.Data.BQL.BqlString.Field<userID> { }
        #endregion

        #region Status
        [PXDBInt()]
        [PXUIField(DisplayName = "Status", Enabled = false)]
        public virtual int? Status { get; set; }
        public abstract class status : PX.Data.BQL.BqlInt.Field<status> { }
        #endregion

        #region StatusDesc
        public abstract class statusDesc : PX.Data.BQL.BqlString.Field<statusDesc> { }
        protected String _StatusDesc;
        [PXDBString(1, IsFixed = true)]
        [PXUIField(DisplayName = "Status", Enabled = false)]
        [PXIntList(new int[] { 1, 2 }, new string[] { "Success", "Error" })]
        public virtual String StatusDesc { get; set; }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime(IsKey = true, PreserveTime = true, InputMask = "g")]
        [PXUIField(DisplayName = "Date/Time", Enabled = false)]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region Noteid
        [PXNote()]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
        #endregion
    }
}