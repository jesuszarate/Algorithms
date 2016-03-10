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
            for (int i = 0; i < m; i++)
            {
                items[i] = new HashSet<int>();
            }
        }

        public void insertOrUpdate(int item, int weight)
        {
            if (weights.ContainsKey(item))
            {
                int w = weights[item];
                if(weight < w)
                {
                    weights[item] = weight;
                }
            }   
            /*
            int w = weights[item];

            if(!items[item].Contains(weight))
                if (w > weight)
                {
                    if (weights.ContainsKey(item))
                    {
                        weights[item] = weight;
                        items[item].Add(weight);
                    }
                    weights.Add(item, weight);
                    items[item].Add(weight);
                }                       
             */
        }

        public int deleteMin()
        {
            if (weights.Count == 0)
                throw new Exception("PQ is empty");

            int min = weights[0];

            foreach (int i in weights.Keys)
            {
                if (min > weights[i])
                {
                    min = weights[i];
                }
            }
            return min;
        }
            
    }
}
