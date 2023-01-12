using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using StarterAssets;

public class Movement : MonoBehaviour
{
    public static Movement instance;
    // Input Action Testing
    public PlayerAction inputAction;
    public GameObject Character;

    //public Health PlayerHealth;

    //Player Movement from Unity Asset for Testing
    public Movement player;
    public float playerx = 0;
    public float playery = 0;
    public float playerz = 0;

    // time variables
    public float timer = 5f;
    public bool timeCheck = false;

    // Regen if Active or Not
    public bool RegenActive = false;

    void Awake()
    {
        //instance awake
        if (!instance)
        {
            instance = this;
        }
        // set player max health at awake
       // PlayerHealth.SetMaxHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        playerx = player.transform.position.x;
        playery = player.transform.position.y;
        playerz = player.transform.position.z;

        if (Character.transform.position.y < -2)
        {
            Character.GetComponent<StarterAssetsInputs>().OnApplicationFocus(false);
            SceneManager.LoadScene(0);
        }
    }
}
