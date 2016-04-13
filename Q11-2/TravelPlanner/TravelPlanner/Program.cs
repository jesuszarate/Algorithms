using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
    class Program
    {
        private static Random rand;
        private static int seed;
        private static int distance = 2905;

        static void Main(string[] args)
        {
            int[] hotels = new int[] { 0, 9, 23, 75, 77, 212, 269, 310, 371, 398, 503, 596, 762, 825, 2046 };
            //int[] hotels = new int[] { 0, 50, 100, 300, 400, 600, 800 };
            //int[] hotels = new int[] { 0, 50, 100, 200, 300 };
            //int[] hotels = new int[] { 400, 802, 1200 };
            //int[] hotels = new int[] { 0, 375, 400, 425, 800 };
            //int[] hotels = new int[] { 400, 802, 1200, 1602, 2000, 2402 };
            //int[] hotels = new int[] { 400, 795, 802, 1198, 1210, 1587, 1607, 1992, 2000 };
            // hotels = new int[] { 370, 420, 785, 805, 1195, 1215, 1587, 1607, 1992, 2000 };

            int size = 15;
            //hotels = randArr(size, distance);
            String prettyArr = "new int[] { ";
            foreach (int i in hotels)
            {
                prettyArr += i + ",";
            }
            prettyArr = prettyArr.Remove(prettyArr.Length - 1);
            prettyArr += "}";
            Console.WriteLine(prettyArr);

            Console.WriteLine("Min " + MinimumPenalty(hotels));
            Console.WriteLine("Min " + DynamicMinimumPenalty(hotels));


            seed = new Random().Next();
            //Time(n => 25 + n, MinimumPenalty);
            //Console.WriteLine();
            Time(n => 25 << n, DynamicMinimumPenalty);
            Console.WriteLine("here");
            Console.ReadKey();
        }

        public static void Time(Func<int, int> Size, Func<int[], int> MinPenaltyMethod)
        {
            rand = new Random(seed);
            Stopwatch timer = new Stopwatch();
            for (int i = 0; i < 9; i++)
            {
                int size = Size(i);
                int[] values = RandomArray(size, 10 * size);
                Array.Sort(values);
                //int[] values = randArr(size, distance);
                long previousTicks = timer.ElapsedTicks;
                timer.Reset();
                timer.Start();
                int longest = MinPenaltyMethod(values);
                timer.Stop();
                Console.WriteLine(String.Format("Size = {0}, length = {1}, {2}",
                    size,
                    longest,
                    TimeReport(timer, previousTicks)));
            }
        }

        public static string TimeReport(Stopwatch timer, long previousTicks)
        {
            double elapsedTime = (1.0 * timer.ElapsedTicks) / Stopwatch.Frequency;
            double previousTime = (1.0 * previousTicks) / Stopwatch.Frequency;
            string ratio = (previousTime == 0) ? "" : (elapsedTime / previousTime).ToString("F2");
            return String.Format("elapsed = {0} sec, ratio = {1}", elapsedTime.ToString("E2"), ratio);
        }

        private static int[] RandomArray(int size, int maxValue)
        {
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = rand.Next(maxValue) + 1;
            }
            return result;
        }


        public static int[] randArr(int size, int dist)
        {
            int[] randArr = new int[size];
            randArr[0] = 0;
            Random random = new Random();
            for (int i = 1; i < size; i++)
            {
                int rand = random.Next(randArr[i - 1] + 1, dist / (size - i));
                randArr[i] = rand;
            }
            return randArr;
        }

        // Returns the minimum penalty that it is possible to incur when driving from the hotel 
        // that is hotel[i] miles from New York to the final hotel, which is hotel[hotel.Length-1] 
        // miles from New York.  Assume that 0 <= i < hotel.Length and that
        // 0 = hotel[0] < hotel[1] < hotel[2] < ... < hotel[hotel.Length-1]
        public static int MinimumPenalty(int[] hotel, int i)
        {
            if (i == hotel.Length - 1)
                return 0;

            int min = Int32.MaxValue;

            for (int j = i + 1; j < hotel.Length; j++)
            {
                int penalty = MinimumPenalty(hotel, j) + (int)Math.Pow(400 - (hotel[j] - hotel[i]), 2);
                min = Math.Min(min, penalty);
            }
            return min;
        }


        /// <summary>
        ///  Returns the minimum penalty that it is possible to incur when driving from the first hotel 
        /// (which is in New York) to the final hotel (which is in San Francisco).  The mileage from New York
        /// to each of the hotels on the route is given by the hotel array, where 
        ///  0 = hotel[0] < hotel[1] < hotel[2] < ... < hotel[hotel.Length-1]
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public static int MinimumPenalty(int[] hotel)
        {
            return MinimumPenalty(hotel, 0);
        }

        // Returns the minimum penalty that it is possible to incur when driving from the hotel 
        // that is hotel[i] miles from New York to the final hotel, which is hotel[hotel.Length-1] 
        // miles from New York.  Assume that 0 <= i < hotel.Length and that
        // 0 = hotel[0] < hotel[1] < hotel[2] < ... < hotel[hotel.Length-1].  
        public static int DynamicMinimumPenalty(int[] hotel, int i, Dictionary<int, int> cache)
        {
            if (i == hotel.Length - 1)
                return 0;

            int result;
            if (cache.TryGetValue(i, out result))
            {
                return result;
            }

            int min = Int32.MaxValue;

            for (int j = i + 1; j < hotel.Length; j++)
            {
                int penalty = DynamicMinimumPenalty(hotel, j, cache) + (int)Math.Pow(400 - (hotel[j] - hotel[i]), 2);
                min = Math.Min(min, penalty);
            }
            cache[i] = min;
            return min;
        }

        // Returns the minimum penalty that it is possible to incur when driving from the first hotel 
        // (which is in New York) to the final hotel (which is in San Francisco).  The mileage from New York
        // to each of the hotels on the route is given by the hotel array, where 
        // 0 = hotel[0] < hotel[1] < hotel[2] < ... < hotel[hotel.Length-1]
        public static int DynamicMinimumPenalty(int[] hotel)
        {
            return DynamicMinimumPenalty(hotel, 0, new Dictionary<int, int>());
        }

        public static int t1(int[] hotel, int i)
        {
            int min = 0;
            for (int j = i + 1; j < hotel.Length; j++)
            {
                int prob = Math.Abs(400 - (hotel[j] - hotel[i]));
                if (j == i + 1)
                    min = prob;

                min = Math.Min(min, prob);
            }
            return min;
        }

        public static int t(int[] hotel)
        {
            int min = 0;
            for (int i = 0; i < hotel.Length; i++)
            {
                int l = t(hotel, i);
                if (i == 0)
                    min = l;

                min = Math.Max(min, l);
            }
            return min;
        }

        public static int t(int[] hotel, int i)
        {
            int min = 0;
            int k = 0;
            for (int j = i + 1; j < hotel.Length; j++)
            {
                int prob = Math.Abs(400 - (hotel[j] - hotel[i])) + t(hotel, i + 1);
                if (k == 0)
                {
                    k++;
                    min = prob;
                }
                min = Math.Min(min, prob);
            }
            return min;
        }
    }
}
