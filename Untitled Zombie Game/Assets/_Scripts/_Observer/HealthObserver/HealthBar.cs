using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class is used as example and for future for GDW game, it will handle the communication between health slider
//and Health events for now.

[RequireComponent(typeof(Health))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider _Healthslider = null;

    public Health health { get; private set; }

    private void Awake()
    {
        health = GetComponent<Health>();

        _Healthslider.maxValue = health.MaxHealth;
        _Healthslider.value = health.MaxHealth;
    }
    
    private void OnEnable()
    {
         //health = GetComponent<Health>();

        _Healthslider.maxValue = health.MaxHealth;
        _Healthslider.value = health.MaxHealth;

        //subscribe to get noified when this health takes damage!
        health.Damaged += OnTakeDamage;
    }

    private void Disable()
    {
        health.Damaged -= OnTakeDamage;
    }

    void OnTakeDamage(int damage)
    {
        //on damaged, display the new health
        _Healthslider.value = health.currentHealth;
    }

    public float GetHealth()
    {
        // return health slider value
        return _Healthslider.value;
    }
}
