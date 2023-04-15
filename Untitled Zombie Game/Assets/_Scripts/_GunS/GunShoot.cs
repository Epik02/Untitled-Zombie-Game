using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    PlayerAction inputAction;

    [Header("Bullet References")]
    [SerializeField]
    private InformationValues informationValues;

    public GameObject[] projectile;
    public GameObject SmallBullet;
    //public GameObject BigBullet;
    public GameObject GunHolder;

    public Transform projectilePos;

    public int damageNumber;

    public WeaponSwitch Weapon;

    [Header("Value Settings")]
    public int value;
    public int maxAmmo;
    private int currentAmmo;
    public int TotalAmmo;
    private int TotalMaxAmmo;
    public float reloadTime = 2f;
    public bool isReloading = false;
    private int newAddAmmo;
    public int speed;

    [Header("Define Weapon Type")]
    public int DefineWeapon;

    public bool AmmoDone = false;

    //Test for AMMO and Reloading
    [Header("UI Score Text")]
    public TMP_Text ChangingAmmo;
    public TMP_Text ChangingTotalAmmo;

    public GameObject ShootSounds;
    public GameObject ReloadSounds;

    // Sound Effects (Play on certain if statements)
    [Header("Sound Effects")]
    public AudioSource ShootSound;
    public AudioSource ReloadSound;

    //public float Soundvolume;

    //Animator work
    [Header ("Animation")]
    public Animator animator;

    private void OnEnable()
    {
        //ShootSound.volume = Soundvolume;
        inputAction.Enable();
        //Weapon.GunType = 0;
    }

    private void OnDisable()
    {
        inputAction.Disable();
        isReloading = false;
    }

private void Awake()
    {
        inputAction = new PlayerAction();
        //Weapon.GunType = 0;
        //ShootSound.volume = Soundvolume;
    }

    private void Start()
    {
        //animator = GetComponent<Animator>();

        //Soundvolume = PlayerPrefs.GetFloat("volume");
        //ShootSound.volume = Soundvolume;
        currentAmmo = maxAmmo;
        TotalMaxAmmo = TotalAmmo;

        isReloading = false;

        value = 0;

        GunHolder = GameObject.FindWithTag("GunHolderScript");
        Weapon = GunHolder.GetComponent<WeaponSwitch>();

        Weapon.GunType = 0;

        ChangingAmmo = GameObject.FindWithTag("CurrentAMMO").GetComponent<TMP_Text>();
        ChangingTotalAmmo = GameObject.FindWithTag("TotalAMMO").GetComponent<TMP_Text>();

        projectile[0] = SmallBullet;
        //projectile[1] = BigBullet;

        ShootSounds = GameObject.FindWithTag("Shooting");
        ShootSound = ShootSounds.GetComponent<AudioSource>();

        ReloadSounds = GameObject.FindWithTag("Reload");
        ReloadSound = ReloadSounds.GetComponent<AudioSource>();
    }

    private void Update()
    {
        //ShootSound.volume = Soundvolume;
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
        if (TotalMaxAmmo > 120 && currentAmmo <=0 && AmmoDone == true)
        {
            inputAction.PlayerShoot.Enable();
            AmmoDone = false;
            return;
        }
        //Debug.Log("Wow 2nd if statment incoming"); // if current ammo reduce to 0, reload it from max ammo
        if (currentAmmo <= 0 && AmmoDone == false)
        {
            //Debug.Log("Reload Time");
            StartCoroutine(Reloads());
           return;
        }

        inputAction.PlayerShoot.Reload.performed += cntxt => reloadingCurrentAmmo();
        //Debug.Log("Wow 3rd if statment incoming"); // if current ammo is greater than 0, player can shoot.
        if (currentAmmo > 0 && AmmoDone == false)
        {
            //Debug.Log("Shoot Time SMALL BULLET");
            inputAction.PlayerShoot.Shoot.performed += cntxt => Shoot(value);
        }
    }

    void reloadingCurrentAmmo()
    {
        StartCoroutine(Reloads());
    }

    IEnumerator Reloads()
    {

        isReloading = true;
        inputAction.PlayerShoot.Disable();
        ReloadSound.Play();
        animator.SetBool("Reload", true);
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("Reload", false);
        Debug.Log("Reloading Done");
        if (TotalMaxAmmo <= maxAmmo)
        {
            newAddAmmo = TotalMaxAmmo;
            currentAmmo += newAddAmmo;
            ChangingAmmo.text = currentAmmo.ToString();
            TotalMaxAmmo -= TotalMaxAmmo;
            ChangingTotalAmmo.text = "/" + TotalMaxAmmo.ToString();
        }
        else if (TotalMaxAmmo > maxAmmo)
        {
            newAddAmmo = maxAmmo - currentAmmo;
            currentAmmo += newAddAmmo;
            ChangingAmmo.text = currentAmmo.ToString();
            TotalMaxAmmo -= newAddAmmo;
            ChangingTotalAmmo.text = "/" + TotalMaxAmmo.ToString();
        }
        //Debug.Log("Ammo Reload:" + currentAmmo);
        inputAction.PlayerShoot.Enable();
        isReloading = false;
    }

    private void Shoot(int check)
    {

        ShootSound.Play();

        if (currentAmmo > 0) // decrease current ammo by 1
        {
            currentAmmo--;
            //Debug.Log("Wow Ammo Decrease");
        }
        ChangingAmmo.text = currentAmmo.ToString();
        Debug.Log("Ammo:" + currentAmmo);
        if (DefineWeapon >= 0)
        {
            if (check == 0)
            {
                damageNumber = informationValues.damage._SmallDamage;

            }
            else damageNumber = informationValues.damage._BigDamage;
        }
        if (DefineWeapon == 1)
        {
            if (check == 0)
            {
                damageNumber = informationValues.damage._EagleDamage;

            }
            else damageNumber = informationValues.damage._BigEagleDamage;
        }
        if (DefineWeapon == 2)
        {
            if (check == 0)
            {
                damageNumber = informationValues.damage._SmallAK47Damage;

            }
            else damageNumber = informationValues.damage._BigAK47Damage;
        }

        //Was testing RayCastHit - works cool right? - Justin Lee
        RaycastHit hit;
        transform.rotation = Quaternion.LookRotation(transform.forward.normalized);
        if (Physics.Raycast(projectilePos.position, projectilePos.forward, out hit))
        {

            ObjectPooler.instance.SpawnFromPool("Bullet", hit.point, Quaternion.identity);
        }
        //else
        //{
            //float maxDistance = 100f;
            //Vector3 spawnPosition = projectilePos.position + projectilePos.forward * maxDistance;
            //ObjectPooler.instance.SpawnFromPool("Bullet", spawnPosition, Quaternion.identity);
        //}
        //Vector3 SpawnBulletLocation = projectilePos.localPosition;

        //Rigidbody bulletRb = ObjectPooler.instance.SpawnFromPool("Bullet", projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        
        //Debug.Log(projectilePos.localPosition);
        //Vector3 direction = (projectilePos.position - transform.position).normalized;

        //transform.rotation = Quaternion.LookRotation(transform.forward.normalized);

        //bulletRb.AddForce(transform.forward.normalized * -speed, ForceMode.Impulse);
        //bulletRb.AddForce(transform.up * 1f, ForceMode.Impulse);
    }

    public void SetValue(int other)
    {
        //Debug.Log("Active:" + other);
        value = other;
    }

    public void AddAmmo(int ammoCount)
    {
        TotalMaxAmmo = ammoCount;
    }

    public int MaxValueAmmo()
    {
        return TotalAmmo;
    }
}
