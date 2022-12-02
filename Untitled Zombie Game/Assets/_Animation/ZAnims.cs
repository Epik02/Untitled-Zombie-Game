using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZAnims : MonoBehaviour
{
    bool intrigger = false;
    public GameObject animObject;
    public Animator animator;

    GameObject tootiredtounderstand;
    void Start()
    {
        //animator = animObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "OnionZombie2 1(Clone)")
        {
            //intrigger = true;
            animator = other.transform.gameObject.GetComponent<Animator>();
            animator.SetBool("IsAttacking", true);
            Debug.Log("true");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.name == "OnionZombie2 1(Clone)")
        {
            //intrigger = false;
            animator = other.transform.gameObject.GetComponent<Animator>();
            animator.SetBool("IsAttacking", false);
            Debug.Log("false");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(intrigger == true)
        //{
        //    Debug.Log("Workomon");
        //    animator.SetBool("IsAttacking", true);
        //}
        //else
        //{
        //    animator.SetBool("IsAttacking", false);
        //}
    }
}
