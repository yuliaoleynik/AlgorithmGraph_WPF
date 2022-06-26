using QuickGraph;

namespace AlgorithmGraph.Models
{
    /// <summary>
    /// Класс двунаправленного графа с заданными вершинами и рёбрами
    /// </summary>
    public class GraphModel : BidirectionalGraph<GraphVertex, GraphEdge>
    { 
        public GraphModel() { }

        public GraphModel(bool allowParallelEdges)
            : base(allowParallelEdges) { }
    }
}
