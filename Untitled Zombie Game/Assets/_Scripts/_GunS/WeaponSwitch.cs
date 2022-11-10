using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;

    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentGun;

    public GunShoot ThrowScript;

    public Transform GunContainer;

    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        //SetCurrent();
        setParent();

        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ThrowScript.ThrowReset();
            Swap();
        }
    }

    public void setParent()
    {
        //currentGun.transform.SetParent(GunContainer);
        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
    }

    public void Swap()
    {
        if (currentWeaponIndex < totalWeapons - 1)
        {
            Debug.Log("1");
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex += 1;
            guns[currentWeaponIndex].SetActive(true);
        }
        //previous Weapon
        else if (currentWeaponIndex > 0)
        {
            Debug.Log("0");
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex -= 1;
            guns[currentWeaponIndex].SetActive(true);
        }
        currentGun = guns[currentWeaponIndex];
    }

    public void SetCurrent(int index)
    {
        guns[index].SetActive(true);
    }
}