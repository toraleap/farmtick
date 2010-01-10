using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTick
{
    /// <summary>
    /// 动物组，包含同一用户在一段短时间内成熟的动物列表
    /// </summary>
    [Serializable]
    public class AnimalGroup : ProductGroup
    {
        public AnimalGroup(DateTime snapshottime, Meadow parent, int ripetime, string ripename)
            : base(snapshottime, parent, ripetime, ripename) { }

        /// <summary>
        /// 已重载，将牧场概况转换为字符表示
        /// </summary>
        public override string RipingString
        {
            get
            {
                return String.Format("{0} {1}可生产", ProductString, FormatTime(RipeOffset));
            }
        }
    }
}
