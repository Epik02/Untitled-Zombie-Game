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

    //public AudioClip[] audioOptions;

    public AudioSource zombieAudio;

    public GameObject Player;

    public float maxDistance = 0.5f; // The distance at which the zombie sound is at maximum volume
    public float minDistance = 30f; // The distance at which the zombie sound is at minimum volume

    // public GameObject EnemyHealth;
    public int damages;

    public GameObject EnemyHealth;

    private void OnEnable()
    {
        EnemyHealth.SetActive(false);
        ScoreManager.instance.AddEnemy();
        damages = informationValues.damage._EnemyDamage;
        transform.GetComponent<Rigidbody>().WakeUp();
        zombieAudio = GetComponent<AudioSource>();
        //PlayerRandomAudio();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnDisable()
    {
        //ScoreManager.instance.DecreaseEnemy();
        transform.GetComponent<Rigidbody>().Sleep();
    }

    //private void PlayerRandomAudio()
   // {
       // int randomIndex = Random.Range(0, audioOptions.Length);
        //zombieAudio.clip = audioOptions[randomIndex];
       // zombieAudio.Play();
   // }

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

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        //float maxDistance = 1f; // The distance at which the zombie sound is at maximum volume
        //float minDistance = 8f; // The distance at which the zombie sound is at minimum volume
        float volume = Mathf.InverseLerp(minDistance, maxDistance, distance);
        zombieAudio.volume = volume;
    }
}
