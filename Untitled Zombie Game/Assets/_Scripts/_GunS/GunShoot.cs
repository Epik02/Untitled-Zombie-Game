using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    PlayerAction inputAction;

    public GameObject projectile;
    public Transform projectilePos;

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

private void Awake()
    {
        inputAction = new PlayerAction();

        inputAction.PlayerShoot.Shoot.performed += cntxt => Shoot();
    }

private void Shoot()
    {
        Rigidbody bulletRb = Instantiate(projectile, projectilePos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 1f, ForceMode.Impulse);
    }
}
