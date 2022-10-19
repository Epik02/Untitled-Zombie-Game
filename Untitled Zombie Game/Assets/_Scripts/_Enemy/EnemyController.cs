using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
   // public GameObject EnemyHealth;
    public int damages = 20;
    // public int maxHealth = 100;
    //public int health = 0;

    //public EnemyHealthSlider healthBar;

    //void Awake()
    //{
    //EnemyHealth.SetActive(true);
    // health = maxHealth;
    // healthBar.SetMaxHealth(maxHealth);
    //}

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Health health = other.gameObject.GetComponent<Health>();
            health?.TakeDamage(damages);
            if (health.currentHealth <= 0)
            {
                SceneManager.LoadScene(0);
            }
            //other.gameObject.GetComponent<EnemyController>().OnTakeDamages(25);
            //Destroy(other.gameObject);
        }
    }

        //public void TakeDamages(int damage)
        //{
        // health -= damage;
        // healthBar.SetHealth(health);
        // Debug.Log(health);

        // if (health <= 0)
        // {
        //ScoreManager.instance.ChangeScore(1);
        //  Destroy(gameObject);
        //  }

        //}

        // public float GetEnemyHealth()
        // {
        // return health;
        //  }
    }
