using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTick
{
    [Serializable]
    public class AnimalGroup : ProductGroup
    {
        public AnimalGroup(DateTime snapshottime, Meadow parent, int ripetime, string ripename)
            : base(snapshottime, parent, ripetime, ripename) { }

        // 将牧场概况转换为字符表示
        public override string RipingString
        {
            get
            {
                return String.Format("{0} {1}可生产", ProductString, FormatTime(RipeOffset));
            }
        }
    }
}
