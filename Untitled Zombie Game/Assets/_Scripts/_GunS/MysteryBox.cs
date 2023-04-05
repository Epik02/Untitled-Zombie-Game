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

    public float ChanceOfBazooka;
    public float ChanceOfAK47;
    public float ChanceOfDeagle;

    public int selectedGun;
    public Transform cubePosition;

    public TMP_Text MysteryBoxText;
    public GameObject MysteryTextPrompt;

    public int PointsToBuy;
     string pointsToBuyText = "0";

    public float Cooldown = 6;

    public float ResetCooldown = 6;
    public float randomvalue;

    //Animator work
    [Header("Animation")]
    public Animator animator;

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

        if (Cooldown > 6)
        {
            animator.SetBool("Open", false);
        }

        if (RandomStartingSoon == true)
        {
            timer += Time.deltaTime;
            

            if (timer < 2.0f && counter < counterCompare)
            {
                counter++;
            }
            else if (counter == counterCompare)
            {
                animator.SetBool("Open", true);
                counter = 0;
                //RandomizeWeapon();
                RandomizeWeapon2();
                counterCompare++;
                //guns[selectedGun].transform.position = cubePosition.transform.position;
                SelectGun = true;
                //RandomStartingSoon = false;
                // guns[selectedGun].transform.parent = null;
            }
            //if (counterCompare = )
            //guns[selectedGun].transform.position = cubePosition.transform.position;
            //guns[selectedGun].transform.SetParent(null);
            //else RandomStartingSoon = false;
        }
        if (timer >= 2 && SelectGun == true)
        {
            //Animator -> Go to idleForPickupw
            //PreFabs[selectedGun].SetActive(true);
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

    void RandomizeWeapon2()
    {
        float rand = Random.value;
        randomvalue = rand;
        if (rand > ChanceOfBazooka)
        {
            selectedGun = 1;
            //guns[1].SetActive(true);
            //guns[1].transform.position = cubePosition.transform.position;
        }
        else if (rand > ChanceOfAK47)
        {
            selectedGun = 0;
            //guns[0].SetActive(true);
            //guns[0].transform.position = cubePosition.transform.position;
        }
        else if (rand > ChanceOfDeagle)
        {
            selectedGun = 2;
        }

    }
}
