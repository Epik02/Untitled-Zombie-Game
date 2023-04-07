using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject EnemyHealth = other.transform.GetChild(2).gameObject;
            EnemyHealth.SetActive(true);
            Debug.Log("Enemy Has Enter");
           //other.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject EnemyHealth = other.transform.GetChild(2).gameObject;
            EnemyHealth.SetActive(false);
            Debug.Log("Enemy Has Left");
            //other.gameObject.SetActive(false);
        }
    }
}
