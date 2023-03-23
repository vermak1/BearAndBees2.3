using System;
using System.Diagnostics;
using System.Threading;

namespace BearAndBees2._3
{
    internal class Forest
    {
        private readonly Bear _bear;

        private readonly Pot _pot;

        private readonly Bee[] _bees;

        private readonly Object _syncRoot;

        public Forest(int potCapacity, int beesCount)
        {
            if (beesCount <= 0)
                throw new ArgumentException(nameof(beesCount));

            _syncRoot= new Object();
            _pot = new Pot(potCapacity);
            _bear = new Bear(_pot, _syncRoot);
            _bees = new Bee[beesCount];

            for (int i = 0; i < beesCount; i++)
                _bees[i] = new Bee(_syncRoot, _pot);
        }

        public void Start()
        {
            _bear.SleepAndWaitForEat();
            for (int i = 0; i < _bees.Length; i++)
                _bees[i].CollectHoney();

            Thread.Sleep(Int32.MaxValue);
        }
    }
}
