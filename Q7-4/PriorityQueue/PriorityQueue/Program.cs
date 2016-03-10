using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
        }


    }
    class PQ
    {
        private HashSet<int>[] items;
        private Dictionary<int, int> weights;

        public PQ(int m)
        {
            weights = new Dictionary<int, int>();
            items = new HashSet<int>[m];
            for (int i = 0; i <= m; i++)
            {
                items[i] = new HashSet<int>();
            }
        }

        public void insertOrUpdate(int item, int weight)
        {
            if (!weights.ContainsKey(item))
            {
                weights.Add(item, weight);
                items[weight].Add(item);
            }
            else
            {
                int oldWeight = weights[item];
                if (weight < oldWeight)
                {
                    weights[item] = weight; // Replace weight of this item
                    items[oldWeight].Remove(item); // Remove item from old weight
                    items[weight].Add(item); // Add the item to its new weight
                }
            }

        }

        public int deleteMin()
        {
            if (weights.Count == 0)
                throw new Exception("PQ is empty");

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Count > 0)
                {
                    int min = items[i].ElementAt(0);
                    items[0].Remove(min);
                    weights.Remove(min);
                    return min;
                }
            }
            return -1;
        }

    }
}
