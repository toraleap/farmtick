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
        public AnimalGroup(Meadow parent, DateTime ripetime, string ripename)
            : base(parent, ripetime, ripename) { }
    }
}
