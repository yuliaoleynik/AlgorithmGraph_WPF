using System;
using System.Collections.Generic;
using System.Windows;
using AlgorithmGraph.Models;

namespace AlgorithmGraph.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        #region Constructor

        public MainViewModel()
        {
            // Blank
        }

        #endregion

        private void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}