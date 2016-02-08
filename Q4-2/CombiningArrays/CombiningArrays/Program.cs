using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombiningArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            CombineArrays ca = new CombineArrays();

            int[] A;
            int[] B;
            int k;
            //// Test 1
            int Test = 1;
            A = new int[] { 3, 6, 7 };
            B = new int[] { 2, 8, 9 };
            k = 0;

            int ans = 2;
            int res = ca.select(A, B, k);
            TestResult(res, ans, Test);

            // Test 2
            Test++;
            k = 5;

            ans = 9;
            res = ca.select(A, B, k);
            TestResult(res, ans, Test);


            //// Test 3
            Test++;
            A = new int[] { 3, 5, 6 };
            B = new int[] { 2, 8, 9, 10 };

            // A + B = 2, 3, 5, 6, 8, 9, 10

            k = 2;

            ans = 5;
            res = ca.select(A, B, k);
            TestResult(res, ans, Test);
            
            // Test 4
            Test++;
            A = new int[] { 1, 2, 3, 4};
            B = new int[] { 3, 5, 6, 8, 9 };

            // A + B = 1,2,3,3,4,5,6,8,9

            Console.WriteLine();
            Console.WriteLine("A = new int[] { 1, 2, 3, 4};");
            Console.WriteLine("B = new int[] { 3, 5, 6, 8, 9 };");
            Console.WriteLine();
            Console.WriteLine("0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 ");
            Console.WriteLine("1 | 2 | 3 | 3 | 4 | 5 | 6 | 8 | 9 ");
            Console.WriteLine();

            k = 3;

            ans = 3;
            res = ca.select(A, B, k);
            TestResult(res, ans, Test);

            // Test 5
            Test++;
            k = 7;

            ans = 8;
            res = ca.select(A, B, k);
            TestResult(res, ans, Test);

            // Test 6
            Test++;
            k = 4;

            ans = 4;
            res = ca.select(A, B, k);
            TestResult(res, ans, Test);

            // Test 7
            Test++;
            k = 3;

            ans = 2;
            res = ca.select(A, B, k);
            TestResult(res, ans, Test);

            // Test 
            Test++;
            A = new int[] { 2 };
            B = new int[] { 3 };

            k = 1;

            ans = 3;
            res = ca.select(A, B, k);
            TestResult(res, ans, Test);

            // Test 
            Test++;
            A = new int[] { 2 };
            B = new int[] { 3 };

            k = 1;

            ans = 3;
            res = ca.select(A, B, k);
            TestResult(res, ans, Test);
            Console.Read();
        }

        public static void TestResult(int results, int actualRes, int tstNumber)
        {
            if (results == actualRes)
                Console.WriteLine("Test " + tstNumber + ": passed - Answer: " + results);
            else
                Console.WriteLine("Test " + tstNumber + ": failed - Result: " + results + " should be " + actualRes);

        }
    }
}
