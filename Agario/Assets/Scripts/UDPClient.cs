using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.UI;


public class UDPClient : MonoBehaviour
{
    public string message = "";
    public Text txt;
    public Button Button;
    public bool buttonClicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UdpClient client = new UdpClient(11113);    // Client created
        var remoteEP = new IPEndPoint(IPAddress.Any, 11113);    //EndPoint created
        var data = client.Receive(ref remoteEP);
        var datta = Encoding.ASCII.GetString(data);
        var sent = message += datta;

        var bytte = Encoding.ASCII.GetBytes(sent);
        var sender = client.Send(bytte, bytte.Length, remoteEP);
        
        Debug.Log(sender);

        if ()
        {
            
        }
    }   
}
