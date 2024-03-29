﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fiddler;

namespace FarmTick
{
    /// <summary>
    /// Fiddler代理数据捕获模式类
    /// </summary>
    public static class DataFiddler
    {
        static Regex regexurl = new Regex(@"(?:http://)?(?:happyfarm|nc|mc)\.(?:xiaoyou|qzone)\.qq\.com/(?:cgi-bin/cgi_|api\.php)");
        static Regex regexfriends1 = new Regex(@"(?:http://)?happyfarm\.(?<source>xiaoyou|qzone)\.qq\.com/api\.php\?mod=friend");
        static Regex regexfriends2 = new Regex(@"(?:http://)?nc\.(?<source>xiaoyou|qzone)\.qq\.com/cgi-bin/cgi_farm_getFriendList\?mod=friend");
        static Regex regexfmaster = new Regex(@"(?:http://)?nc\.(?<source>xiaoyou|qzone)\.qq\.com/cgi-bin/cgi_farm_index\?mod=user&act=run(?:&flag=.*?)?$");
        static Regex regexfarmland = new Regex(@"(?:http://)?nc\.(?<source>xiaoyou|qzone)\.qq\.com/cgi-bin/cgi_farm_index\?mod=user&act=run.*?&ownerId=(?<ownerid>\d+)");
        static Regex regexmeadow = new Regex(@"(?:http://)?mc\.(?<source>xiaoyou|qzone)\.qq\.com/cgi-bin/cgi_enter\?");
        static Regex regexmeadowproduct = new Regex(@"(?:http://)?mc\.(?<source>xiaoyou|qzone)\.qq\.com/cgi-bin/cgi_post_product");
        /// <summary>
        /// 获取是否正在进行数据捕获
        /// </summary>
        public static bool IsCapturing { get { return FiddlerApplication.IsStarted(); } }

        /// <summary>
        /// 启动数据捕获
        /// </summary>
        public static void Capture()
        {
            try
            {
                FiddlerApplication.BeforeResponse += OnBeforeResponse;
                if (Properties.Settings.Default.AutoProxy)
                    FiddlerApplication.Startup(8877, true, false);
                else
                    FiddlerApplication.Startup(8877, false, false);
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
                Fiddler.FiddlerApplication.Shutdown();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void OnBeforeResponse(Session session)
        {
            // 验证URL是否需要处理
            if (session.responseCode == 200 && regexurl.Match(session.url).Success) ParseSession(session);
        }

        private static void ParseSession(Session session)
        {
            Match match;

            session.utilDecodeResponse();

            // 解析好友列表数据
            match = regexfriends1.Match(session.url);
            if (match.Success)
            {
                Friends.ParseFriend(session.url,
                    session.GetResponseBodyAsString());
            }
            match = regexfriends2.Match(session.url);
            if (match.Success)
            {
                Friends.ParseFriend(session.url,
                    session.GetResponseBodyAsString());
            }

            // 解析自己农场数据
            match = regexfmaster.Match(session.url);
            if (match.Success)
            {
                Friends.ParseMaster(session.url,
                    session.GetResponseBodyAsString());
                Farmland f = new Farmland(session.Timers.ServerBeginResponse,
                    session.url,
                    session.GetResponseBodyAsString());
                // 检测是否已有此农场数据
                if (FarmTickManager.Farmlands.ContainsKey(f.OwnerId)) FarmTickManager.Farmlands[f.OwnerId] = f;
                else FarmTickManager.Farmlands.Add(f.OwnerId, f);
                FarmTickManager.NotifyFarmsChanged();
            }

            // 解析好友农场数据
            match = regexfarmland.Match(session.url);
            if (match.Success)
            {
                Farmland f = new Farmland(session.Timers.ServerBeginResponse,
                    session.url,
                    session.GetResponseBodyAsString());
                // 检测是否已有此农场数据
                if (FarmTickManager.Farmlands.ContainsKey(f.OwnerId)) FarmTickManager.Farmlands[f.OwnerId] = f;
                else FarmTickManager.Farmlands.Add(f.OwnerId, f);
                FarmTickManager.NotifyFarmsChanged();
            }

            // 解析好友牧场数据
            match = regexmeadow.Match(session.url);
            if (match.Success)
            {
                Meadow m = new Meadow(session.Timers.ServerBeginResponse,
                    match.Groups["source"].Value,
                    session.GetResponseBodyAsString());
                // 检测是否已有此牧场数据
                if (FarmTickManager.Meadows.ContainsKey(m.OwnerId)) FarmTickManager.Meadows[m.OwnerId] = m;
                else FarmTickManager.Meadows.Add(m.OwnerId, m);
                FarmTickManager.NotifyFarmsChanged();
            }

            // 解析牧场生产数据
            //match = regexmeadowproduct.Match(session.url);
            //if (match.Success)
            //{
            //}
        }
    }
}
