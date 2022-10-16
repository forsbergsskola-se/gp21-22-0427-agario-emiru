using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RequestServerTime : MonoBehaviour
{
   public Text txtobject;
   public void SendRequest()
   {
      var Client = new TcpClient();
      Client.Connect(IPAddress.Loopback, 11113);
      var stream = Client.GetStream();
      var buffer = new byte[200];
      stream.Read(buffer);
      var text = Encoding.ASCII.GetString(buffer);
      txtobject.text = text;

   }
   
}
