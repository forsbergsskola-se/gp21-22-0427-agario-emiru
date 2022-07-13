using System.Net.Sockets;
using System.Text;

var tcpListener = new TcpListener(44444);
tcpListener.Start();

var AcceptClient = tcpListener.AcceptTcpClient();
var currentStream = AcceptClient.GetStream();
var bytes = Encoding.ASCII.GetBytes("Hello");
currentStream.Write(bytes);
currentStream.Close();
AcceptClient.Close();