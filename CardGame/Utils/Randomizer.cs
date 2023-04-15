using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Utils
{
    public class Randomizer
    {
        private readonly Random _random = new Random();

        public int GetRandomNumber(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}
