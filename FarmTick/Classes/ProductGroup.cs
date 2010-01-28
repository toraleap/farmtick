using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTick
{
    /// <summary>
    /// 产品组，包含同一用户在一段短时间内成熟的产品列表
    /// </summary>
    [Serializable]
    public abstract class ProductGroup : IComparable
    {
        public readonly Farm Parent;
        public readonly DateTime RipeTime;
        public readonly string RipeName;
        public int? _ExpectValue;
        public string _ProductString;
        public readonly List<Product> Products = new List<Product>();
        public int OwnerId { get { return Parent.OwnerId; } }
        public string OwnerName { get { return Parent.OwnerName; } }

        /// <summary>
        /// 产品组构造函数
        /// </summary>
        /// <param name="parent">所属农场或牧场</param>
        /// <param name="ripetime">产品组内最早成熟时间</param>
        /// <param name="ripename">产品组内最早成熟产品名</param>
        public ProductGroup(Farm parent, DateTime ripetime, string ripename)
        {
            Parent = parent;
            RipeTime = ripetime;
            RipeName = ripename;
            //ExpectValue = GetExpectValue();
            //ProductString = GetProductString();
        }

        /// <summary>
        /// 获取产品组的期望价值
        /// </summary>
        public int ExpectValue
        {
            get
            {
                if (_ExpectValue.HasValue)
                    return _ExpectValue.Value;
                else
                {
                    _ExpectValue = UpdateExpectValue();
                    return _ExpectValue.Value;
                }
            }
        }

        /// <summary>
        /// 获取产品组的字符串表示
        /// </summary>
        public string ProductString
        {
            get
            {
                if (_ProductString != null)
                    return _ProductString;
                else
                {
                    _ProductString = UpdateProductString();
                    return _ProductString;
                }
            }
        }

        /// <summary>
        /// 初始化产品组内产品的期望价值(可重写)
        /// </summary>
        protected virtual int UpdateExpectValue()
        {
            int v = 0;
            foreach (Product p in Products)
                if (Parent.OwnerId == Friends.MasterId)
                    v += p.Value * ProductTypes.GetNumber(p.Type);
                else
                    v += p.Value;
            return v;
        }

        /// <summary>
        /// 初始化产品组内所有产品的概要表示字符串(可重写)
        /// </summary>
        protected virtual string UpdateProductString()
        {
            Dictionary<int, int> LastRipings = new Dictionary<int, int>();
            foreach (Product p in Products)
                if (LastRipings.ContainsKey(p.Type)) LastRipings[p.Type]++;
                else LastRipings.Add(p.Type, 1);
            StringBuilder sb = new StringBuilder();
            foreach (int at in LastRipings.Keys) sb.Append(LastRipings[at]).Append('x').Append(ProductTypes.GetName(at));
            return sb.ToString();
        }

        /// <summary>
        /// 实现IComparable接口，根据系统设置进行比较(可重写)
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public int CompareTo(object group)
        {
            if (group is ProductGroup)
            {
                if (Properties.Settings.Default.ViewStyle == fViewUI.ViewStyles.Value)
                    return (group as ProductGroup).ExpectValue.CompareTo(ExpectValue);
                else if (Properties.Settings.Default.ViewStyle == fViewUI.ViewStyles.History)
                    return (group as ProductGroup).RipeTime.CompareTo(RipeTime);
                else
                    return RipeTime.CompareTo((group as ProductGroup).RipeTime);
            }
            else
                throw new ArgumentException("比较对象必须是ProductGroup或其派生类的实例！");
        }
    }
}
