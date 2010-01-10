using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using FarmTick.Properties;

namespace FarmTick
{
    public static class Friends
    {
        public static Dictionary<int, string> FriendMapXiaoyou = new Dictionary<int, string>();
        public static Dictionary<int, string> FriendMapQzone = new Dictionary<int, string>();
        public static int MasterId;
        static Regex regexfriend = new Regex(@"""(?:userId|uId)"":(?<userid>\d+),.*?""userName"":""(?<username>.*?)""");
        //static Regex regexmaster = new Regex(@"""uId"":(?<uid>\d+),""userName"":""(?<username>.*?)""");

        public static void ParseMaster(string source, string response)
        {
            // 解析含有自己名字的封包
            MatchCollection mc = regexfriend.Matches(response);
            foreach (Match m in mc)
            {
                MasterId = int.Parse(m.Groups["userid"].Value);
                string username = m.Groups["username"].Value + "[自己]";
                UpdateFriend(source, MasterId, username);
            }
            FarmTick.NotifyFarmsChanged();
        }

        public static void ParseFriend(string source, string response)
        {
            // 解析含有好友名字的封包
            MatchCollection mc = regexfriend.Matches(response);
            foreach (Match m in mc)
            {
                int uid = int.Parse(m.Groups["userid"].Value);
                if (uid != MasterId)
                {
                    string username = UniescapeToString(m.Groups["username"].Value);
                    UpdateFriend(source, uid, username);
                }
            }

            FarmTick.NotifyFarmsChanged();
        }

        private static void UpdateFriend(string source, int uid, string username)
        {
            // 添加或更新本地好友名单
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

        public static void Load()
        {
            // 载入历史好友名字对照表
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

        public static void Save()
        {
            // 保存当前好友名字对照表
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("./friends.dat", FileMode.Create);
            bf.Serialize(fs, FriendMapXiaoyou);
            bf.Serialize(fs, FriendMapQzone);
            bf.Serialize(fs, MasterId);
            fs.Close();
        }

        public static string GetName(int uid)
        {
            // 根据模式获取uid对应的显示名字
            if (Settings.Default.NameMode == 0)
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
            else if (Settings.Default.NameMode == 1)
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

        public static string UTF8ToString(string str)
        {
            // 将UTF8编码的字符串转换为系统默认编码的字符串
            return Encoding.Default.GetString(Encoding.Convert(Encoding.UTF8, Encoding.Default, Encoding.Default.GetBytes(str)));
        }

        public static string UniescapeToString(string str)
        {
            // 将字符串中表示为Unicode转义(类似\uA0E3形式)的字符还原为对应的字符
            int i = 0;
            while ((i = str.IndexOf(@"\u", 0, StringComparison.OrdinalIgnoreCase)) >= 0)
            {
                str = str.Replace(str.Substring(i, 6), Convert.ToChar(Convert.ToInt32(str.Substring(i + 2, 4), 16)).ToString());
            }
            return str;
        }
    }
}
