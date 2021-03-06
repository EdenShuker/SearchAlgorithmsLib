﻿using System.Net.Sockets;
using MazeLib;
using ServerProject.ModelLib;

namespace ServerProject.ControllerLib.Command
{
    public class JoinToGameCommand : Command
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model">Model of server.</param>
        public JoinToGameCommand(IModel model) : base(model)
        {
        }

        public override ForwardMessageEventArgs Execute(string[] args, TcpClient client = null)
        {
            string nameOfGame = args[0];
            Maze maze = this.Model.JoinTo(nameOfGame, client);
            return new ForwardMessageEventArgs(client, maze.ToJSON());
        }

        public override Checksum Check(string[] args)
        {
            Checksum checksum = new Checksum();
            if (args.Length != 1)
            {
                checksum.Valid = false;
                checksum.ErrorMsg = "Invalid number of arguments";
            }
            else
            {
                checksum.Valid = true;
            }
            return checksum;
        }
    }
}