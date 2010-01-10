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
        /// 产品是否还可以收取
        /// </summary>
        public abstract bool Available { get; }
        /// <summary>
        /// 获取产品距成熟的剩余时间
        /// </summary>
        /// <param name="offset">计算时的时间提前量</param>
        /// <returns>以秒表示的剩余时间</returns>
        public virtual int GetUnifiedRipeOffset(int offset) { return UnifiedRipeTime - offset; }
        /// <summary>
        /// 获取产品的成熟时间
        /// </summary>
        public abstract int UnifiedRipeTime { get; }
        /// <summary>
        /// 获取产品的名称
        /// </summary>
        public virtual string Name { get { return GetName(Type); } }
        /// <summary>
        /// 获取产品的期望价值
        /// </summary>
        public virtual int Value { get { return ProductTypes.GetPrice(Type); } }

        /// <summary>
        /// 获取指定ID的产品名称
        /// </summary>
        /// <param name="type">产品ID</param>
        /// <returns>产品名称</returns>
        public static string GetName(int type)
        {
            return ProductTypes.GetName(type);
        }

        /// <summary>
        /// 实现IComparable接口，比较成熟时间(可重写)
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public virtual int CompareTo(object product)
        {
            if (product is Product)
            {
                return UnifiedRipeTime - (product as Product).UnifiedRipeTime;
            }
            else
            {
                throw new ArgumentException("比较对象必须是Product或其派生类的实例！");
            }
        }
    }

    // 
    /// <summary>
    /// 产品信息静态类，存储各产品类型对应的ID、名称、成熟时间、出售单价、期望产出数量表
    /// </summary>
    public static class ProductTypes
    {
        static int[] typeid = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,
                        /* 2 */   1, 14, 15, 18, 19, 13, 23, 26, 27, 29, 
                        /* 3 */   31, 33, 34, 35, 40, 38, 39, 41, 101, 102,
                        /* 4 */   103, 104, 105, 42, 48, 46, 45, 47, 44, 50,
                        /* 5 */   59, 60, 61, 21, 24, 32, 36, 49, 51, 53,
                        /* 6 */   54, 55, 56, 57, 58, 106, 109, 107, 108, 64,
                        /* 7 */   66, 71, 73, 70, 72, 69, 63, 68, 67, 80,
                        /* 8 */   75, 78, 74, 79, 77, 76, 120, 110, 111, 122,
                        /* 9 */   112, 118, 113, 114, 115, 123, 81, 62,
                    /*Animals*/   1001, 1002, 1003, 1004, 1005, 1006, 1007, 1008, 1009, 1010,
                        /* 1 */   1501, 1502, 1503, 1504, 1505, 1507 };
        static string[] name = { "白萝卜", "胡萝卜", "玉米", "土豆", "茄子", "番茄", "豌豆", "辣椒", "南瓜", "苹果", 
                         /* 2 */   "草莓", "西瓜", "香蕉", "桃子", "橙子", "葡萄", "石榴", "柚子", "菠萝", "椰子",
                         /* 3 */   "葫芦", "火龙果", "樱桃", "荔枝", "牧草", "木瓜", "杨桃", "红玫瑰", "薰衣草", "马蹄莲",
                         /* 4 */   "天香百合", "非洲菊", "小雏菊", "柠檬", "杨梅", "爱心果", "猕猴桃", "甘蔗", "丝瓜", "蘑菇",
                         /* 5 */   "大白菜", "水稻", "小麦", "红薯", "黄瓜", "香梨", "奇异果", "花生", "红枣", "桂圆",
                         /* 6 */   "梨", "枇杷", "哈密瓜", "芒果", "榴莲", "郁金香", "蝴蝶兰", "仙人掌", "铃兰", "大葱", 
                         /* 7 */   "鲜姜", "小白菜", "菠菜", "黄豆", "榛子", "莴笋", "苦瓜", "冬瓜", "香瓜", "月柿",
                         /* 8 */   "桑葚", "杏子", "金桔", "番石榴", "蓝莓", "山竹", "蒲公英", "满天星", "粉玫瑰", "丁香花",
                         /* 9 */   "风信子", "水仙花", "栀子花", "蓝玫瑰", "兰花", "海棠花", "圣诞树", "四叶草",
                     /*Animals*/   "鸡", "兔子", "鹅", "猫", "孔雀", "企鹅", "乌龟", "松鼠", "波斯猫", "仓鼠",
                         /* 1 */   "羊", "牛", "猴子", "袋鼠", "梅花鹿", "羚羊" };
        static int[] ripe = { 36000, 46800, 50400, 54000, 57600, 61200, 64800, 72000, 79200, 75600,
                      /* 2 */   86400, 100800, 111600, 151200, 133200, 165600, 187200, 219600, 230400, 198000,
                      /* 3 */   219600, 252000, 259200, 277200, 28800, 165600, 165600, 64800, 219600, 230400,
                      /* 4 */   72000, 75600, 61200, 111600, 111600, 111600, 165600, 111600, 111600, 108000,
                      /* 5 */   50400, 50400, 50400, 93600, 198000, 234000, 291600, 151200, 57600, 151200,
                      /* 6 */   115200, 151200, 111600, 111600, 111600, 187200, 230400, 115200, 115200, 39600,
                      /* 7 */   39600, 39600, 61200, 100800, 165600, 100800, 252000, 259200, 277200, 111600,
                      /* 8 */   277200, 111600, 111600, 111600, 111600, 111600, 57600, 79200, 100800, 111600,
                      /* 9 */   111600, 111600, 133200, 151200, 151200, 277200, 46800, 82800 };
        static int[] price = { 17, 21, 23, 24, 25, 26, 27, 28, 30, 24, 
                       /* 2 */   27, 29, 32, 40, 41, 47, 54, 58, 62, 65, 
                       /* 3 */   71, 77, 78, 86, 6, 80, 82, 27, 58, 62,
                       /* 4 */   28, 24, 26, 83, 84, 100, 75, 42, 50, 55,
                       /* 5 */   22, 21, 21, 0, 0, 0, 0, 38, 25, 38,
                       /* 6 */   35, 77, 38, 100, 100, 54, 62, 32, 32, 0,
                       /* 7 */   0, 0, 0, 0, 47, 0, 0, 0, 0, 0,
                       /* 8 */   0, 0, 0, 42, 43, 44, 0, 0, 0, 0, 
                       /* 9 */   0, 0, 0, 0, 0, 0, 20, 24,
                   /*Animals*/   17, 39, 19, 56, 35, 68, 69, 71, 72, 78,
                       /* 1 */   29, 55, 58, 64, 70, 77 };
        static int[] number = { 16, 17, 17, 18, 20, 21, 22, 24, 25, 23,
                        /* 2 */   24, 27, 29, 32, 26, 29, 30, 33, 25, 27,
                        /* 3 */   30, 32, 33, 34, 25, 28, 29, 22, 33, 35,
                        /* 4 */   24, 23, 21, 26, 26, 1, 27, 28, 24, 27,
                        /* 5 */   17, 18, 18, 1, 1, 1, 1, 1, 1, 1,
                        /* 6 */   1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        /* 7 */   1, 1, 1, 1, 29, 1, 1, 1, 1, 1,
                        /* 8 */   1, 1, 1, 28, 28, 28, 1, 1, 1, 1,
                        /* 9 */   1, 1, 1, 1, 1, 1, 16, 25,
                    /*Animals*/   20, 12, 20, 12, 24, 16, 12, 13, 14, 16, 
                        /* 1 */   24, 12, 12, 12, 13, 15 };

        /// <summary>
        /// 获取指定ID的产品名称
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>产品名称</returns>
        public static string GetName(int id)
        {
            int i;
            if ((i = Array.IndexOf<int>(typeid, id)) >= 0) return name[i];
            else return "未知产品[" + id.ToString() + "]";
        }

        /// <summary>
        /// 获取指定ID的产品成熟时间
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>成熟时间，以秒计算</returns>
        public static int GetRipe(int id)
        {
            int i;
            if ((i = Array.IndexOf<int>(typeid, id)) >= 0) return ripe[i];
            else return 999999;
        }

        /// <summary>
        /// 获取指定ID的产品出售单价
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>出售单价</returns>
        public static int GetPrice(int id)
        {
            int i;
            if ((i = Array.IndexOf<int>(typeid, id)) >= 0) return price[i];
            else return 0;
        }

        /// <summary>
        /// 获取指定ID的产品期望产出数量
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>期望产出数量</returns>
        public static int GetNumber(int id)
        {
            int i;
            if ((i = Array.IndexOf<int>(typeid, id)) >= 0) return number[i];
            else return 1;
        }
    }
}
