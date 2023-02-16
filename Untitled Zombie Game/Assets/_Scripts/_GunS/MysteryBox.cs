using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MysteryBox : MonoBehaviour
{
    Animation Movement;

    public GameObject[] guns;
    public GameObject[] PreFabs;

    bool intrigger = false;
    bool RandomStartingSoon = false;
    bool SelectGun = false;

    float timer;
    int counter, counterCompare;

    public int selectedGun;
    public Transform cubePosition;

    public TMP_Text MysteryBoxText;
    public GameObject MysteryTextPrompt;

    public int PointsToBuy;
     string pointsToBuyText = "0";

    public float Cooldown = 6;

    public float ResetCooldown = 6;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            intrigger = true;
            Debug.Log("Mystery Box true");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            intrigger = false;
            Debug.Log("MysteryBox False");
        }
    }

    void Update()
    {
        Cooldown += Time.deltaTime;
        if (RandomStartingSoon == true)
        {
            timer += Time.deltaTime;
            

            if (timer < 4.0f && counter < counterCompare)
            {
                counter++;
            }
            else if (counter == counterCompare)
            {
                counter = 0;
                RandomizeWeapon();
                counterCompare++;
                guns[selectedGun].transform.position = cubePosition.transform.position;
                SelectGun = true;
                //RandomStartingSoon = false;
                // guns[selectedGun].transform.parent = null;
            }
            //if (counterCompare = )
            //guns[selectedGun].transform.position = cubePosition.transform.position;
            //guns[selectedGun].transform.SetParent(null);
            //else RandomStartingSoon = false;
        }
        if (timer >= 4 && SelectGun == true)
        {
            Instantiate(PreFabs[selectedGun], cubePosition.transform.position, Quaternion.identity);
            SelectGun = false;
        }
        if (intrigger == true)
        {
            MysteryTextPrompt.SetActive(true);
            MysteryBoxText.text = PointsToBuy.ToString() + " to roll the Mystery Box.";
            if (Input.GetKeyDown(KeyCode.E) == true && ScoreManager.instance.GetScore() >= PointsToBuy && Cooldown >= ResetCooldown)
            {
                ScoreManager.instance.DecreaseScore(PointsToBuy);
                counter = 0;
                counterCompare = 0;
                timer = 0;
                Cooldown = 0;
                RandomStartingSoon = false;
                RandomStartingSoon = true;
                Debug.Log("Mystery Box It worked");
                //OpenMysteryBox();
            }
        }
        else
        {
            MysteryTextPrompt.SetActive(false);
        }
    }

   // void OpenMysteryBox()
    //{
        //OpenLid();
      //  RunGunMovement();
   // }

   // void RunGunMovement()
   // {
       // Movement.Play();
   // }

    void RandomizeWeapon()
    {
        int gunCount = guns.Length;
        int rand = Random.Range(0, gunCount);
        while (rand == selectedGun)
        {
            rand = Random.Range(0, gunCount);
        }
        selectedGun = rand;
        for (int i = 0; i < gunCount; i++)
        {
            guns[i].SetActive(false);
        }

        guns[selectedGun].SetActive(true);
        guns[selectedGun].transform.position = cubePosition.transform.position;
        //guns[selectedGun].transform.SetParent(null);
    }
}
