using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);

        if(other.collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else if(other.collider.tag == "Enemy")
        {
            //EnemyController.instance.TakeDamages(25);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        Destroy(gameObject, 3);
    }
}
