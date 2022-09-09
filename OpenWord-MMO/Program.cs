﻿using System;
using System.Diagnostics.CodeAnalysis;

using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Xsl;

var Sentence = "";
var space = ' ';
UdpClient Client = new UdpClient(11114);

while (true)
{
    var remoteEP = new IPEndPoint(IPAddress.Any, 11114);
    Console.WriteLine("Waiting for connection...");
    var data = Client.Receive(ref remoteEP);
    Console.WriteLine($"New connection from {remoteEP} ");
    var word = Encoding.ASCII.GetString(data);
    Console.WriteLine($"Word receieved {word} ");
    

    
    // message ""
    // " hello"
    // " hello world"

    if (Sentence == "")
    {
        Sentence = word;
    }
    else
    {
        Sentence += space + word;
    }

    var bytes = Encoding.ASCII.GetBytes(Sentence);
    Client.Send(bytes, bytes.Length, remoteEP);

    //TODO: letters < 20

    // if (Message.Length > 20 || Message.Contains(space))
    // {
    //     Console.WriteLine("Error: letters over 20 is not allowed or there is whitespace");
    // }
    // else if (!Message.Contains(space) || Message.Length < 20)
    // {
    //     
    //     Console.WriteLine($"Complete message {Message} ");
    // }
}

Client.Close();