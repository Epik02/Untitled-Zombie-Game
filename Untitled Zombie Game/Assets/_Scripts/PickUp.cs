using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;


//public bool equipped;
//public static bool slotFull;

public class PickUp : MonoBehaviour
{
    public GameObject gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;
   // PlayerAction inputAction;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        // Setup
        if(!equipped)
        {
            gunScript.SetActive(false);
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            gunScript.SetActive(true);
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    //private void OnEnable()
    //{
    //    inputAction.Enable();
    //}

    //private void OnDisable()
    //{
    //    inputAction.Disable();
    //}

    //private void Awake()
    //{
    //    inputAction = new PlayerAction();

    //   // if (!equipped && distanceToPlayer.magnitude <= pickUpRange && inputAction.Player.Pick.performed() && !slotFull) PickUps();
    //    //if (equipped && inputAction.Player.Drop.performed()) Drop();
    //    // inputAction.Player.Pick.performed += cntxt => PickUps();
    //}

    private void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUps();
       //if (!equipped && distanceToPlayer.magnitude <= pickUpRange && inputAction.Player.Pick && !slotFull) PickUps();

        ////Drop if equipped and "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
       // if (equipped) inputAction.Player.Drop.performed += cntxt => Drop();
    }

    private void PickUps()
    {
        equipped = true;
        slotFull = true;

        //Make weapon a child of the character/camera and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Enable script
        gunScript.SetActive(true);

    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random)*10);


        //Enable script
        gunScript.SetActive(false);
    }
}

