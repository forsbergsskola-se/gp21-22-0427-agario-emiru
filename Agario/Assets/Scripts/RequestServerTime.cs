using System;
using System.Collections;
using System.Collections.Generic;
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
      var Client = new TcpListener(44444);
      
      while (true)
      {
         Client.Start();
         var acceptClient = Client.AcceptTcpClient();
         var currentStream = acceptClient.GetStream();
         var currentDT = DateTime.Now;
         var bytes = Encoding.ASCII.GetBytes($"hello {currentDT}");
         currentStream.Read(bytes);

         var txt = txtobject;
         txt.text = currentStream.Read(bytes).ToString();
      }
      
   }

   public void Start()
   {
      SendRequest();
   }
}
