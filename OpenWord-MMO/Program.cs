using System;
using System.Diagnostics.CodeAnalysis;

using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

var Message = "";
var space = " ";
UdpClient Client = new UdpClient(11114);

//TODO: you shouldnt be able to send more then 1 word
//TODO: Shouldnt be able to send more then 20 words

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
    Client.Send(bytes, bytes.Length, remoteEP);
    
}

Client.Close();