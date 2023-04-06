using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lec04
using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using TMPro;
using System.Threading;
using StarterAssets;

public class ClientScript : MonoBehaviour
{
    int int1, int2, int3;
    float xvalue, yvalue, zvalue;
    private Thread chatThread;
    private Thread posThread; //for position exchange
    string fo = "";
    string clMSG;
    public TMP_Text tmp;
    private string checkText; //checks to see if text is same as CSMSG so we only display once
    public bool newMSG = false;
    String userText = "test";
    public string input = "est";
    public static string input2 = "";
    public string inputCheck; //compared to input, if different we know a new msg has been entered, we then send it in update
    public GameObject myCube;
    public GameObject osText;
    private static byte[] outBuffer = new byte[1024];
    private static byte[] buf = new byte[1024];
    private static IPEndPoint remoteEP;
    private static IPEndPoint ChatEP;
    public GameObject CubeObject;

    private static EndPoint remoteClient;

    private static Socket clientSoc;

    private byte[] byteArray;
    private float[] ArrayExample;

    private Vector3 LastPos;

    public PrefabEnemies prefabSpawner;
    public WaveTest waveManager;

    public static void StartClient()
    {
        try
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            remoteEP = new IPEndPoint(ip, 8889);

            clientSoc = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);

            remoteClient = new IPEndPoint(IPAddress.Any, 0);

        }
        catch (Exception e)
        {
            Debug.Log("Exception: " + e.ToString());
        }
    }
    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log(input);
    }
    public void ReadStringInput2(string s) //for ip address input
    {
        input2 = s;
        Debug.Log(input2);
    }

    public static bool realIP(string userInput)
    {
        IPAddress adr;

        return IPAddress.TryParse(userInput, out adr) && adr.ToString() == userInput;
    }

    public void StartChatClient()
    {
        //if (realIP(input2))
        //{
        byte[] buffer = new byte[512];
        //String userText;
        bool run = true;
        // Setup our end point (server)
        try
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            //IPAddress ip = Dns.GetHostAddresses("mail.bigpond.com")[0]; //DNS will translate a URL to an IP
            IPEndPoint serverEP = new IPEndPoint(ip, 52030);
            //Setup our client socket
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // Attempt a connection
                Console.WriteLine("Connecting to server...");
                client.Connect(serverEP);
                Console.WriteLine("Connected to IP: {0}", client.RemoteEndPoint.ToString());
                int recv = client.Receive(buffer);

                while (true)
                {
                    buffer = new byte[512];
                    userText = input;
                    userText += " -Gamer1<br>";
                    byte[] userMSG = Encoding.ASCII.GetBytes(userText);
                    client.Send(userMSG);

                    client.Receive(buffer);
                    clMSG = Encoding.ASCII.GetString(buffer);
                    Debug.Log(clMSG);

                    fo = clMSG;

                    if (userText == "exit")
                    {
                        break;
                    }
                }
                // Loop
                // get user input
                // send to server
                Console.WriteLine("From Server: {0}", Encoding.ASCII.GetString(buffer, 0, recv));
                // Release socket resources
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (ArgumentNullException anexc)
            {
                Console.WriteLine("ArgumentNullException: {0}", anexc.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("Socket exception: {0}", se);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unnexpected exception: {0}", e);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e);
        }
    }
    //else
    //{
    //    Debug.Log("invalid ip");
    //}

    //}

    // Start is called before the first frame update
    void Start()
    {
        myCube = GameObject.Find("Cube");


        //chatThread = new Thread(StartChatClient);
        //chatThread.Start();


        //posThread = new Thread(StartClient);
        //posThread.Start();
        StartClient();
        Console.ReadKey();
        //StartChatClient();
    }

    // Update is called once per frame

    public bool masterGame = false;

    float timeTick = 0;
    float tickRate = 1; //1 per second

    void Update()
    {
        tmp.text = clMSG;

        outBuffer = new byte[1024];

        timeTick += Time.deltaTime;


        string clientName = "CLIENT1";
        string toSend = clientName + "," + CubeObject.transform.position.x.ToString() + "," + CubeObject.transform.position.y.ToString() + "," + CubeObject.transform.position.z.ToString() + ", END";

        outBuffer = Encoding.ASCII.GetBytes(toSend);
        clientSoc.SendTo(outBuffer, remoteEP);


        buf = new byte[1024];
        int1 = clientSoc.ReceiveFrom(buf, ref remoteClient);

        int numClients = 0;
        int numZombs = 0;
        string num = Encoding.ASCII.GetString(buf);
        string[] numClient = num.Split(",");

        if (numClient.Length > 3)
        {
            return;
        }
        numClients = Convert.ToInt32(numClient[0]);
        numZombs = Convert.ToInt32(numClient[1]);

        if (numClients == 1 && masterGame == false)
        {
            masterGame = true;
            prefabSpawner.masterMPGame = true;
            waveManager.masterMPGame = true;
        }

        for (int i = 0; i < numClients; ++i)
        {
            buf = new byte[1024];
            int1 = clientSoc.ReceiveFrom(buf, ref remoteClient);

            string positionData1 = Encoding.ASCII.GetString(buf);
            string[] splitPosData1 = positionData1.Split(",");


            if (splitPosData1.Length < 4)
            {
                continue;
            }

            string clientName1 = splitPosData1[0];
            string posX = splitPosData1[1];
            string posY = splitPosData1[2];
            string posZ = splitPosData1[3];
            try
            {
                if (GameObject.Find(clientName1) == null && clientName1 != clientName)
                {
                    GameObject cube = Instantiate(GameObject.Find("MultiplayerCapsule"));
                    cube.transform.name = clientName1;
                    cube.transform.position = new Vector3(float.Parse(posX), float.Parse(posY), float.Parse(posZ));
                }
                else if (clientName1 != clientName)
                {
                    GameObject client = GameObject.Find(clientName1);
                    client.transform.position = new Vector3(float.Parse(posX), float.Parse(posY), float.Parse(posZ));
                }
            }
            catch (Exception e)
            {
                ;
            }
        }

        for (int i = 0; i < numZombs; ++i)
        {
            buf = new byte[1024];
            int1 = clientSoc.ReceiveFrom(buf, ref remoteClient);

            string positionData1 = Encoding.ASCII.GetString(buf);
            string[] splitPosData1 = positionData1.Split(",");

            if (splitPosData1.Length < 5)
            {
                continue;
            }

            string zombName1 = splitPosData1[0];
            string posX = splitPosData1[1];
            string posY = splitPosData1[2];
            string posZ = splitPosData1[3];
            string zombHP = splitPosData1[4];

            if (zombName1.StartsWith("zomb") == true)
            {
                GameObject zombPool = GameObject.Find("OnionZombie2 1_POOL");
                if (zombPool == null)
                {
                    GameObject newZomb = EnemyPool.Spawn(prefabSpawner.Enemy1, new Vector3(Convert.ToSingle(posX), Convert.ToSingle(posY), Convert.ToSingle(posZ)), Quaternion.identity);
                }
                else if (zombPool.transform.childCount < numZombs)
                {
                    GameObject newZomb = EnemyPool.Spawn(prefabSpawner.Enemy1, new Vector3(Convert.ToSingle(posX), Convert.ToSingle(posY), Convert.ToSingle(posZ)), Quaternion.identity);
                }
                else
                {
                    if (zombPool != null)
                    {
                        if (timeTick > 0.15f)
                        {
                            zombPool.transform.GetChild(i).transform.position = new Vector3(float.Parse(posX), float.Parse(posY), float.Parse(posZ));
                            Health zombHP1 = zombPool.transform.GetChild(i).transform.gameObject.GetComponent<Health>();
                            zombHP1.currentHealth = Convert.ToInt32(zombHP);
                        }
                    }
                }
            }
        }

        if (masterGame == true)
        {
            GameObject zombPool = GameObject.Find("OnionZombie2 1_POOL");
            if (zombPool != null)
            {
                for (int i = 0; i < zombPool.transform.childCount; ++i)
                {
                    GameObject zomb = zombPool.transform.GetChild(i).gameObject;
                    Health zombHP = zombPool.transform.GetChild(i).gameObject.GetComponent<Health>();

                    string zombName = "zomb" + i.ToString();
                    string zombSend = zombName + "," + zomb.transform.position.x.ToString() + "," + zomb.transform.position.y.ToString() + "," + zomb.transform.position.z.ToString() + "," + zombHP.currentHealth.ToString() + ", END";

                    outBuffer = Encoding.ASCII.GetBytes(zombSend);
                    clientSoc.SendTo(outBuffer, remoteEP);
                }
            }
        }
        else
        {
            //GameObject zombPool = GameObject.Find("OnionZombie2 1_POOL");
            //if (zombPool != null && timeTick > 0.15f)
            //{
            //    for (int i = 0; i < zombPool.transform.childCount; ++i)
            //    {
            //        GameObject zomb = zombPool.transform.GetChild(i).gameObject;
            //        Health zombHP = zombPool.transform.GetChild(i).gameObject.GetComponent<Health>();

            //        string zombName = "HPzomb" + "," + i.ToString();
            //        string zombSend = zombName + "," + zombHP.currentHealth.ToString() + ", END";

            //        outBuffer = Encoding.ASCII.GetBytes(zombSend);
            //        clientSoc.SendTo(outBuffer, remoteEP);
            //    }
            //}
        }

        if (timeTick > 0.15f)
        {
            timeTick = 0;
        }

        //int1 = clientSoc.ReceiveFrom(buf, ref remoteClient);
        //float.TryParse(Encoding.ASCII.GetString(buf, 0, int1), out xvalue);
        //Debug.Log(xvalue);

        //int2 = clientSoc.ReceiveFrom(buf, ref remoteClient);
        //float.TryParse(Encoding.ASCII.GetString(buf, 0, int2), out yvalue);
        //Debug.Log(yvalue);

        //int3 = clientSoc.ReceiveFrom(buf, ref remoteClient);
        //float.TryParse(Encoding.ASCII.GetString(buf, 0, int3), out zvalue);
        //Debug.Log(zvalue);

        if (Input.GetKeyDown("1"))
        {
            osText.GetComponent<TMP_InputField>().Select();
        }
        else if (Input.GetKeyDown("2"))
        {
            print("2 key was pressed");
            Cursor.visible = false;
            CubeObject.GetComponent<StarterAssetsInputs>().OnApplicationFocus(false);
            CubeObject.SetActive(true);
        }

    }
}
