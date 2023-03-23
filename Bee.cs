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
        public Bee(object sync, Pot pot)
        {
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
                        if (_pot.Portions.Count == _pot.Portions.Capacity)
                            continue;

                        _pot.Portions.Add(byte.MaxValue);
                        if (_pot.Portions.Count == _pot.Portions.Capacity)
                        {
                            Console.WriteLine("Pot is full, waking bear up");
                            _pot.Event.Set();
                        }
                    }
                }
            });
        }
    }
}
