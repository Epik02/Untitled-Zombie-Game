using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float bulletLifetime = 5f; // The amount of time the bullet should live before being disabled
    private float elapsedTime = 0f; // The amount of time that has elapsed since the bullet was spawned

    private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
    }

    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().Sleep();
    }

    private void OnCollisionEnter(Collision other) {
        
        
        gameObject.SetActive(false);

        //Rigidbody bulletRb = gameObject.GetComponent<Rigidbody>();
        //bulletRb.AddForce(-bulletRb.velocity, ForceMode.Impulse);
        GameObject Gun = GameObject.FindWithTag("GunHolderScript");

        GunShoot damage = Gun.GetComponentInChildren<GunShoot>();

        //if (other.collider.tag == "Player")
        //{
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //} 
        if(other.collider.tag == "Enemy")
        {
            Health health = other.gameObject.GetComponent<Health>();
            health?.TakeDamage(damage.damageNumber);
            if (health.currentHealth <= 0)
            {
                ScoreManager.instance.ChangeScore(100);
                ScoreManager.instance.DecreaseEnemy();
            }
            //other.gameObject.GetComponent<EnemyController>().OnTakeDamages(25);
            //Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the elapsed time has exceeded the bullet lifetime
        if (elapsedTime >= bulletLifetime)
        {
            // Disable the game object
            gameObject.SetActive(false);
        }
    }
}
