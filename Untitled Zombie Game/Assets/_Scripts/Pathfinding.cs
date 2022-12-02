using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;

    private void Start()
    {
       // player = GameObject.FindWithTag("Player");
        player = GameObject.Find("PlayerCapsule");
        agent = this.transform.gameObject.GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        //if (player.gameObject != null && gameObject.activeSelf)
        //{
            agent.SetDestination(player.transform.position);
            Debug.Log("THIS IS 69");
        //}
    }
}
