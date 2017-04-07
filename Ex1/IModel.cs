﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using SearchAlgorithmsLib;

namespace Ex1
{
    public interface IModel
    {
        Maze GenerateMaze(string name, int rows, int cols);

        Solution<Position> SolveMaze(string name, int algorithm);

        Maze StartGame(string nameOfGame, int rows, int cols);

        string[] GetAvailableGames();

        Maze JoinTo(string nameOfGame);

        string Play(string move, TcpClient player);

        int Close(string nameOfGame);
    }
}