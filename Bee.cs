using System;
using System.Threading.Tasks;
using System.Threading;

namespace BearAndBees2._3
{
    internal class Bee
    {
        private readonly Random r;

        private readonly Object _sync;

        private readonly Pot _pot;

        private readonly AutoResetEvent _bearReadyToEatEvent;
        public Bee(object sync, Pot pot, AutoResetEvent bearEvent)
        {
            _bearReadyToEatEvent = bearEvent;
            r = new Random();
            _sync = sync;
            _pot = pot;
        }

        public void CollectHoney()
        {
            Task t = Task.Factory.StartNew(() =>
            {
                while (true) 
                {
                    Thread.Sleep(r.Next(500, 1000));//doing work
                    lock (_sync)
                    {
                        if (_pot.IsFull)
                            continue;

                        _pot.AddOnePortion(byte.MaxValue);
                        if (_pot.IsFull)
                        {
                            Console.WriteLine("Pot is full, waking bear up");
                            _bearReadyToEatEvent.Set();
                        }
                    }
                }
            });
        }
    }
}
