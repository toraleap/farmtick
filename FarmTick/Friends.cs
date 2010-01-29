using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using FarmTick.Properties;

namespace FarmTick
{
    /// <summary>
    /// 解析、维护好友列表数据类
    /// </summary>
    public static class Friends
    {
        public static Dictionary<int, string> FriendMapXiaoyou = new Dictionary<int, string>();
        public static Dictionary<int, string> FriendMapQzone = new Dictionary<int, string>();
        public static int MasterId;
        static Regex regexsource = new Regex(@"(?:http://)?(?:happyfarm|nc|mc)\.(?<source>xiaoyou|qzone)\.qq\.com/");
        static Regex regexfriend = new Regex(@"""(?:userId|uId)"":(?<userid>\d+),.*?""userName"":""(?<username>.*?)""");

        /// <summary>
        /// 解析含有自己昵称信息的封包
        /// </summary>
        /// <param name="request">本地请求字符串</param>
        /// <param name="response">服务器返回的响应json字符串</param>
        public static void ParseMaster(string request, string response)
        {
            Match ms = regexsource.Match(request);
            MatchCollection mc = regexfriend.Matches(response);
            foreach (Match m in mc)
            {
                MasterId = int.Parse(m.Groups["userid"].Value);
                string username = m.Groups["username"].Value + "[自己]";
                UpdateFriend(ms.Groups["source"].Value, MasterId, username);
            }
            FarmTickManager.NotifyFarmsChanged();
        }

        /// <summary>
        /// 解析含有好友昵称信息的封包
        /// </summary>
        /// <param name="request">本地请求字符串</param>
        /// <param name="response">服务器返回的响应json字符串</param>
        public static void ParseFriend(string request, string response)
        {
            Match ms = regexsource.Match(request);
            MatchCollection mc = regexfriend.Matches(response);
            foreach (Match m in mc)
            {
                int uid = int.Parse(m.Groups["userid"].Value);
                if (uid != MasterId)
                {
                    string username = UniescapeToString(m.Groups["username"].Value);
                    UpdateFriend(ms.Groups["source"].Value, uid, username);
                }
            }

            FarmTickManager.NotifyFarmsChanged();
        }

        /// <summary>
        /// 添加或更新一条昵称记录
        /// </summary>
        /// <param name="source">昵称类型字符串(xiaoyou或qzone)</param>
        /// <param name="uid">欲添加或更新的用户ID</param>
        /// <param name="username">新的昵称字符串</param>
        private static void UpdateFriend(string source, int uid, string username)
        {
            if (username == String.Empty) username = " ";

            if (source.ToLower() == "xiaoyou")
            {
                if (FriendMapXiaoyou.ContainsKey(uid)) FriendMapXiaoyou[uid] = username;
                else FriendMapXiaoyou.Add(uid, username);
            }
            else if (source.ToLower() == "qzone")
            {
                if (FriendMapQzone.ContainsKey(uid)) FriendMapQzone[uid] = username;
                else FriendMapQzone.Add(uid, username);
            }
        }

        /// <summary>
        /// 载入已存储的好友昵称对照表
        /// </summary>
        public static void Load()
        {
            if (File.Exists("./friends.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream("./friends.dat", FileMode.Open);
                FriendMapXiaoyou = bf.Deserialize(fs) as Dictionary<int, string>;
                FriendMapQzone = bf.Deserialize(fs) as Dictionary<int, string>;
                MasterId = (int)bf.Deserialize(fs);
                fs.Close();
            }
        }

        /// <summary>
        /// 保存当前好友昵称对照表到磁盘
        /// </summary>
        public static void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("./friends.dat", FileMode.Create);
            bf.Serialize(fs, FriendMapXiaoyou);
            bf.Serialize(fs, FriendMapQzone);
            bf.Serialize(fs, MasterId);
            fs.Close();
        }

        /// <summary>
        /// 获取自己或好友的显示昵称
        /// </summary>
        /// <param name="uid">欲获取的用户ID</param>
        /// <returns>根据系统设置返回对应表达方式的昵称(若无数据返回“未知用户”及其ID号)</returns>
        public static string GetName(int uid)
        {
            if (Settings.Default.NameMode == (int)fViewUI.NameModes.Both)
            {
                if (FriendMapXiaoyou.ContainsKey(uid) && FriendMapQzone.ContainsKey(uid))
                    return FriendMapXiaoyou[uid] + " | " + FriendMapQzone[uid];
                else if (FriendMapXiaoyou.ContainsKey(uid))
                    return FriendMapXiaoyou[uid];
                else if (FriendMapQzone.ContainsKey(uid))
                    return FriendMapQzone[uid];
                else
                    return "未知用户[" + uid.ToString() + "]";
            }
            else if (Settings.Default.NameMode == (int)fViewUI.NameModes.Xiaoyou)
            {
                if (FriendMapXiaoyou.ContainsKey(uid))
                    return FriendMapXiaoyou[uid];
                else if (FriendMapQzone.ContainsKey(uid))
                    return FriendMapQzone[uid];
                else
                    return "未知用户[" + uid.ToString() + "]";
            }
            else
            {
                if (FriendMapQzone.ContainsKey(uid))
                    return FriendMapQzone[uid];
                else if (FriendMapXiaoyou.ContainsKey(uid))
                    return FriendMapXiaoyou[uid];
                else
                    return "未知用户[" + uid.ToString() + "]";
            }
        }

        /// <summary>
        /// 将UTF8编码的字符串转换为系统默认编码的字符串
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string UTF8ToString(string str)
        {
            return Encoding.Default.GetString(Encoding.Convert(Encoding.UTF8, Encoding.Default, Encoding.Default.GetBytes(str)));
        }

        /// <summary>
        /// 将字符串中表示为Unicode转义(类似\uA0E3形式)的字符还原为对应的字符
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns>还原后的字符串</returns>
        public static string UniescapeToString(string str)
        {
            int i = 0;
            while ((i = str.IndexOf(@"\u", 0, StringComparison.OrdinalIgnoreCase)) >= 0)
            {
                str = str.Replace(str.Substring(i, 6), Convert.ToChar(Convert.ToInt32(str.Substring(i + 2, 4), 16)).ToString());
            }
            return str;
        }
    }
}
