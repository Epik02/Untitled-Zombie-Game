using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareCrowAnims : MonoBehaviour
{
    Animator animator;

    public Transform player;
    public float animDistance = 10.0f;
    public Vector3 amingus;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //amingus = new Vector3(-21.2670307f, 4.08390331f, 1.51360893f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - amingus;
        if (distanceToPlayer.magnitude <= animDistance)
        {
            animator.SetBool("Present", true);
        }
        else
        {
            animator.SetBool("Present", false);
        }
    }
}

//Vector3(-21.2670002,4.08389997,1.51300001) //straw
//Vector3(5.2558322, 4.28390121, 13.0008507) //pumpkin
//Vector3(23.5950203,4.08389807,60.5528603) //skull