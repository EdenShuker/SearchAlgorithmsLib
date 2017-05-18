﻿using MazeMVVM.ModelLib;
using MazeMVVM.ModelLib.Settings;

namespace MazeMVVM.ViewModelLib.Settings
{
    public class SettingsViewModel : ViewModel, ISettingsViewModel
    {
        private ISettingsModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"></param>
        public SettingsViewModel(ISettingsModel model)
        {
            this.model = model;
        }

        public string ServerIP
        {
            get { return model.ServerIP; }
            set
            {
                model.ServerIP = value;
                NotifyPropertyChanged("ServerIP");
            }
        }

        public int ServerPort
        {
            get { return model.ServerPort; }
            set
            {
                model.ServerPort = value;
                NotifyPropertyChanged("ServerPort");
            }
        }

        public int MazeRows
        {
            get { return model.MazeRows; }
            set
            {
                model.MazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }

        public int MazeCols
        {
            get { return model.MazeCols; }
            set
            {
                model.MazeCols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }

        public int SearchAlgorithm
        {
            get { return model.SearchAlgorithm; }
            set
            {
                this.model.SearchAlgorithm = value;
                NotifyPropertyChanged("SearchAlgorithm");
            }
        }

        public void SaveSettings()
        {
            model.SaveSettings();
        }
    }
}