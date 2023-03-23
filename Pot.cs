using System;
using System.Collections.Generic;

namespace BearAndBees2._3
{
    internal class Pot
    {
        public readonly List<byte> Portions;
        public Pot(Int32 portionsNumber)
        {
            Portions = new List<byte>(portionsNumber);
        }
    }
}
