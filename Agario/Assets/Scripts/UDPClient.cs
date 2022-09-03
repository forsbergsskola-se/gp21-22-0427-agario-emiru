using System;
using System.Collections;
using System.Collections.Generic;
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
        var space = " ";
        string message = TextField.text;
        UdpClient client = new UdpClient(11112);
        var remoteEP = new IPEndPoint(IPAddress.Loopback, 11114);
        var send = Encoding.ASCII.GetBytes(message);
        var sent = client.Send(send, send.Length, remoteEP);
        var response = client.Receive(ref remoteEP);
        message = Encoding.ASCII.GetString(response);

        if (TextField.text.Contains(space))
        {
            Debug.Log("error");
        }
        else
        {
            text.text = message;

            Debug.Log(sent);
        }

        if (message.Length > 20)
        {
            Debug.Log("Error");
        }
    }
    

}
