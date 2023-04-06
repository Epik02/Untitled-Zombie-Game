using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;

    public bool masterMPGame = false;

    private void Start()
    {
        GameObject mpObj = GameObject.Find("MultiplayerGameObject");
        masterMPGame = mpObj.GetComponent<ClientScript>().masterGame;

        if (masterMPGame == true)
        {
            player = GameObject.FindWithTag("Player");
            player = GameObject.Find("PlayerCapsule");
            agent = this.transform.gameObject.GetComponent<NavMeshAgent>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (masterMPGame == true)
        {
            if (player.gameObject != null && gameObject.activeSelf)
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }
}
