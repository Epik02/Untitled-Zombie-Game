using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    //Used to help make buttons or other functions under the child classes
    //Also makes sure the menus are always initialized along with their components (like buttons...)
    public abstract void Initialize();

    //Functions used to hide and show our menu's. 
    //worth noting : virtual functions are so the function can be overwritten by children of menu and the data from the gameObject in case there are any changes.
    public virtual void Hide() => gameObject.SetActive(false);

    public virtual void Show() => gameObject.SetActive(true);
}
