#region #Copyright

// ----------------------------------------------------------------------------------
//   COPYRIGHT (c) 2025 CONTOU CONSULTING
//   ALL RIGHTS RESERVED
//   AUTHOR: Kyle Vanderstoep
//   CREATED DATE: 2025/01/25
// ----------------------------------------------------------------------------------

#endregion

using PX.Common;
using PX.Data.BQL;

namespace LS.EfficiencyMonitor
{
    public class FiveInt : BqlInt.Constant<FiveInt>, IImplement<IBqlNumeric>
    {
        public FiveInt() : base(5)
        {
        }
    }
}