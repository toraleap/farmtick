using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTick
{
    [Serializable]
    public class PlantGroup : ProductGroup
    {
        public PlantGroup(DateTime snapshottime, Farmland parent, int ripetime, string ripename)
            : base(snapshottime, parent, ripetime, ripename) { }

        // 获取组内产品的概要表示字符串
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
