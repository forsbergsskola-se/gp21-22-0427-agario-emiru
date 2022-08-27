﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

UdpClient Client = new UdpClient(11114);

while (true)
{
    
    var remoteEP = new IPEndPoint(IPAddress.Any, 11114);
    var data = Client.Receive(ref remoteEP);
    
    
    var sender = Client.Send(data, data.Length, remoteEP);
    var message = Encoding.ASCII.GetString(data);
    Console.WriteLine(message.Length);

}
Client.Close();