﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex1.Command
{
    public class CloseGameCommand : Command
    {
        public CloseGameCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, TcpClient client = null)
        {
            string nameOfGame = args[0];
            int code = this.Model.Close(nameOfGame);
            return "";
        }
    }
}