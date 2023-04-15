using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

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

    //private void Update()
    // {
    // Destroy(gameObject, 3);
    // }
}
