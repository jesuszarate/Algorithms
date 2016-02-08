using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombiningArrays
{
    class CombineArrays
    {
        // A and B are each sorted into ascending order, and 0 <= k < |A|+|B| 
        // Returns the element that would be stored at index k if A and B were
        // combined into a single array that was sorted into ascending order.
        public int select(int[] A, int[] B, int k)
        {
            //return select(A, 0, |A|-1, B, 0, |B|-1, k);
            return select(A, 0, A.Length - 1, B, 0, B.Length - 1, k);

        }


        // 3 len = 1
        // 2 len = 1
        // k = 2
        public int select(int[] A, int loA, int hiA, int[] B, int loB, int hiB, int k)
        {
            // A[loA..hiA] is empty
            if (hiA < loA)
                return B[k - loA];

            // B[loB..hiB] is empty
            if (hiB < loB)
                return A[k - loB];

            // Get the midpoints of A[loA..hiA] and B[loB..hiB]
            int midA = (loA + hiA) / 2; // 1 / 2 = 0
            int midB = (loB + hiB) / 2; // 1 / 2 = 0

            // Figure out which one of four cases apply
            if (A[midA] <= B[midB]) // If A's midpoint element is less than B's
            {
                // Advance the start of A by one position
                //return select(A, loA+1, hiA, B, loB, hiB, k);


                // If k is greater than the mid, we won't need anything before 
                // the midpoint
                if (k > midA + midB) // is 8 > 0 -> yes
                // is 1 > 1+1 -> no
                {
                    //return select(A, $1, $2, B, $3, $4, k);
                    //return select(A, midA + 1, hiA, B, midB, hiB, k);
                    return select(A, midA + 1, hiA, B, midB, hiB, k);

                }
                else // k is less than mid, so we won't need anything after midpoint
                {
                    //return select(A, $5, %6, B, $7, $8, k);
                    return select(A, midA - hiA, midA, B, loB, hiB, k);

                }
            }
            else // If B's midpoint is less than A's

                // Advance the start of B by one
                //return select(A, loA, hiA, B, loB+1, hiB, k);

                if (k > midA + midB)
                {
                    //return select(A, $9, $10, B, $11, $12, k);
                    //return select(A, midA, hiA, B, midB + 1, hiB, k);
                    return select(A, midA, hiA, B, midB + 1, hiB, k);


                }
                else
                {
                    //return select(A, $13, $14, B, $15, $16, k);
                    //return select(A, loA, midA, B, loB + 1, midB, k);
//                    return select(A, loA, midA, B, midB + 1, hiA, k);
                    return select(A, loA, hiA, B, midB - hiB, midB, k);

                }
        }
    }
}
