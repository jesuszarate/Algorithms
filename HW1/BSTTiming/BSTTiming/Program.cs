using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTTiming
{
    class Program
    {
        /// <summary>
        /// Duration of one second
        /// </summary>
        public const int DURATION = 1000;

        public static int SIZE;

        static void Main(string[] args)
        {
            String line;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Jesus Zarate\Desktop\timingResults.txt"))
            {
                //line = "Size\tTime";
                line = "Time";
                Console.WriteLine(line);
                file.WriteLine(line);

                for (int i = 10; i <= 20; i++)
                {
                    SIZE = (int)Math.Pow(2, i);
                    line = RunBSTTiming(SIZE) + "";
                    //line = SIZE + "\t" + RunBSTTiming(SIZE);

                    Console.WriteLine(line);
                    file.WriteLine(line);
                }
            }
            Console.WriteLine("Finished");
            Console.Read();
        }

        public static double RunBSTTiming(int size)
        {
            // Construct a randomly-generated balanced 
            //binary search tree
            SortedSet<int> bst = new SortedSet<int>();
            for(int i = 0; i < size; i++)
            {
                bst.Add(i);
            }

            // Create a stopwatch
            Stopwatch sw = new Stopwatch();

            // Keep increasing the number of repetitions until one second elapses.
            double elapsed = 0;
            long repetitions = 1;
            do
            {
                repetitions *= 2;
                sw.Restart();
                for (int i = 0; i < repetitions; i++)
                {
                    for (int elt = 0; elt < size; elt++)
                    {
                        bst.Contains(elt);
                    }
                }
                sw.Stop();
                elapsed = msecs(sw);
            } while (elapsed < DURATION);
            double totalAverage = elapsed / repetitions;

            // Create a stopwatch
            sw = new Stopwatch();

            // Keep increasing the number of repetitions until one second elapses.
            elapsed = 0;
            repetitions = 1;
            do
            {
                repetitions *= 2;
                sw.Restart();
                for (int i = 0; i < repetitions; i++)
                {
                    for (int elt = 0; elt < size; elt++)
                    {
                        //BinarySearch(data, elt);
                    }
                }
                sw.Stop();
                elapsed = msecs(sw);
            } while (elapsed < DURATION);
            double overheadAverage = elapsed / repetitions;

            // Display the raw data as a sanity check
            //Console.WriteLine("Total avg:    " + totalAverage.ToString("G2"));
            //Console.WriteLine("Overhead avg: " + overheadAverage.ToString("G2"));

            // Return the difference, averaged over size
            return (totalAverage - overheadAverage)/ size;
        }

        /// <summary>
        /// Returns the number of milliseconds that have elapsed on the Stopwatch.
        /// </summary>
        public static double msecs(Stopwatch sw)
        {
            return (((double)sw.ElapsedTicks) / Stopwatch.Frequency) * 1000;
        }

    }
}
