using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public PlayerAction inputAction;

    public GameObject Character;
    
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
        inputAction = new PlayerAction();

        inputAction.Player.ReloadScene.performed += cntxt => Reload();
    }

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
    }
}
