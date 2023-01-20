using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAmmo : MonoBehaviour
{
    [SerializeField] private Renderer Object;

    public int decreaseScore = 1000;

    public GameObject GunObjectThing;

    public GameObject MaxText;

    public WeaponSwitch ShootScript;

    //int EarnPoints = 0;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            if (ScoreManager.instance.GetScore() >= decreaseScore)
            {
                StartCoroutine(TextAnimation());
                ScoreManager.instance.DecreaseScore(decreaseScore);
                Object.material.color = Color.green;
                if (ShootScript.GunType == 0)
                {
                    ShootScript.SetAmmo(ShootScript.GetValue());
                    Debug.Log(ShootScript.GunType);
                }
                else if (ShootScript.GunType == 1)
                {
                    ShootScript.SetAmmo(ShootScript.GetBaValue());
                    Debug.Log(ShootScript.GunType);
                }
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
