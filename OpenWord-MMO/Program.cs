using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

var Message = "Hello";
UdpClient Client = new UdpClient(11114);

while (true)
{
    var remoteEP = new IPEndPoint(IPAddress.Any, 11114);
    var data = Client.Receive(ref remoteEP);

    var sender = Client.Send(data, data.Length, remoteEP);
    Console.WriteLine(sender);

    if (sender > 20)
    {
        break;
    }

    if (sender < 20)
    {
        for (int i = 0; i > 1;)
        {
            Console.WriteLine(" ");
        }
        
    }
}
Client.Close();