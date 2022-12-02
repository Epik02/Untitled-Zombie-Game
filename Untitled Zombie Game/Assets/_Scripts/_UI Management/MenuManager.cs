using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //Make a singleton instance for the class
    public static MenuManager menuInstance;

    //SerializeField is so we can edit menuList while keeping it private to the class.
    // You might say, "??" but it helps edit code an attach components without having to actually code while in the Unity editor.

    //menuList holds all of our menus so we can access them
    [SerializeField] private Menu[] menuList;

    //to help track where we at
    private Menu currentMenu;



    //T is just to protect the tyoe we want back. In this case we want an object from Menu.
    //Function for seeking menus but better for buttons that use listeners and for iterating through lists.
    public static void Show<T>() where T : Menu
    {
        for (int i = 0; i < menuInstance.menuList.Length; i++)
        {
            //self explanatory generally but worth noting is that you cant have == T, but must have "is" T
            if (menuInstance.menuList[i] is T)
            {
                if (menuInstance.currentMenu != null)
                {
                    //Hides the current menu you are on...
                    menuInstance.currentMenu.Hide();
                }
                //...shows the menu we want...
                menuInstance.menuList[i].Show();

                //...and then sets out current menu to the one we opened.
                menuInstance.currentMenu = menuInstance.menuList[i];
            }
        }
    }

    //Same purpose as Awake() code from ScoreManager for our instance. Makes sure the instance exists on startup
    void Awake()
    {
        if (!menuInstance)
        {
            menuInstance = this;
        }
    }

    private void Start()
    {
        // "Better safe than sorry" first time setup
        for (int i = 0; i < menuList.Length; i++)
        {
            //Make sure everything exists
            menuList[i].Initialize();

            //Make sure everything is hidden on launch
            menuList[i].Hide();
        }

        //Boot up our opening menu
        MenuManager.Show<TopMenu>();
    }
}
