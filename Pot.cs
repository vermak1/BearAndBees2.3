using System;
using System.Collections.Generic;

namespace BearAndBees2._3
{
    internal class Pot
    {
        private readonly List<byte> _portions;

        public Boolean IsFull => _portions.Count == _portions.Capacity;
        public Pot(Int32 portionsNumber)
        {
            if (portionsNumber <= 0)
                throw new ArgumentException(nameof(portionsNumber));

            _portions = new List<byte>(portionsNumber);
        }

        public void AddOnePortion(byte portion)
        {
            _portions.Add(portion);
        }

        public void RemoveAllPortions() 
        {
            _portions.Clear();
        }
    }
}
