using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;


//public bool equipped;
//public static bool slotFull;

public class PickUp : MonoBehaviour
{
    public GameObject CurrentGunEquiped;
    public GameObject gunScript;
    public GameObject GunHolder;

    //public GunShoot ThrowScript;

    public WeaponSwitch swichy;

    public PickUp CurrentPickUp;

    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;
    //PlayerAction inputAction;

    public Vector3 holder;
    public Vector3 ScaleLocation;

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
            //coll.isTrigger = false;
            coll.enabled = true;
        }
        if (equipped)
        {
            gunScript.SetActive(true);
            rb.isKinematic = true;
            //coll.isTrigger = true;
            coll.enabled = false;
            slotFull = true;
        }

        GunHolder = GameObject.FindWithTag("GunHolderScript");
        //ThrowScript = gunScript.GetComponent<GunShoot>();
        player = GameObject.FindWithTag("Player").transform;
        gunContainer = GameObject.FindWithTag("GunHolderScript").transform;
        fpsCam = GameObject.FindWithTag("MainCamera").transform;
        swichy = GunHolder.GetComponent<WeaponSwitch>();

        //CurrentGunEquiped = GameObject.FindWithTag("CurrentGun");
        //CurrentPickUp = CurrentGunEquiped.GetComponent<PickUp>();
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

        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.Q))
        {
            CurrentGunEquiped = GameObject.FindWithTag("CurrentGun");
            CurrentPickUp = CurrentGunEquiped.GetComponent<PickUp>();
            CurrentPickUp.Drop();
            Debug.Log("Dropped Gun");
            PickUps();
            Debug.Log("Pick Up Gun");
        }
        //if (!equipped && distanceToPlayer.magnitude <= pickUpRange && !slotFull)
        //{
        //    inputAction.Player.Drop.Disable();
        //    inputAction.Player.Pick.Enable();
        //    inputAction.Player.Pick.performed += cntxt => PickUps();  
        //}

        ////Drop if equipped and "Q" is pressed
        //if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
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
        //Destroy(CurrentGunEquiped);
        //Make weapon a child of the character/camera and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = holder;
            //new Vector3(-0.119f, -0.206f, 0.382f);
        //transform.localPosition = new Vector3(-2.378f, 4.266f, 30.75f);
        transform.localRotation = Quaternion.Euler(0.0f,90.0f, 0.0f);//Quaternion.Euler(Vector3.zero);
        transform.localScale = ScaleLocation;

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.enabled = false;
        //coll.isTrigger = true;

        //Enable script
        gunScript.SetActive(true);

        
        swichy.setParent();
        //swichy.Swap();
        swichy.SetCurrent(1);
        //gameObject.tag = "CurrentGun";

    }

    private void Drop()
    {
        //ThrowScript.ThrowReset();
        equipped = false;
        slotFull = false;
        
        //Set parent to null
        transform.SetParent(null);
        gunScript.SetActive(false);
        //swichy.setParent();
        //swichy.SetCurrent(1);

        Destroy(gameObject);
        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = false;
        coll.enabled = true;
        //coll.isTrigger = false;

        //Gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random)*10);

        //Enable script
        //gunScript.SetActive(false);

       // swichy.Swap();
        //swichy.setParent();
        //swichy.SetCurrent(1);
        //swichy.SetCurrent();

    }
}

