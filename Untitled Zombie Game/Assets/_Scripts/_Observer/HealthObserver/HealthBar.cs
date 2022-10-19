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

    public Health Health { get; private set; }

    private void Awake()
    {
        Health = GetComponent<Health>();

        _Healthslider.maxValue = Health.MaxHealth;
        _Healthslider.value = Health.StartingHealth;
    }
    
    private void OnEnable()
    {
        //subscribe to get noified when this health takes damage!
        Health.Damaged += OnTakeDamage;
    }

    private void Disable()
    {
        Health.Damaged -= OnTakeDamage;
    }

    void OnTakeDamage(int damage)
    {
        //on damaged, display the new health
        _Healthslider.value = Health.currentHealth;
    }

    //public void SetMaxHealth(int health)
    //{
    //    slider.maxValue = health;
    //    slider.value = health;
    //}

    //public void SetHealth(int health)
    //{
    //    slider.value = health;
    //}

    public float GetHealth()
    {
        return _Healthslider.value;
    }

}
