using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
    //initialize button
    [SerializeField] private Button menuButton;

    [SerializeField] private Button KeybindButton;

    public override void Initialize()
    {
        //attach button command
        menuButton.onClick.AddListener(() => MenuManager.Show<TopMenu>());

        KeybindButton.onClick.AddListener(() => MenuManager.Show<KeyBindMenu>());
    }
}
