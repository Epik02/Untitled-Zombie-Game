using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindMenu : Menu
{
    //initialize button
    [SerializeField] private Button backButton;

 //   [SerializeField] private ActionRebind shootRebind;
 //   [SerializeField] private Button rebindButton;

    public override void Initialize()
    {
        //attach button command
        backButton.onClick.AddListener(() => MenuManager.Show<SettingsMenu>());

   //     rebindButton.onClick.AddListener(() => shootRebind.StartRebinding());
    }
}
