namespace AlgorithmGraph.Models
{
    /// <summary>
    /// Класс вершины графа
    /// </summary>
    public class GraphVertex
    {
        public int Number { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            return Number.ToString();
        }

        #endregion
    }
}
