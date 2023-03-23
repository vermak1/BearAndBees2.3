using System;
using System.Collections.Generic;
using System.Threading;

namespace BearAndBees2._3
{
    internal class Pot
    {
        public readonly AutoResetEvent Event;


        public readonly List<byte> Portions;
        public Pot(Int32 portionsNumber)
        {
            if (portionsNumber <= 0)
                throw new ArgumentException(nameof(portionsNumber));

            Portions = new List<byte>(portionsNumber);
            Event = new AutoResetEvent(false);
        }
    }
}
