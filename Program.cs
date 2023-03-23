using System;

namespace BearAndBees2._3
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Forest forest = new Forest(1000, 2);
                forest.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: {0}", ex.Message);
                Environment.Exit(1);
            }
        }
    }

    
}
