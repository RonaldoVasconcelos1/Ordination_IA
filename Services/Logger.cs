using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;

namespace teste.Services
{
    public class Logger
    {
        public const string DEFAULT_VECTOR_SIZE = "Vector Size";
        public const string DEFAULT_MESSAGE = "Successful sorting";
        private static List<string> Intervals = new List<string>();

        public static void AddLog(string method, int sizeVector)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Intervals.Add($"{method} - {DEFAULT_VECTOR_SIZE}: {sizeVector.ToString()} - {Program.DEFAULT_TIME_SPENT}: {stopwatch.Elapsed}");
            stopwatch.Stop();
        }

        public static void DisplayIntervals()
        {

            foreach (var item in Intervals)
            {
                WriteLine(item);
            }

        }
    }
}