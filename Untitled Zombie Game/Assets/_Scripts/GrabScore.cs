using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GrabScore : MonoBehaviour
{
    public float Score;
    public TMP_Text ScoreHold;
    public TMP_InputField Inputholder;
    //public List<TMP_Text> TextScore = new List<TMP_Text>();
    //public List<TMP_Text> ShowScore = new List<TMP_Text>();
    //public List<string> NameHolder = new List<string>();
    //public List<float> ScoreHolder = new List<float>();
    public GameObject PanelSwitch;
    public GameObject PanelSwitch2;
    public GameObject contentWindow;
    public GameObject recalltextObject;

    // Start is called before the first frame update
    void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Score_Logs/");
        Score = PlayerPrefs.GetFloat("Score");
        ScoreHold.text = Score.ToString();
        PanelSwitch.SetActive(false);
        PanelSwitch2.SetActive(true);
    }
    public void CreateTextFile()
    {
        if (Inputholder.text == "")
        {
            return;
        }

        //Create the text file at the already created directory in the start function
        string textDocumentName = Application.streamingAssetsPath + "/Score_Logs/" + "Score" + ".txt";

        if (!File.Exists(textDocumentName))
        {
            File.WriteAllText(textDocumentName, "");
        }

        //Any text that is still in the input field will be sent to the score text file
        File.AppendAllText(textDocumentName, "Name: " + Inputholder.text + " Score: " + Score.ToString() + "\n");
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonPress()
    {
        PanelSwitch.SetActive(true);
        PanelSwitch2.SetActive(false);

        //Get the file from its directory or path
        string readFromFilePath = Application.streamingAssetsPath + "/Score_Logs/" + "Score" + ".txt";

        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

        foreach (string line in fileLines)
        {
            Debug.Log("TextHolder");

            GameObject Test = Instantiate(recalltextObject, contentWindow.transform);

            recalltextObject.GetComponent<TMP_Text>().text = line;
        }
        GameObject New = Instantiate(recalltextObject, contentWindow.transform);
        recalltextObject.GetComponent<TMP_Text>().text = "Name: " + Inputholder.text + " Score: " + Score.ToString();
        PlayerPrefs.SetString("CurrentScoreName", Inputholder.text);
        PlayerPrefs.SetFloat("CurrentScore", Score);

        recalltextObject.GetComponent<TMP_Text>().text = "";
        //UpdateScore();
    }

    public void MainMenuPress()
    {
        SceneManager.LoadScene(0);
    }
}