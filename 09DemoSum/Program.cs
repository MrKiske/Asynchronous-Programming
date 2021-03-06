﻿namespace _09DemoSum
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var arraySize = 50000000;
            var array = BuildAnArray(arraySize);
           
                var stopwatch = Stopwatch.StartNew();
                var firstArray = array.Take(array.Length / 2);
                var lastArray = array.Skip(array.Length / 2);

                var arrayProcessorFirst = new ArrayProcessor(firstArray.ToArray(), 0, firstArray.ToList().Count);
                var arrayProcessorLast = new ArrayProcessor(lastArray.ToArray(), 0, lastArray.ToList().Count);

                Thread firstThread = new Thread(arrayProcessorFirst.CalculateSum);
                Thread lastThread = new Thread(arrayProcessorLast.CalculateSum);

                //var arrayProcessor = new ArrayProcessor(array, 0, arraySize);
                //arrayProcessor.CalculateSum();
                firstThread.Start();
                lastThread.Start();


                lastThread.Join();
                firstThread.Join();


                //var totalSum = arrayProcessor.Sum;
                var totalSum = arrayProcessorFirst.Sum + arrayProcessorLast.Sum;

                stopwatch.Stop();

                Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
                Console.WriteLine($"Sum: {totalSum}");
           
        }

        public static int[] BuildAnArray(int size)
        {
            var array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
