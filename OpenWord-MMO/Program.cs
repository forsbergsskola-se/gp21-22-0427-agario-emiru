﻿using System;
using System.Diagnostics.CodeAnalysis;

using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Xsl;

var Message = "";
var space = " ";
UdpClient Client = new UdpClient(11114);

while (true)
{
    var remoteEP = new IPEndPoint(IPAddress.Any, 11114);
    Console.WriteLine("Waiting for connection...");
    var data = Client.Receive(ref remoteEP);
    Console.WriteLine($"new connection from {remoteEP} ");
    var word = Encoding.ASCII.GetString(data);
    Console.WriteLine($"Word receieved {word} ");
    Message += word + space;
    Console.WriteLine($"Complete message {Message} ");

    var bytes = Encoding.ASCII.GetBytes(Message);
    var sent = Client.Send(bytes, bytes.Length, remoteEP);

    if (sent > 20)
    {
        break;
    }

    if (word.Contains(space))
    {
        break;
    }
}

Client.Close();