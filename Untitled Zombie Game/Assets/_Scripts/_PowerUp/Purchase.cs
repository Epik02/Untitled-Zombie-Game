using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    [SerializeField] private Renderer Object;

    public int decreaseScore = 500;

    public GameObject GunThing;

    public GameObject ActiveText;

    public WeaponSwitch ShootScript;

    //int EarnPoints = 0;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            if (ScoreManager.instance.GetScore() >= 500)
            {
                StartCoroutine(TextAnimation());
                ScoreManager.instance.DecreaseScore(decreaseScore);
                Object.material.color = Color.blue;
                ShootScript.Setvalue(1);
            }
            else
            {
                Debug.Log("<color-red> You Don't Have Enough Score");
                Object.material.color = Color.black;
            }
            
        }
    }

    public void Update()
    {
        ShootScript = GunThing.GetComponent<WeaponSwitch>();
    }
     IEnumerator PowerUp()
    {
        Debug.Log("Power up started!");
        yield return new WaitForSeconds(5f);
        Object.material.color = Color.red;

        Debug.Log("Power Ended");
    }
    IEnumerator TextAnimation()
    {
        //Debug.Log("Power text up!");
        ActiveText.SetActive(true);
        yield return new WaitForSeconds(3f);
        ActiveText.SetActive(false);

        //Debug.Log("Power Ended");
    }
}
