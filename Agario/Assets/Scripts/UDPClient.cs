using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Mono.Cecil;
using UnityEngine;


public class UDPClient : MonoBehaviour
{
    public string message = "";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var remoteEP = new IPEndPoint(IPAddress.Any, 11113);
        UdpClient client = new UdpClient(11113);

        var data = client.Receive(ref remoteEP);
        var send = client.Send(data, data.Length, remoteEP);
        var sent = Encoding.ASCII.GetString();
        var read = sent;
        Debug.Log(read);
    }   
}
