using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Mono.Cecil;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class UDPClient : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TMP_InputField TextField;
    public void forButton()
    {
        string message = TextField.text;
        var space = ' ';
        var message2 = "";
        UdpClient client = new UdpClient(11112);
        var remoteEP = new IPEndPoint(IPAddress.Loopback, 11114);
        var send = Encoding.ASCII.GetBytes(message);
        var sent = client.Send(send, send.Length, remoteEP);
        var response = client.Receive(ref remoteEP);
        message = Encoding.ASCII.GetString(response);

        text.text = message;
        
        Debug.Log(sent);






    }
    
}
