﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Ex1.Command;
using Ex1.ModelLib;

namespace Ex1.ControllerLib
{
    public class Controller : IController
    {
        private Dictionary<string, ICommand> commands;
        private IModel model;

        public Controller()
        {
            this.model = new Model();
            // Add Commands
            this.commands = new Dictionary<string, ICommand>();
            this.commands.Add("generate", new GenerateMazeCommand(this.model));
            this.commands.Add("solve", new SolveMazeCommand(this.model));
            this.commands.Add("start", new StartGameCommand(this.model));
            this.commands.Add("list", new ListCommand(this.model));
            this.commands.Add("join", new JoinToGameCommand(this.model));
            this.commands.Add("play", new PlayCommand(this.model));
            this.commands.Add("close", new CloseGameCommand(this.model));
        }

        public string ExecuteCommand(string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
            {
                return "Command not found";
            }
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            return command.Execute(args, client);
        }

        public bool IsClientInGame(TcpClient client)
        {
            return model.IsClientInGame(client);
        }

    }
}