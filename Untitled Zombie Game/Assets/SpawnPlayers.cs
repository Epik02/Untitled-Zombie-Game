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
    public int NumberOfPlayers = 2;

    //private float[] holder;

    public bool check = false;

    //Client Code:
    private static byte[] outBuffer = new byte[512];
    private static IPEndPoint ClientEP;
    //private static IPEndPoint IPChatEP;
    private static EndPoint remoteServer;
    //private static EndPoint ChatEP;

    private static Socket ClientSocket;

    public String Display;

    /*private static void StartClient()
    {
        try
        {

            
            IPAddress ip = IPAddress.Parse("127.0.0.1"); //Testing (use 127.0.0.1)
            ClientEP = new IPEndPoint(ip, 8889);
            ChatEP = new IPEndPoint(ip, 8888);

            ClientSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);

            remoteServer = new IPEndPoint(IPAddress.Any, 0);


        }
        catch (Exception e)
        {
            Debug.Log("Exception: " + e.ToString());
        }
    }*/
    private void SendMessage()
    {
        //ClientSocket.Bind(ClientEP);
        //ClientSocket.Connect(ClientEP);
        outBuffer = Encoding.ASCII.GetBytes(Display);
        ClientSocket.SendTo(outBuffer, ClientEP);



        //byte[] data = new byte[512];
        //int rec = ClientSocket.ReceiveFrom(outBuffer, ref remoteServer);
        //holder = new float[rec / 4];
        //Buffer.BlockCopy(outBuffer, 0, data, 0, rec);

        // Debug.Log(holder[0]);

        int rec = ClientSocket.Receive(outBuffer);
        //int.TryParse(Encoding.ASCII.GetString(outBuffer, 0, rec), out NumberOfPlayers);

        Debug.Log(rec);

        outBuffer = Encoding.ASCII.GetBytes(Display);
        ClientSocket.SendTo(outBuffer, ClientEP);
        ClientSocket.Close();
        //return 0;
        //NumberOfPlayers = rec;
        //ClientSocket.Disconnect(true);
        //ClientSocket.Close();
        //ClientSocket.Close();
    }

    private void Start()
    {
        //StartClient();
        for (int i = 0; i <= NumberOfPlayers; i++)
        {
            Instantiate(PlayerPreFabContent, SpawnLocations[i].transform.position, Quaternion.identity);
        }
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
