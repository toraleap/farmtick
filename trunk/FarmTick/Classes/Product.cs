using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTick
{
    /// <summary>
    /// 农场或牧场的产品基类
    /// </summary>
    [Serializable]
    public abstract class Product : IComparable
    {
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public int Type;
        /// <summary>
        /// 获取产品的名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 获取产品的成熟时间
        /// </summary>
        public DateTime RipeTime;
        /// <summary>
        /// 获取产品的期望价值
        /// </summary>
        public int Value;
        /// <summary>
        /// 产品是否还可以收取
        /// </summary>
        public abstract bool Available { get; }

        /// <summary>
        /// 实现IComparable接口，根据系统设置进行比较(可重写)
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public virtual int CompareTo(object product)
        {
            if (product is Product)
            {
                if (Properties.Settings.Default.ViewStyle == fViewUI.ViewStyles.Value)
                    return (product as Product).Value.CompareTo(Value);
                else if (Properties.Settings.Default.ViewStyle == fViewUI.ViewStyles.History)
                    return (product as Product).RipeTime.CompareTo(RipeTime);
                else
                    return RipeTime.CompareTo((product as Product).RipeTime);
            }
            else
            {
                throw new ArgumentException("比较对象必须是Product或其派生类的实例！");
            }
        }
    }
}
