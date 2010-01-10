using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FarmTick
{
    // QQ农场类。表示自己或一个好友的整个农场
    [Serializable]
    public class Farmland : Farm
    {
        public bool IsDogHungry = true;
        static Regex regexmaster = new Regex(@"""uId"":(?<uid>\d+),""userName"":""(?<username>.*?)""");
        static Regex regexplant = new Regex(@"""farmlandStatus"":\[(?:(?<response>{.*?}),?)+\]");
        static Regex regexinfo = new Regex(@"(?:""isHungry"":(?<ishungry>\d)|""farmlandStatus"").*?""serverTime"":(?<servertime>\d+)");

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

        // 创建新农场分组
        protected override ProductGroup CreateGroup(DateTime snapshottime, Farm parent, int ripetime, string ripename)
        {
            return new PlantGroup(snapshottime, parent as Farmland, ripetime, ripename);
        }
    }
}
