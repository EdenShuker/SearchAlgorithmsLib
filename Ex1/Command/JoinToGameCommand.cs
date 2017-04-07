﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using Newtonsoft.Json.Linq;

namespace Ex1.Command
{
    public class JoinToGameCommand : Command
    {
        public JoinToGameCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, TcpClient client = null)
        {
            string nameOfGame = args[0];
            Maze maze = this.Model.JoinTo(nameOfGame, client);
            JObject mazeObj = JObject.Parse(maze.ToJSON());
            JObject mergedObj = new JObject();
            mergedObj["Name"] = nameOfGame;
            mergedObj.Merge(mazeObj);
            return mergedObj.ToString();
        }
    }
}