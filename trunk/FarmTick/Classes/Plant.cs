using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FarmTick
{
    // 农场作物类，表示一块耕地的情况
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

        public override bool Available { get { return (Type > 0 && PickedList.IndexOf(Friends.MasterId) < 0 && (Number1 == 0 || Number1 != Number2)); } }
        public override int UnifiedRipeTime { get { return PlantTime + RipeOffset; } }

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
