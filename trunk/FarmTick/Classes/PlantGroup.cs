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
        public PlantGroup(Farmland parent, DateTime ripetime, string ripename)
            : base(parent, ripetime, ripename) { }

        /// <summary>
        /// 已重载，初始化组内产品的概要表示字符串，判断是否有狗
        /// </summary>
        protected override string UpdateProductString()
        {
            if ((Parent as Farmland).IsDogHungry)
                return base.UpdateProductString();
            else
                return "(狗)" + base.UpdateProductString();
        }
    }
}
