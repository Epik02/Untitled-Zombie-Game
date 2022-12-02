using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZAnims : MonoBehaviour
{
    bool intrigger = false;
    public Animator animator;
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OnionZombie2")
        {
            intrigger = true;
            Debug.Log("true");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "OnionZombie2")
        {
            intrigger = false;
            Debug.Log("false");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(intrigger == true)
        {
            Debug.Log("Workomon");
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
}
