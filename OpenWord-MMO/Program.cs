using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

//TODO: Need Constructor to pass port number

//TODO: Receiver Method
//TODO: Send Method that sends data on that socket
//TODO:Close everything when done

var port = Console.ReadLine();
string data = "";

UdpClient Client = new UdpClient();     // Created port
var remoteEP = new IPEndPoint(IPAddress.Any, 44445);

while (true)
{
    var receive = Client.Receive(ref remoteEP);
    
}