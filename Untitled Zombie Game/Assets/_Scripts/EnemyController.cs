using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int damages = 10;
    public float maxHealth = 100;
    public float health = 0;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision other)
    {
        //if (other.collider.tag == "Bullet") ScoreManager.instance.ChangeScore(1);
        if (other.collider.tag == "Player") Movement.instance.TakeDamage(damages);
    }

    public void TakeDamages(int damage)
    {
        health -= damage;
        Debug.Log(health);

        if (health <= 0)
        {
            ScoreManager.instance.ChangeScore(1);
            Destroy(gameObject);
        }
  
    }

    public float GetEnemyHealth()
    {
        return health;
    }
}
