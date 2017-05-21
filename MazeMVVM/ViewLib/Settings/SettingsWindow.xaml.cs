﻿using System.ComponentModel;
using System.Windows;
using MazeMVVM.ModelLib.Settings;
using MazeMVVM.ViewModelLib.Settings;

namespace MazeMVVM.ViewLib.Settings
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private ISettingsViewModel vm;
        private bool isButtonPressed;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SettingsWindow()
        {
            InitializeComponent();
            ISettingsModel model = new ApplicationSettingsModel();
            vm = new SettingsViewModel(model);
            // define vm as data context
            this.DataContext = vm;
            this.isButtonPressed = false;
        }

        /// <summary>
        /// Called when OK button is pressed. Save settings and Return to main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.isButtonPressed = true;
            vm.SaveSettings();
            BackToMenu();
        }

        /// <summary>
        /// Called when Cancel button is pressed. Return to main window without 
        /// saving changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.isButtonPressed = true;
            BackToMenu();
        }

        private void BackToMenu()
        {
            Window win = Application.Current.MainWindow;
            win.Show();
            this.Close();
        }

        private void SettingsWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (!this.isButtonPressed)
            {
                Window window = Application.Current.MainWindow;
                window.Close();
            }
        }
    }
}