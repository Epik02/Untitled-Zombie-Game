using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
    //initialize button
    [SerializeField] private Button menuButton;
    [SerializeField] private Button AObutton;

   // [SerializeField] private Button KeybindButton;

    public override void Initialize()
    {
        //attach button command
        menuButton.onClick.AddListener(() => MenuManager.Show<TopMenu>());
        AObutton.onClick.AddListener(() => MenuManager.Show<AdvancedOptions>());

      //  KeybindButton.onClick.AddListener(() => MenuManager.Show<KeyBindMenu>());
    }
}
