using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CornScript : MonoBehaviour
{
    [SerializeField]
    private InformationValues informationValues;

    [SerializeField] int damage;

    // Numbers for explode
    [Header("Settings")]
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    // Sound Effects (Play when Grenade Explode)
    [Header("Sound Effects")]
    public GameObject GrenadeSound;

    public float Soundvolume;

    // Start is called before the first frame update
    void Start()
    {
        GrenadeSound = GameObject.FindWithTag("ExplodeSound");
        damage = informationValues.damage._GrenadeDamage;
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        //countdown -= Time.deltaTime;
        //if (countdown <= 0 && !hasExploded)
        //{
        //    Explode();
        //    hasExploded = true;
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        Explode();
        hasExploded = true;
    }
    void Explode()
    {

        Debug.Log("BOOM!");
        GrenadeSound.GetComponent<AudioSource>().Play();
        // show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        GameObject Gun = GameObject.FindWithTag("GunHolderScript");

        BazookaShoot damage = Gun.GetComponentInChildren<BazookaShoot>();


        // Get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
            if (nearbyObject.GetComponent<Collider>().tag == "Enemy")
            {
                Health health = nearbyObject.gameObject.GetComponent<Health>();
                health?.TakeDamage(damage.damageNumber);
                if (health.currentHealth <= 0)
                {
                    ScoreManager.instance.ChangeScore(200);
                    ScoreManager.instance.DecreaseEnemy();
                }
            }
        }
        //gameObject.SetActive(false);
        // remove grenade
        Destroy(gameObject);
    }
}
