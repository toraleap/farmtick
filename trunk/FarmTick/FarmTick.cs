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
        public static Dictionary<int, Farmland> Farmlands = new Dictionary<int,Farmland>();
        public static Dictionary<int, Meadow> Meadows = new Dictionary<int, Meadow>();

        public delegate bool GroupEvaluator(ProductGroup group);
        public delegate void FarmsChangedEventHandler();
        public static event FarmsChangedEventHandler FarmsChanged;

        public static List<ProductGroup> GetSortedGroups()
        {
            // 根据预定义的规则对农牧场进行排序，输出排序后的农牧场列表
            List<ProductGroup> SortedGroups = new List<ProductGroup>();
            foreach (Farm f in Farmlands.Values) foreach (ProductGroup g in f.Groups) SortedGroups.Add(g);
            foreach (Farm f in Meadows.Values) foreach (ProductGroup g in f.Groups) SortedGroups.Add(g);
            SortedGroups.Sort();
            return SortedGroups;
        }

        // 获取最近一次成熟的信息
        public static RipeInfoCollection GetFirstRipeCollection(int offset) { return GetFirstRipeCollection(g => { return g.RipeOffset > offset; }); }
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

        public static void NotifyFarmsChanged()
        {
            if (FarmsChanged != null) FarmsChanged();
        }

        public static void Load()
        {
            // 载入上次农场列表
            if (File.Exists("./farms.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream("./farms.dat", FileMode.Open);
                Farmlands = bf.Deserialize(fs) as Dictionary<int, Farmland>;
                Meadows = bf.Deserialize(fs) as Dictionary<int, Meadow>;
                fs.Close();
            }
        }

        public static void Save()
        {
            // 保存当前农场列表
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("./farms.dat", FileMode.Create);
            bf.Serialize(fs, Farmlands);
            bf.Serialize(fs, Meadows);
            fs.Close();
        }

        public class RipeInfoCollection : List<ProductGroup>
        {
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

            public int ExpectValue
            {
                get
                {
                    int ev = 0;
                    foreach (ProductGroup g in this) ev += g.ExpectValue;
                    return ev;
                }
            }

            public DateTime RipeTime
            {
                get
                {
                    if (this.Count == 0) return DateTime.MinValue;
                    else return this[0].SnapshotTime.AddSeconds(this[0].RipeTime);
                }
            }

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
