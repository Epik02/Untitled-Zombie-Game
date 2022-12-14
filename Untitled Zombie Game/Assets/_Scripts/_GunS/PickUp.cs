using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;


//public bool equipped;
//public static bool slotFull;

public class PickUp : MonoBehaviour
{
    public GameObject gunScript;
    public GameObject GunHolder;

    //public GunShoot ThrowScript;

    public WeaponSwitch swichy;

    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;
    //PlayerAction inputAction;

    public Vector3 holder;

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
        GunHolder = GameObject.FindWithTag("GunHolderScript");
        //ThrowScript = gunScript.GetComponent<GunShoot>();
        swichy = GunHolder.GetComponent<WeaponSwitch>();
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
    //    // if (!equipped && distanceToPlayer.magnitude <= pickUpRange && inputAction.Player.Pick.performed() && !slotFull) PickUps();
    //    //if (equipped && inputAction.Player.Drop.performed()) Drop();
    //    // inputAction.Player.Pick.performed += cntxt => PickUps();
    //}

    private void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;

        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUps();
        //if (!equipped && distanceToPlayer.magnitude <= pickUpRange && !slotFull)
        //{
        //    inputAction.Player.Drop.Disable();
        //    inputAction.Player.Pick.Enable();
        //    inputAction.Player.Pick.performed += cntxt => PickUps();
            
        //}

        ////Drop if equipped and "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
        //if (equipped)
        //{
        //    inputAction.Player.Pick.Disable();
        //    inputAction.Player.Drop.Enable();
        //    inputAction.Player.Drop.performed += cntxt => Drop();
        //}
    }

    private void PickUps()
    {
        equipped = true;
        slotFull = true;

        //Make weapon a child of the character/camera and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = holder;
            //new Vector3(-0.119f, -0.206f, 0.382f);
        //transform.localPosition = new Vector3(-2.378f, 4.266f, 30.75f);
        transform.localRotation = Quaternion.Euler(0.0f,90.0f, 0.0f);//Quaternion.Euler(Vector3.zero);
        transform.localScale = new Vector3(1.91f, 0.83f, 1.355f);

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Enable script
        gunScript.SetActive(true);

        
        swichy.setParent();
        //swichy.Swap();
        swichy.SetCurrent(1);

    }

    private void Drop()
    {
        //ThrowScript.ThrowReset();
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

       // swichy.Swap();
        swichy.setParent();
        swichy.SetCurrent(1);
        //swichy.SetCurrent();

    }
}

