using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGraph.Algorithms
{
    class Bellman_Ford
    {
        public double[] distance { get; set; }

        public Bellman_Ford(int[,] matrix, int count)
        {
            distance = new double[count];
            var visited = new bool[count];
            int start = 0;

            for (var i = 0; i < count; i++)
            {
                distance[i] = double.PositiveInfinity;
                visited[i] = false;
            }

            distance[start] = 0;
            while ( start!= -1)
            {
                for (int i = 0; i < count; i++)
                    if ((matrix[start, i] + distance[start] < distance[i]) && matrix[start, i] != 0)
                    {
                        distance[i] = matrix[start, i] + distance[start];
                    }


                visited[start] = true;
                start = -1;
                double mindistance = double.PositiveInfinity;

                for (int i = 0; i < count; i++)
                if (!visited[i] && (distance[i] < mindistance))
                {
                    start = i; mindistance = distance[i];
                }
            }
            distance[0] = 0;
        }
    }
}
