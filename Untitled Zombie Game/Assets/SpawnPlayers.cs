using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject PlayerPreFabContent;
    public GameObject[] SpawnLocations;
    public int NumberOfPlayers;

    public bool check = true;

    //Client Code:
    private static byte[] outBuffer = new byte[512];
    private static IPEndPoint ClientEP;
    //private static IPEndPoint IPChatEP;

    private static EndPoint remoteServer;
    //private static EndPoint ChatEP;

    private static Socket ClientSocket;

    public String Display;

    private static void StartClient()
    {
        try
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1"); //Testing (use 127.0.0.1)
            ClientEP = new IPEndPoint(ip, 8889);
            //ChatEP = new IPEndPoint(ip, 8888);

            ClientSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);

            remoteServer = new IPEndPoint(IPAddress.Any, 0);

        }
        catch (Exception e)
        {
            Debug.Log("Exception: " + e.ToString());
        }
    }
    private void SendMessage()
    {
        //ClientSocket.Connect(ClientEP);
        outBuffer = Encoding.ASCII.GetBytes(Display);
        ClientSocket.SendTo(outBuffer, ClientEP);


        int rec = ClientSocket.ReceiveFrom(outBuffer, ref remoteServer);
        Debug.Log(rec);
        NumberOfPlayers = rec;
        //ClientSocket.Disconnect(true);
        //ClientSocket.Close();
        //ClientSocket.Close();
    }

    private void Start()
    {
        StartClient();
    }

    private void Update()
    {
        if (check == true)
        {
            SendMessage();
            NumberOfPlayers--;
            for (int i = 0; i <= NumberOfPlayers; i++)
            {
                Instantiate(PlayerPreFabContent, SpawnLocations[i].transform.position, Quaternion.identity);
            }
            check = false;
        }
    }
}
