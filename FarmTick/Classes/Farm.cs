using System;
using System.Collections.Generic;
using System.Text;

namespace FarmTick
{
    // QQ农场牧场的基类。表示自己或一个好友的农场或牧场。
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

        // 农场/牧场成熟产品分组
        public virtual void CreateGroups()
        {
            // 将产品按成熟时间排序
            Products.Sort();

            int lasttime = 0;
            ProductGroup group = null;

            foreach (Product p in Products)
            {
                if (!p.Available) continue;
                if (group != null && p.UnifiedRipeTime - lasttime <= 120)
                {
                    lasttime = p.UnifiedRipeTime;
                    group.Products.Add(p);
                }
                else
                {
                    lasttime = p.UnifiedRipeTime;
                    Groups.Add(group = CreateGroup(SnapshotTime, this, p.UnifiedRipeTime, p.Name));
                    group.Products.Add(p);
                }
            }
        }

        // 创建新分组(需重写)
        protected abstract ProductGroup CreateGroup(DateTime snapshottime, Farm parent, int ripetime, string ripename);
    }
}
