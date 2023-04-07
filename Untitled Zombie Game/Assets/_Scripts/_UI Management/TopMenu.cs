using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopMenu : Menu
{
    //initialize button
    [SerializeField] private Button startButton;

    [SerializeField] private Button settingsButton;

    [SerializeField] private Button quitButton;

    public override void Initialize()
    {
        //attach button command
        settingsButton.onClick.AddListener(() => MenuManager.Show<SettingsMenu>());

        startButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        startButton.onClick.AddListener(() => EnemyPool.ResetThis());
        startButton.onClick.AddListener(() => Time.timeScale = 1f);

        quitButton.onClick.AddListener(() => Application.Quit());
    }

    public void SwitchToScoreScene()
    {
        SceneManager.LoadScene(2);
    }
}
