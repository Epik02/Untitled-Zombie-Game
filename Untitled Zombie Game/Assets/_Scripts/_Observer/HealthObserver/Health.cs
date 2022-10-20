using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    //This is a generic health class and in this example will be used as a subject for the observer pattern.

    //Public Action
    public event Action<int> Damaged = delegate { };
    //public event Action Killed = delegate { };

    //Health Testing
    [SerializeField] int _maxHealth = 100;
    public int MaxHealth => _maxHealth;

    [SerializeField] int _StartingHealth = 100;
    public int StartingHealth => _StartingHealth;

    public int currentHealth;
    
    public int damages = 0;

    //Player/Enemy Health Bar
    public HealthBar healthBar;

    void Awake()
    {
        currentHealth = _StartingHealth;
    }

    //taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Damaged.Invoke(damage);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    //public void kill()
    //{
    //    Killed.Invoke();
    //    gameObject.SetActive(false);
    //}
}
