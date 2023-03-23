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

        public Forest(int potCapacity, int beesCount)
        {
            _bear = new Bear();
            _pot = new Pot(potCapacity);
            _bees = new Bee[beesCount];

            for (int i = 0; i < beesCount; i++)
                _bees[i] = new Bee();
        }

        public void Start()
        {
            Object sync = new Object();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            _bear.SleepAndWaitForEat(_pot, sync);
            for (int i = 0; i < _bees.Length; i++)
                _bees[i].CollectHoney(_pot, sync, _bear, stopwatch);

            Thread.Sleep(Int32.MaxValue);
        }
    }
}
