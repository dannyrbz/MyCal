﻿using System;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRChat
{
    public class LiveChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}