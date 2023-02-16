using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PurchaseGun : MonoBehaviour
{
    public GameObject WeaponSold;

    bool intrigger = false;

    public int PurchaseCost;
    public TMP_Text Cost;
    public GameObject CostText;
    public string WeaponName;

    public float Cooldown = 10;

    public int ResetCooldown = 10;

    public GameObject Location;

    //public Vector3 LocationOfWeapon;

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
        Cooldown += Time.deltaTime;
        if (intrigger == true)
        {
            CostText.SetActive(true);
            Cost.text = PurchaseCost.ToString() + " points to purchase " + WeaponName;
            if (Input.GetKeyDown(KeyCode.E) == true && ScoreManager.instance.GetScore() >= PurchaseCost && Cooldown >= ResetCooldown)
            {
                Debug.Log("Purchase Weapon Working");
                ScoreManager.instance.DecreaseScore(PurchaseCost);
                Instantiate(WeaponSold, Location.transform.position, Quaternion.identity);
                Cooldown = 0;
            }
        }
        else
        {
            CostText.SetActive(false);
        }
    }
}
