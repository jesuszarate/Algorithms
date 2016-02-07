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

            // Test 1
            int[] A = {3,5,6};
            int[] B = {2,8,9};
            int k = 8;

            ca.select(A, B, k);

            // Test 2
            k = 2;

            ca.select(A, B, k);

            // Test 3
            A = new int[]{ 3, 5, 6 };
            B = new int[]{ 2, 8, 9 };

            k = 2;
        }
    }
}
