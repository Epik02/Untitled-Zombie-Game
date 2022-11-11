using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class PauseMenus : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject CurrentPlayer;
    public GameObject CurrentUI;

    void Start()
    {
        CurrentPlayer.GetComponent<StarterAssetsInputs>().OnApplicationFocus(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused)
            //{
            //    Resume();
            //}
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

    void Pause()
    {
        CurrentPlayer.GetComponent<StarterAssetsInputs>().OnApplicationFocus(false);
        pauseMenuUI.SetActive(true);
        CurrentPlayer.SetActive(false);
        CurrentUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
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
}
