using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Movement player;
    public float playerx = 0;
    public float playery = 0;
    public float playerz = 0;

    // Update is called once per frame
    void Update()
    {
        playerx = player.transform.position.x;
        playery = player.transform.position.y;
        playerz = player.transform.position.z;
    }
}
