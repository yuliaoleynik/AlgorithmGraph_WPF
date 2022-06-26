using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGraph.Algorithms
{
    class Dijkstra
    {
        public Dijkstra(int[,] matrix, int s)
        {
            Initial(0, s);
            while (queue.Count > 0)
            {
                int u = getNextVertex();

                for (int i = 0; i < s; i++)
                {
                    if (matrix[u, i] > 0)
                    {
                        if (dist[i] > dist[u] + matrix[u, i])
                        {
                            dist[i] = dist[u] + matrix[u, i];
                        }
                    }
                }
            }
        }

        public double[] dist { get; set; }
        int getNextVertex()
        {
            var min = double.PositiveInfinity;
            int vertex = -1;

            foreach (int val in queue)
            {
                if (dist[val] <= min)
                {
                    min = dist[val];
                    vertex = val;
                }
            }
            queue.Remove(vertex);
            return vertex;
        }

        List<int> queue = new List<int>();
        public void Initial(int s, int len)
        {
            dist = new double[len];

            for (int i = 0; i < len; i++)
            {
                dist[i] = double.PositiveInfinity;
                queue.Add(i);
            }
            dist[0] = 0;
        }
    }
}

