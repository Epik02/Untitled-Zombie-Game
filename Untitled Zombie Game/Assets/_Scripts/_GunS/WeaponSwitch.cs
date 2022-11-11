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

    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        //SetCurrent();
        setParent();

        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
        ThrowScript = guns[currentWeaponIndex].GetComponentInChildren<GunShoot>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
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
        //ThrowScript = currentGun.GetComponent<GunShoot>();
        if (currentWeaponIndex < totalWeapons - 1)
        {
            Debug.Log("1");
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex += 1;
            currentGun = guns[currentWeaponIndex];
           //ThrowScript = guns[currentWeaponIndex].GetComponentInChildren<GunShoot>();
            guns[currentWeaponIndex].SetActive(true);
            //ThrowScript.ThrowReset();
        }
        //previous Weapon
        else if (currentWeaponIndex > 0)
        {
            Debug.Log("0");
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex -= 1;
            currentGun = guns[currentWeaponIndex];
            //ThrowScript = guns[currentWeaponIndex].GetComponentInChildren<GunShoot>();
            //ThrowScript = currentGun.GetComponent<GunShoot>();
            guns[currentWeaponIndex].SetActive(true);
            //ThrowScript.ThrowReset();
        }
    }

    public void SetCurrent(int index)
    {
        guns[index].SetActive(true);
    }

    public void Setvalue(int other)
    {
        Debug.Log(other);
        ThrowScript.SetValue(other);
    }
}
