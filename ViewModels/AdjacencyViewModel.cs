using System;
using System.Linq;
using System.Windows.Input;
using AlgorithmGraph.Commands;
using AlgorithmGraph.Models;
using System.Windows;

namespace AlgorithmGraph.ViewModels
{
    internal class AdjacencyViewModel : GraphViewModel<GraphModel>
    {
        public int[,] AdjacencyMatrix { get; set; }

        private DelegateCommand _updateGraphCommand;

        public ICommand UpdateGraphCommand
        {
            get
            {
                if (_updateGraphCommand == null)
                {
                    _updateGraphCommand = new DelegateCommand(UpdateGraph);
                }
                return _updateGraphCommand;
            }
        }

        private void UpdateGraph()
        {
            Model = new GraphModel(false);
            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
                Model.AddVertex(new GraphVertex { Number = i });

            var vx = Model.Vertices.ToList();

            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
                {
                    if (AdjacencyMatrix[i, j] != 0)
                    {
                        if (i == j)
                        {
                            MessageBox.Show($"Не повинно бути петель(вершина {i})");
                        }
                        else if (Model.ContainsEdge(vx[j], vx[i]))
                        {
                            MessageBox.Show($"Не повинно бути кратних ребер(вершини {j}, {i})");
                        }
                        else { Model.AddEdge(new GraphEdge(vx[i], vx[j])); }
                    }
                }
            }
        }

        public void FillMatrix(int count)
        {
            AdjacencyMatrix = new int[count, count];
            var rnd = new Random();
            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
                for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
                    AdjacencyMatrix[i, j] = 0;

            OnPropertyChanged("AdjacencyMatrix");
        }

        public void ResetMatrix(int count)
        {
            FillMatrix(count);
        }

        public AdjacencyViewModel()
        {

        }
    }
}
