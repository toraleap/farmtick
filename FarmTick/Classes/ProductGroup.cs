using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTick
{
    [Serializable]
    public abstract class ProductGroup : IComparable
    {
        public readonly Farm Parent;
        public readonly int RipeTime;
        public readonly string RipeName;
        public readonly DateTime SnapshotTime;
        public int? _ExpectValue;
        public string _ProductString;
        public readonly List<Product> Products = new List<Product>();
        public bool Available { get { return RipeTime - (DateTime.Now - SnapshotTime).TotalSeconds > 0; } }
        public int RipeOffset { get { return (int)(RipeTime - (DateTime.Now - SnapshotTime).TotalSeconds); } }
        public int OwnerId { get { return Parent.OwnerId; } }
        public string OwnerName { get { return Parent.OwnerName; } }

        public ProductGroup(DateTime snapshottime, Farm parent, int ripetime, string ripename)
        {
            SnapshotTime = snapshottime;
            Parent = parent;
            RipeTime = ripetime;
            RipeName = ripename;
        }

        // 获取产品的期望价值(可重写)
        public virtual int ExpectValue
        {
            get
            {
                if (_ExpectValue == null)
                {
                    int v = 0;
                    foreach (Product p in Products)
                        if (Parent.OwnerId == Friends.MasterId)
                            v += p.Value * ProductTypes.GetNumber(p.Type);
                        else
                            v += p.Value;
                    _ExpectValue = v;
                }
                return _ExpectValue.Value;
            }
        }


        // 获取组内产品的概要表示字符串(可重写)
        public virtual string ProductString
        {
            get
            {
                if (_ProductString == null)
                {
                    Dictionary<int, int> LastRipings = new Dictionary<int, int>();
                    foreach (Product p in Products)
                        if (LastRipings.ContainsKey(p.Type)) LastRipings[p.Type]++;
                        else LastRipings.Add(p.Type, 1);
                    StringBuilder sb = new StringBuilder();
                    foreach (int at in LastRipings.Keys) sb.Append(LastRipings[at]).Append('x').Append(Product.GetName(at));
                    _ProductString = sb.ToString();
                }
                return _ProductString;
            }
        }

        // 获取组内产品的成熟字符串(可重写)
        public virtual string RipingString
        {
            get
            {
                return String.Format("{0} {1}成熟", ProductString, FormatTime(RipeOffset));
            }
        }

        // 比较成熟时间或价值(可重写)
        public int CompareTo(object group)
        {
            if (group is ProductGroup)
                return RipeOffset - (group as ProductGroup).RipeOffset;
            else
                return 0;
        }

        // 将以秒表示的时间转换为适当的显示格式
        protected string FormatTime(int offset)
        {
            if (offset > 3600)
                return String.Format("{0}小时{1}分钟后", offset / 3600, (offset % 3600) / 60);
            else if (offset > 180)
                return String.Format("{0}分钟后", offset / 60);
            else if (offset > 60)
                return String.Format("{0}分钟{1}秒钟后", offset / 60, offset % 60);
            else if (offset > 0)
                return String.Format("{0}秒钟后", offset);
            else if (offset > -60)
                return String.Format("{0}秒钟前", -offset);
            else
                return String.Format("{0}分钟前", -offset / 60);
        }
    }
}
