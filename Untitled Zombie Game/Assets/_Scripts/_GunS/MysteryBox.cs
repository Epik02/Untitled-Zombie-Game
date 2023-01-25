using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MysteryBox : MonoBehaviour
{
    Animation Movement;

    public GameObject[] guns;

    bool intrigger = false;
    bool RandomStartingSoon = false;

    float timer;
    int counter, counterCompare;

    public int selectedGun;
    public Transform cubePosition;

    public TMP_Text MysteryBoxText;
    public GameObject MysteryTextPrompt;

    public int PointsToBuy;
     string pointsToBuyText = "0";

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
                //RandomStartingSoon = false;
               // guns[selectedGun].transform.parent = null;
            }
            //guns[selectedGun].transform.position = cubePosition.transform.position;
            //guns[selectedGun].transform.SetParent(null);
            //else RandomStartingSoon = false;
        }
        else
        {
            counter = 0;
            counterCompare = 0;
            timer = 0;
            RandomStartingSoon = false;
        }
        if (intrigger == true)
        {
            MysteryTextPrompt.SetActive(true);
            MysteryBoxText.text = PointsToBuy.ToString() + " to roll the Mystery Box.";
            if (Input.GetKeyDown(KeyCode.E) == true && ScoreManager.instance.GetScore() >= PointsToBuy)
            {
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
