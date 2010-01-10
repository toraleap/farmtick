using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FarmTick
{
    // 牧场动物类，表示一只动物的情况
    [Serializable]
    public class Animal : Product
    {
        int GrowTimeNext;
        bool Hungry;
        int Status;
        int StatusNext;
        static Regex regexanimal = new Regex(@"{.*?""cId"":(?<animaltype>\d+),.*?""growTimeNext"":(?<growtimenext>\d+),""hungry"":(?<hungry>\d+),.*?""status"":(?<status>\d+),""statusNext"":(?<statusnext>\d+),.*?}");

        public override bool Available { get { return (Type > 0 && (StatusNext == 3 || Status == 4) && !Hungry); } }
        public override int UnifiedRipeTime { get { return (GrowTimeNext > 0) ? GrowTimeNext : 99999999; } }

        public Animal(string response)
        {
            Match m = regexanimal.Match(response);
            Type = int.Parse(m.Groups["animaltype"].Value);
            GrowTimeNext = int.Parse(m.Groups["growtimenext"].Value);
            Hungry = (int.Parse(m.Groups["hungry"].Value) == 1);
            Status = int.Parse(m.Groups["status"].Value);
            StatusNext = int.Parse(m.Groups["statusnext"].Value);
        }
    }
}
