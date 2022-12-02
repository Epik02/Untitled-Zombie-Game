using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = this.transform.gameObject.GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
