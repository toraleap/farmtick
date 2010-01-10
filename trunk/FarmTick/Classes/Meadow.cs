using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FarmTick
{
    // QQ牧场类。表示自己或一个好友的整个牧场
    [Serializable]
    public class Meadow : Farm
    {
        static Regex regexmeadow = new Regex(@"""animal"":\[(?:(?<response>{.*?}),?)+\]");
        static Regex regexinfo = new Regex(@"""user"":{.*?""uId"":(?<ownerid>\d+)");

        public Meadow(string entrypoint, DateTime snapshottime, string response)
        {
            EntryPoint = entrypoint;
            OwnerId = int.Parse(regexinfo.Match(response).Groups["ownerid"].Value);
            SnapshotTime = snapshottime;

            foreach (Capture c in regexmeadow.Match(response).Groups["response"].Captures)
            {
                Products.Add(new Animal(c.Value));
            }
            CreateGroups();
        }

        // 创建新牧场分组
        protected override ProductGroup CreateGroup(DateTime snapshottime, Farm parent, int ripetime, string ripename)
        {
            return new AnimalGroup(snapshottime, parent as Meadow, ripetime, ripename);
        }
    }
}
