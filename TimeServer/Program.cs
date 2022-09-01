using System;
using System.Net.Sockets;
using System.Text;

var tcpListener = new TcpListener(44445);


while (true)
{
     tcpListener.Start();
     var AcceptClient = tcpListener.AcceptTcpClient();
     var currentStream = AcceptClient.GetStream();
     var DT = DateTime.Now;
     var bytes = Encoding.ASCII.GetBytes($"Hello {DT}");
     currentStream.Write(bytes);
     currentStream.Close();
     AcceptClient.Close();
}



