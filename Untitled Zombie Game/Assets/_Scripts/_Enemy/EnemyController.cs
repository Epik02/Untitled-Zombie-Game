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

    public GameObject EnemyHealth;

    private void OnEnable()
    {
        EnemyHealth.SetActive(false);
        ScoreManager.instance.AddEnemy();
        damages = informationValues.damage._EnemyDamage;
        transform.GetComponent<Rigidbody>().WakeUp();
    }

    private void OnDisable()
    {
        //ScoreManager.instance.DecreaseEnemy();
        transform.GetComponent<Rigidbody>().Sleep();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
            health?.TakeDamage(damages);
            if (health.currentHealth <= 0)
            {
                other.gameObject.GetComponent<StarterAssetsInputs>().OnApplicationFocus(false);
                PlayerPrefs.SetFloat("Score", ScoreManager.instance.TotalScore);
                SceneManager.LoadScene(2);
            }
            //other.gameObject.GetComponent<EnemyController>().OnTakeDamages(25);
            //Destroy(other.gameObject);
        }
    }

    public void SetDamage(int value)
    {
        informationValues.damage._EnemyDamage = value;
    }
}
