using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class PauseMenus : MonoBehaviour
{
    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject advMenuUI;

    public GameObject CurrentPlayer;
    public GameObject CurrentUI;

    void Start()
    {
        CurrentPlayer.GetComponent<StarterAssetsInputs>().OnApplicationFocus(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update Being Called (Input");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Input Called");
            if (!GameIsPaused)
            //{
               // Resume();
           // }
            //else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        CurrentPlayer.GetComponent<StarterAssetsInputs>().OnApplicationFocus(true);
        pauseMenuUI.SetActive(false);
        CurrentPlayer.SetActive(true);
        CurrentUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Debug.Log("Pause1");
        CurrentPlayer.GetComponent<StarterAssetsInputs>().OnApplicationFocus(false);
        pauseMenuUI.SetActive(true);
        CurrentPlayer.SetActive(false);
        CurrentUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("Pause3");
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu....");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game....");
        {
            Application.Quit();
        }
    }

    public void AOmenu()
    {
        pauseMenuUI.SetActive(false);
        advMenuUI.SetActive(true);
    }

    public void Pmenu()
    {
        pauseMenuUI.SetActive(true);
        advMenuUI.SetActive(false);
    }

}
