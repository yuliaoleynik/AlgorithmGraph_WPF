using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGraph.Algorithms
{
     public class Floyd_Warshall
    {
		public double[,] distance { get; set; }

        public Floyd_Warshall(int[,] matrix, int count)
        {
			distance = new double[count, count];

			for (int i = 0; i < count; ++i)
				for (int j = 0; j < count; ++j)
				{
					if (i != j && matrix[i, j] == 0)
					{
						distance[i, j] = double.PositiveInfinity;
					}
					else { distance[i, j] = matrix[i, j]; }
				}

			for (int k = 0; k < count; ++k)
			{
				for (int i = 0; i < count; ++i)
				{
					for (int j = 0; j < count; ++j)
					{
						if (distance[i, k] + distance[k, j] < distance[i, j])
							distance[i, j] = distance[i, k] + distance[k, j];
					}
				}
			}
		}
    }
}
