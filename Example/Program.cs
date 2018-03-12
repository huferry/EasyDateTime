using System;
using System.Diagnostics;
using EasyDateTime;

namespace Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            var count = 0;

            Action act = () => Console.WriteLine(
                $"Count:[{count++}] | Elapsed millisecond:[{stopwatch.ElapsedMilliseconds}]");

            stopwatch.Start();

            act.DoEvery(300.Milliseconds(), 10)
                .WithoutWaiting(() =>
                {
                    // performed when finished all actions
                    Console.WriteLine("Finished.");
                });

            Console.WriteLine("This line is written without waiting.");
        }
    }
}