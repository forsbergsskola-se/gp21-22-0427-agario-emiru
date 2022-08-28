using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

var Message = " ";
UdpClient Client = new UdpClient(11114);


while (true)
{
    var remoteEP = new IPEndPoint(IPAddress.Any, 11114);
    var data = Client.Receive(ref remoteEP);
    var datta = Encoding.ASCII.GetString(data);
    var sent = Message += datta;

    var byyte = Encoding.ASCII.GetBytes(sent);
    
    var sender = Client.Send(byyte, byyte.Length, remoteEP);

    if (sender > 20)
    {
        break;  
    }

    if (sender < 20)
    {
        Console.WriteLine(sender);
    }

}

Client.Close();