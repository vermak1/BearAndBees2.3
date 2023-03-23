using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace BearAndBees2._3
{
    internal class Bee
    {
        private readonly Random r;

        public Bee()
        {
            r = new Random();
        }

        public void CollectHoney(Pot pot, object syncRoot, Bear bear, Stopwatch stopwatch)
        {
            Task t = Task.Factory.StartNew(() =>
            {
                while (true) 
                {
                    Thread.Sleep(r.Next(500, 1000));//doing work
                    lock (syncRoot)
                    {
                        if (pot.Portions.Count == pot.Portions.Capacity)
                            continue;

                        pot.Portions.Add(byte.MaxValue);
                        if (pot.Portions.Count == pot.Portions.Capacity)
                        {
                            Console.WriteLine("Pot is full, waking bear up, it took [{0}]", stopwatch.Elapsed.TotalSeconds);
                            bear.Awake = true;
                            stopwatch.Restart();
                        }
                    }
                }
            });
        }
    }
}
