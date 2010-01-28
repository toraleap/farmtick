using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTick
{
    /// <summary>
    /// QQ农场牧场的基类。表示自己或一个好友的农场或牧场。
    /// </summary>
    [Serializable]
    public abstract class Farm
    {
        public int OwnerId;
        public string EntryPoint;
        public DateTime SnapshotTime;
        public string OwnerName { get { return Friends.GetName(OwnerId); } }
        public List<Product> Products = new List<Product>();
        public List<ProductGroup> Groups = new List<ProductGroup>();

        public Farm()
        {
            CreateGroups();
        }

        /// <summary>
        /// 为农场牧场创建各自的产品组
        /// </summary>
        public virtual void CreateGroups()
        {
            // 将产品按成熟时间排序
            Products.Sort();

            DateTime lasttime = DateTime.Now;
            ProductGroup group = null;

            foreach (Product p in Products)
            {
                if (!p.Available) continue;
                if (group != null && p.RipeTime.Subtract(lasttime).TotalSeconds <= 120)
                {
                    lasttime = p.RipeTime;
                    group.Products.Add(p);
                }
                else
                {
                    lasttime = p.RipeTime;
                    Groups.Add(group = CreateGroup(this, p.RipeTime, p.Name));
                    group.Products.Add(p);
                }
            }
        }

        /// <summary>
        /// 由CreateGroups函数调用，创建一个新分组(需重写)
        /// </summary>
        /// <param name="snapshottime">快照时间</param>
        /// <param name="parent">产品组所属Farm</param>
        /// <param name="ripetime">产品组内最早成熟时间</param>
        /// <param name="ripename">产品组内最早成熟产品名</param>
        /// <returns>新建的产品组</returns>
        protected abstract ProductGroup CreateGroup(Farm parent, DateTime ripetime, string ripename);
    }
}
