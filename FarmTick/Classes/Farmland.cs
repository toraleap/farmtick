using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FarmTick
{
    /// <summary>
    /// QQ农场类，继承自Farm，表示自己或一个好友的整个农场
    /// </summary>
    [Serializable]
    public class Farmland : Farm
    {
        public bool IsDogHungry = true;
        static Regex regexmaster = new Regex(@"""uId"":(?<uid>\d+),""userName"":""(?<username>.*?)""");
        static Regex regexplant = new Regex(@"""farmlandStatus"":\[(?:(?<response>{.*?}),?)+\]");
        static Regex regexinfo = new Regex(@"(?:""isHungry"":(?<ishungry>\d)|""farmlandStatus"").*?""serverTime"":(?<servertime>\d+)");

        /// <summary>
        /// QQ农场构造函数
        /// </summary>
        /// <param name="entrypoint">数据来源字符串(xiaoyou或qzone)</param>
        /// <param name="ownerid">所属用户ID</param>
        /// <param name="snapshottime">快照时间</param>
        /// <param name="response">服务器返回的json字符串</param>
        public Farmland(string entrypoint, string ownerid, DateTime snapshottime, string response)
        {
            EntryPoint = entrypoint;
            if (ownerid == String.Empty) ownerid = regexmaster.Match(response).Groups["uid"].Value;
            OwnerId = int.Parse(ownerid);
            SnapshotTime = snapshottime;

            Match mi = regexinfo.Match(response);
            IsDogHungry = !(mi.Groups["ishungry"].Value == "0");

            foreach (Capture c in regexplant.Match(response).Groups["response"].Captures)
            {
                Products.Add(new Plant(c.Value, int.Parse(mi.Groups["servertime"].Value)));
            }
            CreateGroups();
        }

        /// <summary>
        /// 已重载，由CreateGroups函数调用，创建一个农场作物分组
        /// </summary>
        /// <param name="snapshottime">快照时间</param>
        /// <param name="parent">作物组所属Farm</param>
        /// <param name="ripetime">作物组最早成熟时间</param>
        /// <param name="ripename">作物组最早成熟作物名</param>
        /// <returns>新建的作物组</returns>
        protected override ProductGroup CreateGroup(DateTime snapshottime, Farm parent, int ripetime, string ripename)
        {
            return new PlantGroup(snapshottime, parent as Farmland, ripetime, ripename);
        }
    }
}
