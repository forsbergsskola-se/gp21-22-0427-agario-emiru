using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Mono.Cecil;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UDPClient : MonoBehaviour
{


    public void forButton()
    {
        string message = "  ";
        UdpClient client = new UdpClient(11113);
        var remoteEP = new IPEndPoint(IPAddress.Any, 11112);
        
        var send = Encoding.ASCII.GetBytes(message);
        var sent = client.Send(send, send.Length, remoteEP);

        Debug.Log(sent);
    }

}
