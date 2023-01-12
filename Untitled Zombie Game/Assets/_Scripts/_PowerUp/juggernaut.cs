using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juggernaut : MonoBehaviour
{
    [SerializeField] private Renderer Object;

    public PlayerHealth PlayerHealth;

    public GameObject MaxText;

    public int JugHeathValue;

    public int DecreaseScore = 100;



    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            if (ScoreManager.instance.GetScore() > 0)
            {
                StartCoroutine(TextAnimation());
                ScoreManager.instance.DecreaseScore(DecreaseScore);
                Object.material.color = Color.red;
                PlayerHealth?.SetHealth(JugHeathValue);
            }
            else
            {
                Debug.Log("<color-black> You Don't Have Enough Score");
                Object.material.color = Color.black;
            }

        }
    }

    IEnumerator TextAnimation()
    {
        //Debug.Log("Power text up!");
        MaxText.SetActive(true);
        yield return new WaitForSeconds(3f);
        MaxText.SetActive(false);

        //Debug.Log("Power Ended");
    }
}
