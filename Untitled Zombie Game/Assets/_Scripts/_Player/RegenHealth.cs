using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenHealth : MonoBehaviour
{
    public PlayerHealth PlayerHealth;

    // time variables
    public float timer;
    public float timeAdd;
    public bool timeCheck;

    // Regen if Active or Not
    public bool RegenActive;

    void Start()
    {
        timeCheck = false;
        RegenActive = false;
        timer = timeAdd;
    }

    void Enable()
    {
        timeCheck = false;
        RegenActive = false;
        timer = timeAdd;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.currentHealth > 0 && PlayerHealth.currentHealth < PlayerHealth.maxHealthApply)
        {
            if (timeCheck == false && RegenActive == false)
            {
                timer -= Time.deltaTime;
                // Debug.Log("Decreasing Time");

                if (timer <= 0)
                {
                    //Detect when timer is done
                    timeCheck = true;
                    RegenActive = true;
                    timer = 2;
                    Debug.Log("Time is Done, player Regen begin");
                }
            }

            if (timeCheck == true && RegenActive == true)
            {
                PlayerHealth?.RegenHealth(25);
                // check if player health is greater than or equal to 100, add timer to start timer before regen begins
                if (PlayerHealth.currentHealth >= PlayerHealth.maxHealthApply)
                {
                    timeCheck = false;
                    RegenActive = false;
                    timer = timeAdd;
                }
            }


        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Enemy")
        {
            timer = timeAdd;
        }
    }
}
