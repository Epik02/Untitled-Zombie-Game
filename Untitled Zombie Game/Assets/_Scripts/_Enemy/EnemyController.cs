using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private InformationValues informationValues;

    // public GameObject EnemyHealth;
    public int damages;

    private void OnEnable()
    {
        ScoreManager.instance.AddEnemy();
        damages = informationValues.damage._EnemyDamage;
        transform.GetComponent<Rigidbody>().WakeUp();
    }

    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().Sleep();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Health health = other.gameObject.GetComponent<Health>();
            health?.TakeDamage(damages);
            if (health.currentHealth <= 0)
            {
                other.gameObject.GetComponent<StarterAssetsInputs>().OnApplicationFocus(false);
                SceneManager.LoadScene(0);
            }
            //other.gameObject.GetComponent<EnemyController>().OnTakeDamages(25);
            //Destroy(other.gameObject);
        }
    }

}
