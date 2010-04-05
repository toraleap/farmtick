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
        public int ServerTime;
        static Regex regexsource = new Regex(@"(?:http://)?nc\.(?<source>xiaoyou|qzone)\.qq\.com/cgi-bin/cgi_farm_index\?mod=user&act=run");
        static Regex regexuid = new Regex(@"(?:http://)?nc\.(?<source>xiaoyou|qzone)\.qq\.com/cgi-bin/cgi_farm_index\?mod=user&act=run.*?&ownerId=(?<ownerid>\d+)");
        static Regex regexmaster = new Regex(@"""uId"":(?<uid>\d+),(?:""uinLogin"":\d+,)?""userName"":""(?<username>.*?)""");
        static Regex regexplant = new Regex(@"""farmlandStatus"":\[(?:(?<response>{.*?}),?)+\]");
        static Regex regexinfo = new Regex(@"(?:""isHungry"":(?<ishungry>\d)|""farmlandStatus"").*?""serverTime"":(?<servertime>\d+)");

        /// <summary>
        /// QQ农场构造函数
        /// </summary>
        /// <param name="snapshottime">快照时间</param>
        /// <param name="entrypoint">本地请求字符串</param>
        /// <param name="response">服务器返回的响应json字符串</param>
        public Farmland(DateTime snapshottime, string request, string response)
        {
            string ownerid = regexmaster.Match(response).Groups["uid"].Value;
            EntryPoint = regexsource.Match(request).Groups["source"].Value;
            if (ownerid != string.Empty)
                OwnerId = int.Parse(ownerid);
            else
                OwnerId = int.Parse(regexuid.Match(request).Groups["ownerid"].Value);
            SnapshotTime = snapshottime;

            Match mi = regexinfo.Match(response);
            ServerTime = int.Parse(mi.Groups["servertime"].Value);
            IsDogHungry = !(mi.Groups["ishungry"].Value == "0");

            foreach (Capture c in regexplant.Match(response).Groups["response"].Captures)
            {
                Products.Add(new Plant(this, c.Value));
            }
            CreateGroups();
        }

        /// <summary>
        /// 已重载，由CreateGroups函数调用，创建一个农场作物分组
        /// </summary>
        /// <param name="parent">作物组所属Farm</param>
        /// <param name="ripetime">作物组最早成熟时间</param>
        /// <param name="ripename">作物组最早成熟作物名</param>
        /// <returns>新建的作物组</returns>
        protected override ProductGroup CreateGroup(Farm parent, DateTime ripetime, string ripename)
        {
            return new PlantGroup(parent as Farmland, ripetime, ripename);
        }
    }
}
