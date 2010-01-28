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
        Farmland Parent;
        int Status;
        int Number1;
        int Number2;
        public List<int> PickedList = new List<int>();
        static Regex regexplant = new Regex(@"{""a"":(?<planttype>\d+),""b"":(?<status>\d+),.*?""l"":(?<number1>\d+),""m"":(?<number2>\d+),""n"":[\[\{](?<pickedlist>.*?)[\]\}],.*?""q"":(?<planttime>\d+),.*?}");
        static Regex regexpicked = new Regex(@"""(?<uid>\d+?)"":\d+?");

        /// <summary>
        /// 作物是否还可以收取
        /// </summary>
        public override bool Available { get { return (Type > 0 && PickedList.IndexOf(Friends.MasterId) < 0 && (Number1 == 0 || Number1 != Number2)); } }

        /// <summary>
        /// 作物类构造函数
        /// </summary>
        /// <param name="parent">所属农场</param>
        /// <param name="response">服务器返回的json字符串</param>
        public Plant(Farmland parent, string response)
        {
            Parent = parent;
            Match m = regexplant.Match(response);
            Type = int.Parse(m.Groups["planttype"].Value);
            Status = int.Parse(m.Groups["status"].Value);
            Number1 = int.Parse(m.Groups["number1"].Value);
            Number2 = int.Parse(m.Groups["number2"].Value);
            MatchCollection mc = regexpicked.Matches(m.Groups["pickedlist"].Value);
            foreach (Match mp in mc) PickedList.Add(int.Parse(mp.Groups["uid"].Value));
            Name = ProductTypes.GetName(Type);
            Value = ProductTypes.GetPrice(Type);
            RipeTime = parent.SnapshotTime.AddSeconds(int.Parse(m.Groups["planttime"].Value) + ProductTypes.GetRipe(Type) - parent.ServerTime);
        }
    }
}
