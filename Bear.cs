using System;
using System.Threading;
using System.Threading.Tasks;

namespace BearAndBees2._3
{
    internal class Bear
    {
        public Boolean Awake { get; set; }

        public Bear()
        {
            Awake = false;
        }
        public void SleepAndWaitForEat(Pot pot, object sync)
        {
            Task t = Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    if (!Awake)
                    {
                        Console.WriteLine("Bear is sleeping...");
                        Thread.Sleep(500);
                        continue;
                    }
                    await EatHoney(pot, sync);
                }
            });
        }

        private async Task EatHoney(Pot pot, object sync)
        {
            Task t = Task.Delay(5000);
            Console.WriteLine("Eating honey...");
            await t;
            lock (sync)
            {
                Awake = false;
                pot.Portions.Clear();
            }
            Console.WriteLine("All honey is gone");
        }
    }
}
