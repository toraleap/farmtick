using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FarmTick
{
    /// <summary>
    /// 农场作物类，继承自Product，表示一块耕地的情况
    /// </summary>
    [Serializable]
    public class Plant : Product
    {
        int Status;
        int PlantTime;
        int Number1;
        int Number2;
        public List<int> PickedList = new List<int>();
        int RipeOffset { get { return ProductTypes.GetRipe(Type); } }
        static Regex regexplant = new Regex(@"{""a"":(?<planttype>\d+),""b"":(?<status>\d+),.*?""l"":(?<number1>\d+),""m"":(?<number2>\d+),""n"":[\[\{](?<pickedlist>.*?)[\]\}],.*?""q"":(?<planttime>\d+),.*?}");
        static Regex regexpicked = new Regex(@"""(?<uid>\d+?)"":\d+?");

        /// <summary>
        /// 作物是否还可以收取
        /// </summary>
        public override bool Available { get { return (Type > 0 && PickedList.IndexOf(Friends.MasterId) < 0 && (Number1 == 0 || Number1 != Number2)); } }
        /// <summary>
        /// 获取作物的成熟时间
        /// </summary>
        public override int UnifiedRipeTime { get { return PlantTime + RipeOffset; } }

        /// <summary>
        /// 作物类构造函数
        /// </summary>
        /// <param name="response">服务器返回的json字符串</param>
        /// <param name="servertime">快照时间</param>
        public Plant(string response, int servertime)
        {
            Match m = regexplant.Match(response);
            Type = int.Parse(m.Groups["planttype"].Value);
            Status = int.Parse(m.Groups["status"].Value);
            Number1 = int.Parse(m.Groups["number1"].Value);
            Number2 = int.Parse(m.Groups["number2"].Value);
            MatchCollection mc = regexpicked.Matches(m.Groups["pickedlist"].Value);
            foreach (Match mp in mc) PickedList.Add(int.Parse(mp.Groups["uid"].Value));
            PlantTime = int.Parse(m.Groups["planttime"].Value) - servertime;
        }
    }
}
