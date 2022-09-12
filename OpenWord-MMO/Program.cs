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
var errormessage = "Error";
UdpClient Client = new UdpClient(11114);

while (true)
{
    var remoteEP = new IPEndPoint(IPAddress.Any, 11114);
    Console.WriteLine("Waiting for connection...");
    var data = Client.Receive(ref remoteEP);
    Console.WriteLine($"New connection from {remoteEP} ");
    var word = Encoding.ASCII.GetString(data);
    Console.WriteLine($"Word receieved {word} ");
    
    //TODO: if sentence contains errormessage THEN dont add with errormessage
    
    
    if (word.Length <= 20 && !word.Contains(space))
    {
        if (Sentence == "")
        {
            Sentence = word;
        }
        else if (Sentence.Contains(errormessage))
        {
            Sentence = word;
        }
        else
        {
            Sentence += space + word;
        }
    }
    else
    {
        Console.WriteLine("Errror: this is not working ");
        Sentence = errormessage;

    }

    var bytes = Encoding.ASCII.GetBytes(Sentence);
    Client.Send(bytes, bytes.Length, remoteEP);
    
    // WIth the 20 character check and the contains space check:
    //     - You want to validate the word, not the sentence
    //     - You want to do so before changing the sentence
    //     - Because, if the word is not valid, you do not want to change the sentence
    //     - Also, if you do not change the sentence (which means, the word was invalid)
    //     - Instead of sending the Sentence to the Client
    //     - You want to send an Error Message to the Client 
    //       IF(WORD IS VALID) THEN: CHANGE SENTENCE AND SEND SENTENCE TO CLIENT
    //       ELSE: DO NOT CHANGE SENTENCE AND SEND ERROR MESSAGE TO CLIENT 
    
    
}

Client.Close();