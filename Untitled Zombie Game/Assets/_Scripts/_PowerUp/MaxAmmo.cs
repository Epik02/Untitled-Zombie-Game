using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAmmo : MonoBehaviour
{
    [SerializeField] private Renderer Object;

    public int decreaseScore = 500;

    public GameObject GunObjectThing;

    public GameObject MaxText;

    public WeaponSwitch ShootScript;

    //int EarnPoints = 0;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            if (ScoreManager.instance.GetScore() > 0)
            {
                StartCoroutine(TextAnimation());
                ScoreManager.instance.DecreaseScore(decreaseScore);
                Object.material.color = Color.green;
                ShootScript.SetAmmo(ShootScript.GetValue());
            }
            else
            {
                Debug.Log("<color-red> You Don't Have Enough Score");
                Object.material.color = Color.red;
            }

        }
    }

    public void Update()
    {
        ShootScript = GunObjectThing.GetComponent<WeaponSwitch>();
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
