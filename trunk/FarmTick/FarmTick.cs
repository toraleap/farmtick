using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace FarmTick
{
    public static class FarmTick
    {
        /// <summary>
        /// 存储农场快照数据
        /// </summary>
        public static Dictionary<int, Farmland> Farmlands = new Dictionary<int,Farmland>();
        /// <summary>
        /// 存储牧场快照数据
        /// </summary>
        public static Dictionary<int, Meadow> Meadows = new Dictionary<int, Meadow>();

        /// <summary>
        /// 判定产品组是否满足条件的委托
        /// </summary>
        /// <param name="group">待判断的产品组</param>
        /// <returns>该产品组是否满足条件</returns>
        public delegate bool GroupEvaluator(ProductGroup group);
        public delegate void FarmsChangedEventHandler();
        /// <summary>
        /// 当农牧场数据发生改变时，触发此事件
        /// </summary>
        public static event FarmsChangedEventHandler FarmsChanged;

        /// <summary>
        /// 获取根据最近成熟时间进行排序后的所有产品组
        /// </summary>
        /// <returns>排序后的产品组</returns>
        public static List<ProductGroup> GetSortedGroups()
        {
            List<ProductGroup> SortedGroups = new List<ProductGroup>();
            foreach (Farm f in Farmlands.Values) foreach (ProductGroup g in f.Groups) SortedGroups.Add(g);
            foreach (Farm f in Meadows.Values) foreach (ProductGroup g in f.Groups) SortedGroups.Add(g);
            SortedGroups.Sort();
            return SortedGroups;
        }
        
        /// <summary>
        /// 根据给出的提前时间量，获取最近成熟的产品组集合
        /// </summary>
        /// <param name="offset">计算时提前的时间量</param>
        /// <returns>满足条件的即将成熟的产品组集合</returns>
        public static RipeInfoCollection GetFirstRipeCollection(int offset) { return GetFirstRipeCollection(g => { return g.RipeOffset > offset; }); }
        
        /// <summary>
        /// 根据给出的判定委托，获取最近成熟的产品组集合
        /// </summary>
        /// <param name="Evaluator">判定产品组是否满足条件的委托调用</param>
        /// <returns>满足条件的即将成熟的产品组集合</returns>
        public static RipeInfoCollection GetFirstRipeCollection(GroupEvaluator Evaluator)
        {
            RipeInfoCollection lri = new RipeInfoCollection();
            int FirstRipeOffset = 0;
            foreach (ProductGroup g in GetSortedGroups())
            {
                if (Evaluator(g))
                {
                    if (FirstRipeOffset == 0) FirstRipeOffset = g.RipeOffset;
                    if (g.RipeOffset - FirstRipeOffset < 60) lri.Add(g);
                }
            }
            return lri;
        }

        /// <summary>
        /// 通知GUI农场数据发生改变，需要更新
        /// </summary>
        public static void NotifyFarmsChanged()
        {
            if (FarmsChanged != null) FarmsChanged();
        }

        /// <summary>
        /// 载入上次退出时保存的农场列表
        /// </summary>
        public static void Load()
        {
            if (File.Exists("./farms.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream("./farms.dat", FileMode.Open);
                Farmlands = bf.Deserialize(fs) as Dictionary<int, Farmland>;
                Meadows = bf.Deserialize(fs) as Dictionary<int, Meadow>;
                fs.Close();
            }
        }

        /// <summary>
        /// 退出时保存的农场列表以便下次载入
        /// </summary>
        public static void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("./farms.dat", FileMode.Create);
            bf.Serialize(fs, Farmlands);
            bf.Serialize(fs, Meadows);
            fs.Close();
        }

        /// <summary>
        /// 记录即将成熟的产品组集合
        /// </summary>
        public class RipeInfoCollection : List<ProductGroup>
        {
            /// <summary>
            /// 获取产品组集合所有者的昵称
            /// </summary>
            public string OwnerName
            {
                get
                {
                    if (this.Count == 0) return "无";
                    List<string> ls = new List<string>();
                    foreach (ProductGroup g in this) ls.Add(g.OwnerName);
                    return string.Join(",", ls.ToArray());
                }
            }

            /// <summary>
            /// 获取产品组集合的期望收获价值
            /// </summary>
            public int ExpectValue
            {
                get
                {
                    int ev = 0;
                    foreach (ProductGroup g in this) ev += g.ExpectValue;
                    return ev;
                }
            }

            /// <summary>
            /// 获取产品组集合中最早的成熟时间
            /// </summary>
            public DateTime RipeTime
            {
                get
                {
                    if (this.Count == 0) return DateTime.MinValue;
                    else return this[0].SnapshotTime.AddSeconds(this[0].RipeTime);
                }
            }

            /// <summary>
            /// 获取产品组集合中全部产品的字符串表示
            /// </summary>
            public string ProductString
            {
                get
                {
                    if (this.Count == 0) return "无";
                    List<string> ls = new List<string>();
                    foreach (ProductGroup g in this) ls.Add(g.ProductString);
                    return string.Join(",", ls.ToArray());
                }
            }
        }
    }
}
