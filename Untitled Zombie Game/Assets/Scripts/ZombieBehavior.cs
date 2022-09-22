using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    //public Movement playerpos;
    private float playerx;
    private float playery;
    public Rigidbody zombieBody;
    public ZombieBehavior zombie;
    public float speed = 1;
    public GameObject zombieObject;

    public Vector2 mmovement;
    public Movement mplayer;

    public float rotationangle, x1 = 1, z1 = 1;
    public float fpi = Mathf.PI;

    private GameObject zombieClone;

    Vector3 relPos;
    void zombieMovement() //change it so the zombie gameobject is being rotated. currently only the original is
    {

        x1 = (zombieBody.position.x) - (mplayer.playerx);
        z1 = (mplayer.playerz) - (zombieBody.position.z);
        rotationangle = (Mathf.Atan(z1 / x1)) * (180 / fpi);

        if (zombieObject.transform.position.x > mplayer.playerx) //bottom left
        {
            zombieBody.velocity = new Vector3(-speed, zombieBody.velocity.y, zombieBody.velocity.z);
         
        }
        else if (zombieObject.transform.position.x < mplayer.playerx) //bottom right
        {
            zombieBody.velocity = new Vector3(speed, zombieBody.velocity.y, zombieBody.velocity.z);
           // zombie.zombieBody.SetRotation(-rotationangle);
        }
        if (zombieObject.transform.position.z > mplayer.playerz)
        {
            zombieBody.velocity = new Vector3(zombieBody.velocity.x, zombieBody.velocity.y, -speed);
        }
        else if (zombieObject.transform.position.z < mplayer.playerz)
        {
            zombieBody.velocity = new Vector3(zombieBody.velocity.x, zombieBody.velocity.y, speed);
        }
        if (zombieObject.transform.position.y > mplayer.playery)
        {
            zombieBody.velocity = new Vector3(zombieBody.velocity.x, -speed, zombieBody.velocity.z);
        }
        else if (zombieObject.transform.position.z < mplayer.playerz)
        {
            zombieBody.velocity = new Vector3(zombieBody.velocity.x, speed, zombieBody.velocity.z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        zombieMovement();
    }
}
