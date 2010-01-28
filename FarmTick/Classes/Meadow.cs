using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FarmTick
{
    /// <summary>
    /// QQ牧场类，继承自Farm，表示自己或一个好友的整个牧场
    /// </summary>
    [Serializable]
    public class Meadow : Farm
    {
        static Regex regexsource = new Regex(@"(?:http://)?mc\.(?<source>xiaoyou|qzone)\.qq\.com/cgi-bin/cgi_enter\?");
        static Regex regexmeadow = new Regex(@"""animal"":\[(?:(?<response>{.*?}),?)+\]");
        static Regex regexinfo = new Regex(@"""user"":{.*?""uId"":(?<ownerid>\d+)");

        /// <summary>
        /// QQ牧场构造函数
        /// </summary>
        /// <param name="snapshottime">快照时间</param>
        /// <param name="request">本地请求字符串</param>
        /// <param name="response">服务器返回的响应json字符串</param>
        public Meadow(DateTime snapshottime, string request, string response)
        {
            EntryPoint = regexsource.Match(request).Groups["source"].Value;
            OwnerId = int.Parse(regexinfo.Match(response).Groups["ownerid"].Value);
            SnapshotTime = snapshottime;

            foreach (Capture c in regexmeadow.Match(response).Groups["response"].Captures)
            {
                Products.Add(new Animal(this, c.Value));
            }
            CreateGroups();
        }

        /// <summary>
        /// 已重载，由CreateGroups函数调用，创建一个牧场动物分组
        /// </summary>
        /// <param name="parent">动物组所属Farm</param>
        /// <param name="ripetime">动物组最早成熟时间</param>
        /// <param name="ripename">动物组最早成熟作物名</param>
        /// <returns>新建的动物组</returns>
        protected override ProductGroup CreateGroup(Farm parent, DateTime ripetime, string ripename)
        {
            return new AnimalGroup(parent as Meadow, ripetime, ripename);
        }
    }
}
