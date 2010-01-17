using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTick
{
    /// <summary>
    /// 作物组，包含同一用户在一段短时间内成熟的作物列表
    /// </summary>
    [Serializable]
    public class PlantGroup : ProductGroup
    {
        public PlantGroup(DateTime snapshottime, Farmland parent, int ripetime, string ripename)
            : base(snapshottime, parent, ripetime, ripename) { }

        /// <summary>
        /// 已重载，获取组内产品的概要表示字符串，判断是否有狗
        /// </summary>
        public override string ProductString
        {
            get
            {
                if (_ProductString == null)
                {
                    if ((Parent as Farmland).IsDogHungry)
                        _ProductString = base.ProductString;
                    else
                        _ProductString = "(狗)" + base.ProductString;
                }
                return _ProductString;
            }
        }
    }
}
