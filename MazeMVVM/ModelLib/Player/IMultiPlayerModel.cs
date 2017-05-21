﻿using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeMVVM.ModelLib.Player
{
    public interface IMultiPlayerModel : IPlayerModel
    {
        event EventHandler GameEnded;

        Position PosOtherPlayer { get; set; }

        void Start();

        void CloseGame();

    }
}