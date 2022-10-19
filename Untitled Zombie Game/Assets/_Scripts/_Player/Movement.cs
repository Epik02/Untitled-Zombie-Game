using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public static Movement instance;
    // Input Action Testing
    public PlayerAction inputAction;
    public GameObject Character;

    //Health Testing
    //public int maxHealth = 100;
    //public int currentHealth;
    //public int damages = 0;

    //public HealthBar healthBar;
    

    //Player Movement from Unity Asset for Testing
    public Movement player;
    public float playerx = 0;
    public float playery = 0;
    public float playerz = 0;

    private void OnEnable()
    {
        inputAction.Player.Enable();
    }

    private void OnDisable()
    {
        inputAction.Player.Disable();
    }

    void Awake()
    {
        //instance awake
        if (!instance)
        {
            instance = this;
        }

        //currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);

        inputAction = new PlayerAction();

        inputAction.Player.ReloadScene.performed += cntxt => Reload();
        //inputAction.Player.Damage.performed += cntxt => TakeDamage(damages);
    }
    //taking damage
    //public void TakeDamage(int damage)
    //{
    //    currentHealth -= damage;
    //    healthBar.SetHealth(currentHealth);
    //}

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        playerx = player.transform.position.x;
        playery = player.transform.position.y;
        playerz = player.transform.position.z;

        if (Character.transform.position.y < -2)
        {
            SceneManager.LoadScene(0);
        }

       // if (healthBar.GetHealth() <= 0)
        //{
          //  SceneManager.LoadScene(0);
       // }
    }
}
