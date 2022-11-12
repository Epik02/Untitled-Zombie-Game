using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    PlayerAction inputAction;

    [Header("Bullet References")]
    public GameObject[] projectile;
    public GameObject SmallBullet;
    public GameObject BigBullet;

    public Transform projectilePos;

    [Header("Value Settings")]
    public int value;
    public int maxAmmo = 15;
    private int currentAmmo;
    public int TotalAmmo = 120;
    private int TotalMaxAmmo;
    public float reloadTime = 2f;
    public bool isReloading = false;

    public bool AmmoDone = false;

    //Test for AMMO and Reloading
    [Header("UI Score Text")]
    public TMP_Text ChangingAmmo;
    public TMP_Text ChangingTotalAmmo;

    // Sound Effects (Play on certain if statements)
    [Header("Sound Effects")]
    public AudioSource ShootSound;
    public AudioSource ReloadSound;

    public float Soundvolume;

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
        isReloading = false;
    }

private void Awake()
    {
        inputAction = new PlayerAction();

    }

    private void Start()
    {
        currentAmmo = maxAmmo;
        TotalMaxAmmo = TotalAmmo;

        isReloading = false;

        value = 0;

        ChangingAmmo = GameObject.FindWithTag("CurrentAMMO").GetComponent<TMP_Text>();
        ChangingTotalAmmo = GameObject.FindWithTag("TotalAMMO").GetComponent<TMP_Text>();

        projectile[0] = SmallBullet;
        projectile[1] = BigBullet;

        ShootSound.volume = Soundvolume;
    }

    private void Update()
    {
        ChangingAmmo.text = currentAmmo.ToString();
        ChangingTotalAmmo.text = "/" + TotalMaxAmmo.ToString();
        //Debug.Log("Wow 1st if statment incoming");
        if (isReloading)
            return;
        if (TotalMaxAmmo <= 0 && currentAmmo <= 0) // Gun cannot shoot anymore if ammo is 0 and storage ammo is 0
        {
            //Debug.Log("Statment went by max = 0 and ammo = 0");
            inputAction.PlayerShoot.Disable();
            AmmoDone = true;
            return;
        }
        //Debug.Log("Wow 2nd if statment incoming"); // if current ammo reduce to 0, reload it from max ammo
        if (currentAmmo <= 0 && AmmoDone == false)
        {
            //Debug.Log("Reload Time");
            StartCoroutine(Reload());
           return;
        }
        //Debug.Log("Wow 3rd if statment incoming"); // if current ammo is greater than 0, player can shoot.
        if (currentAmmo > 0 && AmmoDone == false)
        {
            //Debug.Log("Shoot Time SMALL BULLET");
            inputAction.PlayerShoot.Shoot.performed += cntxt => Shoot(value);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        inputAction.PlayerShoot.Disable();
        ReloadSound.Play();
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        Debug.Log("Reloading Done");
        currentAmmo = maxAmmo;
        ChangingAmmo.text = currentAmmo.ToString();
        TotalMaxAmmo -= maxAmmo;
        ChangingTotalAmmo.text = "/" + TotalMaxAmmo.ToString();
        //Debug.Log("Ammo Reload:" + currentAmmo);
        inputAction.PlayerShoot.Enable();
        isReloading = false;
    }

    private void Shoot(int check)
    {
        if (currentAmmo > 0) // decrease current ammo by 1
        {
            currentAmmo--;
            //Debug.Log("Wow Ammo Decrease");
        }
        ChangingAmmo.text = currentAmmo.ToString();
        Debug.Log("Ammo:" + currentAmmo);
        ShootSound.Play();
        Rigidbody bulletRb = Instantiate(projectile[check], projectilePos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 1f, ForceMode.Impulse);
    }

    public void AddMaxAmmo()
    {

    }

    //public void ThrowReset()
    //{
    //    isReloading = false;
    //}

    public void SetValue(int other)
    {
        //Debug.Log("Active:" + other);
        value = other;
    }
}
