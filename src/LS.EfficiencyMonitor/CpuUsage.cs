#region #Copyright

// ----------------------------------------------------------------------------------
//   COPYRIGHT (c) 2025 CONTOU CONSULTING
//   ALL RIGHTS RESERVED
//   AUTHOR: Kyle Vanderstoep
//   CREATED DATE: 2025/01/25
// ----------------------------------------------------------------------------------

#endregion

namespace LS.EfficiencyMonitor
{
    public class CpuUsage
    {
        public int MaxUsage
        {
            get => _maxUsage > 100 ? 100 : _maxUsage;
            set => _maxUsage = value;
        }

        public int MinUsage
        {
            get => _minUsage > 100 ? 100 : _minUsage;
            set => _minUsage = value;
        }

        public int AvgUsage
        {
            get => _avgUsage > 100 ? 100 : _avgUsage;
            set => _avgUsage = value;
        }

        private int _maxUsage;
        private int _minUsage;
        private int _avgUsage;
    }
}