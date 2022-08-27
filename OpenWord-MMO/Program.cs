using System.Net;
using System.Net.Sockets;

UdpClient port = new UdpClient(444446);     // Created port

while (true)
{
    var EndPoint = new IPEndPoint(IPAddress.Any, 11000);
    var data = port.Receive(ref EndPoint);
}