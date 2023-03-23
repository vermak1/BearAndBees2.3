using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BearAndBees2._3
{
    internal class Bear
    {
        private readonly Pot _pot;

        private readonly Object _sync;

        public Bear(Pot pot, object sync)
        {
            _pot = pot;
            _sync = sync;
        }

        public void SleepAndWaitForEat()
        {
            Task t = Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    _pot.Event.WaitOne();
                    Console.WriteLine("Waiting took [{0}]", stopwatch.Elapsed.TotalSeconds);
                    await EatHoney();
                }
            });
        }

        private async Task EatHoney()
        {
            Task t = Task.Delay(5000);
            Console.WriteLine("Eating honey...");
            await t;
            lock (_sync)
            {
                _pot.Portions.Clear();
            }
            Console.WriteLine("All honey is gone");
        }
    }
}
