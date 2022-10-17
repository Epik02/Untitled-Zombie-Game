using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   // public GameObject gameObjects;
   // public static EnemyController instance;
    public int damages = 10;
   // public float health = 100;

    //void Awake()
    //{
    //    if (!instance)
    //    {
    //        instance = this;
    //    }
    //}

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Player")
            Movement.instance.TakeDamage(damages);

    }

    //public void TakeDamages(int damage)
    //{
    //    health -= damage;

    //    if (health <= 0)
    //    {
    //        Destroy(gameObjects);
    //    }
    //}
}
