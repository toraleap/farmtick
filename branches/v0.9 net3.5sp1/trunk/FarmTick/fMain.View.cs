using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FarmTick
{
    public partial class fMain
    {
        private bool NotifyAll(ProductGroup g)
        {
            return g.RipeOffset > 0;
        }

        private bool NotifyValuable100(ProductGroup g)
        {
            return (g.RipeOffset > 0 && g.ExpectValue > 100);
        }

        private bool NotifyValuable300(ProductGroup g)
        {
            return (g.RipeOffset > 0 && g.ExpectValue > 300);
        }

        private bool NotifySelfonly(ProductGroup g)
        {
            return (g.RipeOffset > 0 && g.Parent.OwnerId == Friends.MasterId);
        }

        private bool NotifyNone(ProductGroup g)
        {
            return false;
        }

        private bool ListShowAll(ProductGroup g)
        {
            return g.RipeOffset > (tsbShowRiped.Checked ? -600 : 0);
        }

        private static int ListShowOneId = 0;
        private bool ListShowOne(ProductGroup g)
        {
            if (ListShowOneId == 0) ListShowOneId = Friends.MasterId;
            return (g.Parent.OwnerId == ListShowOneId && g.RipeOffset > (tsbShowRiped.Checked ? -600 : 0));
        }

        private void ChartShowSource()
        {
            string[] label = { "校友农场", "校友牧场", "公共牧场", "空间牧场", "空间农场", "公共农场"};
            double[] value = { 0, 0, 0, 0, 0, 0 };
            foreach (ProductGroup g in FarmTick.GetSortedGroups())
            {
                if (g.Available && g.Parent.OwnerId != Friends.MasterId)
                {
                    if (Friends.FriendMapXiaoyou.ContainsKey(g.Parent.OwnerId))
                    {
                        if (Friends.FriendMapQzone.ContainsKey(g.Parent.OwnerId))
                        {
                            if (g.Parent is Farmland)
                                value[5] += g.ExpectValue;
                            else
                                value[2] += g.ExpectValue;
                        }
                        else
                        {
                            if (g.Parent is Farmland)
                                value[0] += g.ExpectValue;
                            else
                                value[1] += g.ExpectValue;
                        }
                    }
                    else
                    {
                        if (g.Parent is Farmland)
                            value[4] += g.ExpectValue;
                        else
                            value[3] += g.ExpectValue;
                    }
                }
            }

            SetSerials(1, SeriesChartType.Doughnut);
            chtFarms.Series[0].Points.DataBindXY(label, value);
            chtFarms.Series[0].LegendText = "";
            chtFarms.Series[0]["PieLabelStyle"] = "Disabled"; 
            chtFarms.Legends[0].Title = "收益来源(不含自己)";
            chtFarms.ChartAreas[0].Area3DStyle.Enable3D = true;
        }

        private void ChartShowTimeBlock()
        {
            List<string> label = new List<string>();
            double[] valuef = { 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] valuem = { 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] values = { 0, 0, 0, 0, 0, 0, 0, 0 };
            DateTime now = DateTime.Now;
            for (int i = 0; i < 8; i++) label.Add(((now.Hour + i) % 24).ToString());
            foreach (ProductGroup g in FarmTick.GetSortedGroups())
            {
                int i = (24 + now.AddSeconds(g.RipeOffset).Hour - now.Hour) % 24;
                if (g.Available && g.RipeOffset < 3600 * 8 && i < 8)
                {
                    if (g.Parent.OwnerId == Friends.MasterId)
                    {
                        values[i] += g.ExpectValue;
                    }
                    else
                    {
                        if (g.Parent is Farmland)
                            valuef[i] += g.ExpectValue;
                        else
                            valuem[i] += g.ExpectValue;
                    }
                } 
            }

            SetSerials(3, SeriesChartType.StackedColumn);
            chtFarms.Series[0].Points.DataBindXY(label, valuef);
            chtFarms.Series[0].LegendText = "好友农场";
            chtFarms.Series[1].Points.DataBindXY(label, valuem);
            chtFarms.Series[1].LegendText = "好友牧场";
            chtFarms.Series[2].Points.DataBindXY(label, values);
            chtFarms.Series[2].LegendText = "自己";
            chtFarms.ChartAreas[0].AxisX.Title = "时间";
            chtFarms.ChartAreas[0].AxisY.Title = "收益";
            chtFarms.Legends[0].Title = "时间收益块图";
            chtFarms.ChartAreas[0].Area3DStyle.Enable3D = true;
        }

        private void SetSerials(int count, SeriesChartType type)
        {
            for (int i = 0; i < chtFarms.Series.Count; i++)
                if (i < count)
                {
                    chtFarms.Series[i].Enabled = true;
                    chtFarms.Series[i].ChartType = type;
                }
                else chtFarms.Series[i].Enabled = false;
        }
    }
}
