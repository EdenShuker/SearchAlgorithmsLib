﻿using System.ComponentModel;
using System.Windows;
using MazeMVVM.ModelLib.Player;
using MazeMVVM.ViewModelLib.Player;

namespace MazeMVVM.ViewLib.SinglePlayer
{
    /// <summary>
    /// Interaction logic for SPGameWindow.xaml
    /// </summary>
    public partial class SPGameWindow : Window
    {
        private ISPViewModel vm;
        private bool isBackToMenuButtonPressed;

        public SPGameWindow(ISinglePlayerModel model)
        {
            InitializeComponent();
            vm = new SPViewModel(model);
            vm.Subscribe(mazeBoard);
            mazeBoard.PlayerMoved += ShowMsg;
            this.DataContext = vm;
            this.isBackToMenuButtonPressed = false;
        }

        private void ShowMsg(object sender, PlayerMovedEventArgs e)
        {
            // Check if player reached the goal
            if (this.vm.VM_Pos == this.vm.VM_GoalPos)
            {
                MessageWindow msgWindow = new MessageWindow();
                msgWindow.Msg = "Winner!";
                msgWindow.Show();
            }
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            vm.RestartGame();
        }

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            vm.SolveMaze();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            this.isBackToMenuButtonPressed = true;
            Window win = Application.Current.MainWindow;
            win.Show();
            this.Close();
        }

        private void SPGameWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (!this.isBackToMenuButtonPressed)
            {
                Window window = Application.Current.MainWindow;
                window.Close();
            }
        }
    }
}