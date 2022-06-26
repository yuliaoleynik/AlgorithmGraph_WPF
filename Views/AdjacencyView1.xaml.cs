using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AlgorithmGraph.ViewModels;
using AlgorithmGraph.Algorithms;
using System.Diagnostics;
using System;

namespace AlgorithmGraph.Views
{
    /// <summary>
    /// Логика взаимодействия для AdjaencyView1.xaml
    /// </summary>
    public partial class AdjacencyView1 : UserControl
    {
        private AdjacencyViewModel vm = new AdjacencyViewModel();
        int count;

        public AdjacencyView1()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            count = int.Parse(selectedItem.Content.ToString());
            vm.FillMatrix(count);
            DataContext = vm;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            vm.ResetMatrix(count);
            DataContext = vm;
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
            Stopwatch stopwatch = new Stopwatch();
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            if (selectedItem.Content.ToString() == "Дейкстри") 
            {
                if (checkMatrix())
                {
                    stopwatch.Start();
                    var method = new Dijkstra(vm.AdjacencyMatrix, count);
                    stopwatch.Stop();

                    var item = method.dist;
                    string test = "";

                    TimeSpan ts = stopwatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

                    string timeResult = "Час виконання алгоритму Дейкстри = " + elapsedTime + "\n";
                    string result = "Алгоритм Дейкстри" + "\n";

                    for (int i = 0; i < item.Length; i++)
                    {
                        result += "Вага найкоротшого шляху до вершини " + i + " = " + item[i] + "\n";
                        test += item[i] + " ";
                    }

                    textresult.Text = result;
                    timeresult.Text = timeResult;
                    MessageBox.Show(test);
                }
            }
            if (selectedItem.Content.ToString() == "Беллмана-Форда") 
            {
                stopwatch.Start();
                var method = new Bellman_Ford(vm.AdjacencyMatrix, count);
                stopwatch.Stop();

                var item = method.distance;

                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

                string timeResult = "Час виконання алгоритму Беллмана-Форда = " + elapsedTime + "\n";
                string result = "Алгоритм Беллмана-Форда" + "\n";
                string test = "";

                for (int i = 0; i < item.Length; i++)
                {
                    result += "Вага найкоротшого шляху до вершини " + i + " = " + item[i] + "\n";
                    test += item[i] + " ";
                }
                textresult.Text = result;
                timeresult.Text = timeResult;
                MessageBox.Show(test);
            }
            if (selectedItem.Content.ToString() == "Флойда-Воршелла") 
            {
                stopwatch.Start();
                var method = new Floyd_Warshall(vm.AdjacencyMatrix, count);
                stopwatch.Stop();

                var item = method.distance;

                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

                string timeResult = "Час виконання алгоритму Флойда-Варшала = " + elapsedTime + "\n";
                string result = "Алгоритм Флойда-Воршелла" + "\n";

                for (int i = 0; i < count; ++i)
                {
                    for (int j = 0; j < count; ++j)
                    {
                        if (item[i, j] == double.PositiveInfinity)
                            result += "Вага шдяху від " + i + " до " + j + " = " + double.PositiveInfinity + "\n";
                        else
                            result += "Вага шдяху від " + i + " до " + j + " = " + item[i, j] + "\n";
                    }
                }
                textresult.Text = result;
                timeresult.Text = timeResult;
            }
        }

        public bool checkMatrix()
        {
            for (int i = 0; i < vm.AdjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < vm.AdjacencyMatrix.GetLength(1); j++)
                {
                    if (vm.AdjacencyMatrix[i, j] < 0) { MessageBox.Show("Від'ємна вага! " + i + "-" + j); return false; }
                    if (i == j && vm.AdjacencyMatrix[i, j] > 0) { MessageBox.Show("Не повинно бути петель(вершина " + i + ")"); return false; }
                }
            }
            return true;
        }
    }    
}

