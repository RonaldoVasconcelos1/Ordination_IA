using System;
using static System.Console;
using System.Diagnostics;
using teste.Services;

namespace teste
{
    class Program
    {
        public const string DEFAULT_TIME_SPENT = "Time spent";

        static void Main(string[] args)
        {
            var ordenation = new Ordenation();
            var stopwatch = new Stopwatch();

            int option = 0;

            do
            {
                WriteLine();

                WriteLine($"The default size of the vector is as {ordenation.GetSize().ToString()}");

                WriteLine();

                WriteLine($"1 - Change vector size (if you change it, a new collection of numbers will be generated)");
                WriteLine("2 - MergeSort");
                WriteLine("3 - MergeSortRecursivo");
                WriteLine("4 - QuickSort");
                WriteLine("5 - BoobleSort");
                WriteLine("6 - Show all registered ranges");
                WriteLine("7 - End session");

                WriteLine();

                Write("Choose the option [1 - 7]: ");
                option = Convert.ToInt32(ReadLine());

                WriteLine();

                switch (option)
                {
                    case 1:
                        Write("Choose the size: ");
                        var size = Convert.ToInt32(ReadLine());
                        ordenation.SetSize(size);
                        WriteLine("Size changed successfully!");
                        break;
                    case 2:
                        stopwatch.Start();
                        ordenation.MergeSort();
                        stopwatch.Stop();
                        Logger.AddLog("MergeSort", ordenation.GetSize());
                        WriteLine($"{Logger.DEFAULT_MESSAGE} - {DEFAULT_TIME_SPENT}: {stopwatch.Elapsed}");
                        break;
                    case 3:
                        stopwatch.Start();
                        ordenation.MergeSortRecursivo(ordenation.MinSizeVector(), ordenation.MaxSizeVector());
                        stopwatch.Stop();
                        Logger.AddLog("MergeSortRecursivo", ordenation.GetSize());
                        WriteLine($"{Logger.DEFAULT_MESSAGE} - {DEFAULT_TIME_SPENT}: {stopwatch.Elapsed}");
                        break;
                    case 4:
                        ordenation.QuickSort(ordenation.MinSizeVector(), ordenation.MaxSizeVector());
                        Logger.AddLog("QuickSort", ordenation.GetSize());
                        WriteLine($"{Logger.DEFAULT_MESSAGE} - {DEFAULT_TIME_SPENT}: {stopwatch.Elapsed} ");
                        break;
                    case 5:
                        ordenation.BoobleSort();
                        Logger.AddLog("BoobleSort", ordenation.GetSize());
                        WriteLine($"{Logger.DEFAULT_MESSAGE} - {DEFAULT_TIME_SPENT}: {stopwatch.Elapsed}");
                        break;
                    case 6:
                        stopwatch.Start();
                        Logger.DisplayIntervals();
                        stopwatch.Stop();

                        WriteLine();
                        WriteLine("Press ENTER key ...");
                        ReadKey();
                        break;
                    default:
                        break;
                }

            } while (option > 0 && option < 7);
        }
    }
}
