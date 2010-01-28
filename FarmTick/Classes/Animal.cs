using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FarmTick
{
    /// <summary>
    /// 牧场动物类，继承自Product，表示一只动物的情况
    /// </summary>
    [Serializable]
    public class Animal : Product
    {
        Meadow Parent;
        int GrowTimeNext;
        bool Hungry;
        int Status;
        int StatusNext;
        static Regex regexanimal = new Regex(@"{.*?""cId"":(?<animaltype>\d+),.*?""growTimeNext"":(?<growtimenext>\d+),""hungry"":(?<hungry>\d+),.*?""status"":(?<status>\d+),""statusNext"":(?<statusnext>\d+),.*?}");
        
        /// <summary>
        /// 动物是否还可以收取
        /// </summary>
        public override bool Available { get { return (Type > 0 && (StatusNext == 3 || Status == 4) && (Properties.Settings.Default.ShowHungry || !Hungry)); } }

        /// <summary>
        /// 动物类构造函数
        /// </summary>
        /// <param name="parent">所属牧场</param>
        /// <param name="response">服务器返回的json字符串</param>
        public Animal(Meadow parent, string response)
        {
            Parent = parent;
            Match m = regexanimal.Match(response);
            Type = int.Parse(m.Groups["animaltype"].Value);
            GrowTimeNext = int.Parse(m.Groups["growtimenext"].Value);
            Hungry = (int.Parse(m.Groups["hungry"].Value) == 1);
            Status = int.Parse(m.Groups["status"].Value);
            StatusNext = int.Parse(m.Groups["statusnext"].Value);
            Name = ProductTypes.GetName(Type);
            Value = ProductTypes.GetPrice(Type);
            RipeTime = Parent.SnapshotTime.AddSeconds(GrowTimeNext);
        }
    }
}
