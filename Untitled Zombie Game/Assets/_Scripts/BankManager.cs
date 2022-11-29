using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BankManager : MonoBehaviour
{

    int bankScore = 500;
    string stringBankScore = "0";
    public static ScoreManager sm;
    public Movement mplayer;
    bool intrigger = false;
    public string filePath;
    public static ScoreManager scoreInstance;

    private void Start()
    {
        StreamReader sr = new StreamReader("save.txt");
        stringBankScore = sr.ReadToEnd();
        bankScore = int.Parse(stringBankScore);
        Debug.Log(bankScore);
        sr.Close();
    }

    private void deposit()
    {
        StreamWriter sw = new StreamWriter("save.txt");
        bankScore = bankScore + 100;
        ScoreManager.instance.DecreaseScore(100);
        sw.WriteLine(bankScore);
        Debug.Log(bankScore);
        sw.Close();
    }

    private void withdraw()
    {
        StreamWriter sw = new StreamWriter("save.txt");
        bankScore = bankScore - 100;
        ScoreManager.instance.ChangeScore(100);
        sw.WriteLine(bankScore);
        Debug.Log(bankScore);
        sw.Close();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            intrigger = true;
            Debug.Log("true");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            intrigger = false;
            Debug.Log("false");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (intrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.L) == true)
            {
                deposit();
            }
            if (Input.GetKeyDown(KeyCode.K) == true)
            {
                withdraw();
            }
        }
    }
}
