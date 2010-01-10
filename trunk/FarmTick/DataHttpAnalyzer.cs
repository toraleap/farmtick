using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HTTPAnalyzer;
using HTTPAnalyzerStd;

namespace FarmTick
{
    /// <summary>
    /// HttpAnalyzer驱动数据捕获模式类
    /// </summary>
    public static class DataHttpAnalyzer
    {
        static Regex regexurl = new Regex(@"(?:http://)?(?:happyfarm|nc|mc)\.(?:xiaoyou|qzone)\.qq\.com/(?:cgi-bin/cgi_|api\.php");
        static Regex regexfriends = new Regex(@"(?:http://)?happyfarm\.(?<source>xiaoyou|qzone)\.qq\.com/api\.php\?mod=friend");
        static Regex regexfmaster = new Regex(@"(?:http://)?nc\.(?<source>xiaoyou|qzone)\.qq\.com/cgi-bin/cgi_farm_index\?mod=user&act=run(?:&flag=.*?)?$");
        static Regex regexfarmland = new Regex(@"(?:http://)?nc\.(?<source>xiaoyou|qzone)\.qq\.com/cgi-bin/cgi_farm_index\?mod=user&act=run&ownerId=(?<ownerid>\d+)");
        static Regex regexmeadow = new Regex(@"(?:http://)?mc\.(?<source>xiaoyou|qzone)\.qq\.com/cgi-bin/cgi_enter\?");
        /// <summary>
        /// 获取是否正在进行数据捕获
        /// </summary>
        public static bool IsCapturing { get { return ha.IsLogging; } }
        static HTTPAnalyzerStandAloneClass ha;

        /// <summary>
        /// 启动数据捕获
        /// </summary>
        public static void Capture()
        {
            try
            {
                ha = new HTTPAnalyzerStandAloneClass();
                ha.Visible = false;
                ha.MaxLogSize = 10;
                ha.OnNewEntry += OnNewEntry;
                ha.AttachAllSessions();
                ha.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 结束数据捕获
        /// </summary>
        public static void Release()
        {
            try
            {
                ha.Stop();
                ha = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void OnNewEntry(ILogEntry entry, ref bool discardIt)
        {
            // 验证URL是否需要处理
            if (entry.IsComplete && regexurl.Match(entry.URL).Success) ParseEntry(entry, ref discardIt);
        }

        private static void ParseEntry(ILogEntry entry, ref bool discardIt)
        {
            Match match;

            // 解析好友列表数据
            match = regexfriends.Match(entry.URL);
            if (match.Success)
            {
                Friends.ParseFriend(match.Groups["source"].Value,
                    Encoding.Default.GetString((byte[])entry.Content.Data));
            }

            // 解析自己农场数据
            match = regexfmaster.Match(entry.URL);
            if (match.Success)
            {
                Friends.ParseMaster(match.Groups["source"].Value,
                    Encoding.Default.GetString((byte[])entry.Content.Data));
                Farmland f = new Farmland(match.Groups["source"].Value,
                    String.Empty,
                    entry.TimeStart,
                    Encoding.Default.GetString((byte[])entry.Content.Data));
                // 检测是否已有此农场数据
                if (FarmTick.Farmlands.ContainsKey(f.OwnerId)) FarmTick.Farmlands[f.OwnerId] = f;
                else FarmTick.Farmlands.Add(f.OwnerId, f);
                FarmTick.NotifyFarmsChanged();
            }

            // 解析好友农场数据
            match = regexfarmland.Match(entry.URL);
            if (match.Success)
            {
                Farmland f = new Farmland(match.Groups["source"].Value,
                    match.Groups["ownerid"].Value,
                    entry.TimeStart,
                    Encoding.Default.GetString((byte[])entry.Content.Data));
                // 检测是否已有此农场数据
                if (FarmTick.Farmlands.ContainsKey(f.OwnerId)) FarmTick.Farmlands[f.OwnerId] = f;
                else FarmTick.Farmlands.Add(f.OwnerId, f);
                FarmTick.NotifyFarmsChanged();
            }

            // 解析好友牧场数据
            match = regexmeadow.Match(entry.URL);
            if (match.Success)
            {
                Meadow m = new Meadow(match.Groups["source"].Value,
                    entry.TimeStart,
                    Encoding.Default.GetString((byte[])entry.Content.Data));
                // 检测是否已有此牧场数据
                if (FarmTick.Meadows.ContainsKey(m.OwnerId)) FarmTick.Meadows[m.OwnerId] = m;
                else FarmTick.Meadows.Add(m.OwnerId, m);
                FarmTick.NotifyFarmsChanged();
            }

            discardIt = true;
        }
    }
}
