using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int GunType;
    int totalWeapons = 1;
    public int OtherWeaponIndex;
    public int currentWeaponIndex;

    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentGun;

    public GunShoot ThrowScript;
    public BazookaShoot BazookaScript;

    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        //SetCurrent();
        setParent();

        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
        OtherWeaponIndex = 1;
        ThrowScript = guns[currentWeaponIndex].GetComponentInChildren<GunShoot>();
        BazookaScript = guns[currentWeaponIndex].GetComponentInChildren<BazookaShoot>();
        Debug.Log(GunType);
    }

    void Update()
    {
        if (guns[currentWeaponIndex].gameObject != null)
        {
            guns[currentWeaponIndex].gameObject.tag = "CurrentGun";
        }
        
        if (guns[OtherWeaponIndex].gameObject != null)
        {
            guns[OtherWeaponIndex].gameObject.tag = "NotCurrentGun";
        }
        
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
            OtherWeaponIndex -= 1;
            
            currentGun = guns[currentWeaponIndex];
            ThrowScript = guns[currentWeaponIndex].GetComponentInChildren<GunShoot>();
            BazookaScript = guns[currentWeaponIndex].GetComponentInChildren<BazookaShoot>();
            //guns[0].gameObject.tag = "NotCurrentGun";
            //guns[currentWeaponIndex].gameObject.tag = "CurrentGun";
            guns[currentWeaponIndex].SetActive(true);
            Debug.Log(GunType);
            //ThrowScript.ThrowReset();
        }
        //previous Weapon
        else if (currentWeaponIndex > 0)
        {
            Debug.Log("0");
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex -= 1;
            OtherWeaponIndex += 1;
            currentGun = guns[currentWeaponIndex];
            ThrowScript = guns[currentWeaponIndex].GetComponentInChildren<GunShoot>();
            BazookaScript = guns[currentWeaponIndex].GetComponentInChildren<BazookaShoot>();
            //guns[1].gameObject.tag = "NotCurrentGun";
            //guns[currentWeaponIndex].gameObject.tag = "CurrentGun";
            //ThrowScript = currentGun.GetComponent<GunShoot>();
            guns[currentWeaponIndex].SetActive(true);
            Debug.Log(GunType);
            //ThrowScript.ThrowReset();
        }
    }

    public void SetCurrent(int index)
    {
        guns[index].SetActive(true);
        //guns[1].gameObject.tag = "CurrentGun";
        //guns[0].gameObject.tag = "NotCurrentGun";
    }

    public void Setvalue(int other)
    {
        Debug.Log(other);
        if (GunType == 0)
        {
            ThrowScript.SetValue(other);
        }
        else if (GunType == 1)
        {
            BazookaScript.SetValue(other);
        }
    }

    public int GetValue()
    {
        return ThrowScript.MaxValueAmmo();
       // return BazookaScript.MaxValueAmmo();
    }

    public int GetBaValue()
    {
        return BazookaScript.MaxValueAmmo();
    }
    public void SetAmmo(int other)
    {
        Debug.Log(other);
        if (GunType == 0)
        {
            ThrowScript.AddAmmo(other);
        }
        else if (GunType == 1)
        {
            BazookaScript.AddAmmo(other);
        }
    }
}
