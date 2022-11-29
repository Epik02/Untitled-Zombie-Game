using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    //This is a generic health class and in this example will be used as a subject for the observer pattern.

    [SerializeField]
    private InformationValues informationValues;

    //Public Action
    public event Action<int> Damaged = delegate { };
    //public event Action Killed = delegate { };
    public event Action<int> Regen = delegate { };
    public event Action<int> Jug = delegate { };

    //Health Testing
    public int MaxHealth => informationValues._maxHealth;

    //[SerializeField] int _StartingHealth = 100;
    public int StartingHealth => informationValues._maxHealth; //=> _StartingHealth;

    public int currentHealth;

    public int maxHealthApply;

    void OnEnable()
    {
        //currentHealth = MaxHealth;
        //maxHealthApply = MaxHealth;
    }

    void Awake()
    {
        currentHealth = MaxHealth;
        maxHealthApply = MaxHealth;
    }


    //taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Damaged.Invoke(damage);

        if (currentHealth <= 0)
        {
            //ScoreManager.instance.DecreaseEnemy();
            EnemyPool.Despawn(gameObject);
        }
    }

    public void SetMaxHealth(int other)
    {
        informationValues._maxHealth = other;
    }

    public void RegenHealth(int value)
    {
        currentHealth += value;
        Regen.Invoke(value);
    }

    public void SetHealth(int value)
    {
        maxHealthApply = value;
        informationValues._maxHealth = value;
        Jug.Invoke(value);
    }

}
