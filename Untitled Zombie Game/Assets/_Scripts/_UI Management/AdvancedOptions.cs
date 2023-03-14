using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedOptions : Menu
{
    //initialize button
    [SerializeField] private Button BackButton;

    public override void Initialize()
    {
        //attach button command
        BackButton.onClick.AddListener(() => MenuManager.Show<SettingsMenu>());
    }
}
