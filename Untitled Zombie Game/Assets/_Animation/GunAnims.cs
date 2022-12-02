using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnims : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        if (Input.GetKey(KeyCode.Mouse0) == true)
        {
            animator.SetBool("IsFiring", true);
        }
        else
        {
            animator.SetBool("IsFiring", false);
        }
    }
}
