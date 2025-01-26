using PX.Data;

namespace LS.EfficiencyMonitor
{
    [PXCacheName("Rating Selection")]
    [PXVirtual]
    public class PopUpFilter : PXBqlTable, IBqlTable
    {
        #region Rating
        public abstract class rating : PX.Data.BQL.BqlString.Field<rating> { }
        [PXIntList(new int[] { 0, 1, 2 }, new string[] { "Low Impact", "Medium Impact", "High Impact" })]
        [PXDefault(0)]
        [PXUIField(DisplayName = "Rating", Visible = true)]
        [PXIntAttribute]
        public virtual int? Rating { get; set; }
        #endregion
    }
}
