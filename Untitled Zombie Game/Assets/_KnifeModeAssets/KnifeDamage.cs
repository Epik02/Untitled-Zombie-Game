using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeDamage : MonoBehaviour
{

    [Header("Despawn Timer")]
    public float bulletLifetime = 5f; // The amount of time the bullet should live before being disabled
    private float elapsedTime = 0f; // The amount of time that has elapsed since the bullet was spawned


    public int KnifeDamages = 250;
    private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
    }

    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().Sleep();
    }

    private void OnCollisionEnter(Collision other)
    {
        //Rigidbody bulletRb = gameObject.GetComponent<Rigidbody>();
        //bulletRb.AddForce(-bulletRb.velocity, ForceMode.Impulse);

        //if (other.collider.tag == "Player")
        //{
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //} 
        if (other.collider.tag == "Enemy")
        {
            Health health = other.gameObject.GetComponent<Health>();
            health?.TakeDamage(KnifeDamages);
            if (health.currentHealth <= 0)
            {
                ScoreManager.instance.ChangeScore(200);
                ScoreManager.instance.DecreaseEnemy();
            }
            //other.gameObject.GetComponent<EnemyController>().OnTakeDamages(25);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the elapsed time has exceeded the bullet lifetime
        if (elapsedTime >= bulletLifetime)
        {
            Destroy(gameObject);
            // Disable the game object
            //gameObject.SetActive(false);
        }
    }
}
