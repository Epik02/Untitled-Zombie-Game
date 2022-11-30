using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Doors : MonoBehaviour
{

    bool intrigger = false;
    public GameObject doorPrompt;
    public GameObject door;
    public TMP_Text ChangingText;
    public int pointsToBuy = 0;
    string pointsToBuyText = "0";

    void destroyObstacle()
    {
        Destroy(door);
        doorPrompt.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            intrigger = true;
            Debug.Log("true");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            intrigger = false;
            Debug.Log("false");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (intrigger == true)
        {
            doorPrompt.SetActive(true);
            ChangingText.text = pointsToBuy.ToString() + " points to clear debris";
            if (Input.GetKeyDown(KeyCode.E) == true)
            {
                Debug.Log("It workie");
                ScoreManager.instance.DecreaseScore(pointsToBuy);
                destroyObstacle();
            }
        }
        else
        {
            doorPrompt.SetActive(false);
        }
    }
}
