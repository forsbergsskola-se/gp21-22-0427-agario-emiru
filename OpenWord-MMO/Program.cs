using System;
using System.Diagnostics.CodeAnalysis;

using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Xsl;

var Sentence = "";
var space = ' ';
var errorMessage = "Error";

var errorSentence = "";
UdpClient Client = new UdpClient(11114);

while (true)
{
    var remoteEP = new IPEndPoint(IPAddress.Any, 11114);
    Console.WriteLine("Waiting for connection...");
    var data = Client.Receive(ref remoteEP);
    Console.WriteLine($"New connection from {remoteEP} ");
    var word = Encoding.ASCII.GetString(data);
    Console.WriteLine($"Word receieved {word} ");
    
    
    
    if (word.Length <= 20 && !word.Contains(space))
    {
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
    }
    else
    {
        Console.WriteLine("Error: this is not working ");
        var errorBytes = Encoding.ASCII.GetBytes(errorMessage);
        Client.Send(errorBytes, errorBytes.Length, remoteEP);
    }

     
    
}

Client.Close();