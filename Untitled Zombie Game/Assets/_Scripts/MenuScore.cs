using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class MenuScore : MonoBehaviour
{
    public GameObject PanelSwitch;
    public GameObject PanelSwitch2;
    public GameObject contentWindow;
    public GameObject recalltextObject;

    // Start is called before the first frame update
    void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Score_Logs/");
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonPress()
    {
        PanelSwitch.SetActive(true);
        PanelSwitch2.SetActive(false);

        //Create the text file at the already created directory in the start function
        string textDocumentName = Application.streamingAssetsPath + "/Score_Logs/" + "Score" + ".txt";

        if (!File.Exists(textDocumentName))
        {
            File.WriteAllText(textDocumentName, "");
        }

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
        recalltextObject.GetComponent<TMP_Text>().text = "Name: " + PlayerPrefs.GetString("CurrentScoreName)" + " Score: " + PlayerPrefs.GetFloat("CurrentScore"));

        recalltextObject.GetComponent<TMP_Text>().text = "";
        //UpdateScore();
    }

    public void MainMenuPress()
    {
        PanelSwitch.SetActive(false);
        PanelSwitch2.SetActive(true);
    }
}
