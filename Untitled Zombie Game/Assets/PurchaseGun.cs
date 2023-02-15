using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PurchaseGun : MonoBehaviour
{
    public GameObject WeaponSold;

    bool intrigger = false;

    public int PurchaseCost = 0;
    public TMP_Text Cost;
    public GameObject CostText;
    public string WeaponName;

    public Vector3 LocationOfWeapon;


    PickUp grabWeaponName;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            intrigger = true;
            Debug.Log("Encounter Weapon Purchase");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            intrigger = false;
            Debug.Log("Weapon Purchase False");
        }
    }

    private void Update()
    {
        if (intrigger == true)
        {
            CostText.SetActive(true);
            Cost.text = PurchaseCost.ToString() + " points to purchase " + WeaponName;
            if (Input.GetKeyDown(KeyCode.E) == true && ScoreManager.instance.GetScore() >= PurchaseCost)
            {
                Debug.Log("Purchase Weapon Working");
                Instantiate(WeaponSold, LocationOfWeapon, Quaternion.identity);
            }
        }
        else
        {
            CostText.SetActive(false);
        }
    }
}
