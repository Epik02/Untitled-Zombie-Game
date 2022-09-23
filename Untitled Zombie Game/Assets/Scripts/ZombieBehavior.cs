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

    //new shit
    float rise = 0;
    float run = 0;
    float slope = 0;
    float b = 0;
    float followx = 0;
    float followz = 0;
    float test = 0;
    //new shit

    Vector3 relPos;

    void zombieMovement() //change it so the zombie gameobject is being rotated. currently only the original is
    {
        rise = (mplayer.playerz) - (zombieObject.transform.position.z);
        run = (mplayer.playerx) - (zombieObject.transform.position.x);

        slope = rise / run;
        //y = mx + b
        b = slope * mplayer.playerx - mplayer.playerz;
        b = b / -1;
        followz = slope * mplayer.playerx + b;
        followx = mplayer.playerz - b / slope;
        relPos = new Vector3(followx, zombieObject.transform.position.y, followz);
        Debug.Log(run);
        //so zombie follows player
        GetComponent<Rigidbody>().velocity = (relPos - zombieBody.transform.position) * speed;
        // zombieObject.transform.SetPositionAndRotation(relPos, Quaternion.Euler(0, 0, 0));

    }

    //sort of functional movement
    //void zombieMovement() //change it so the zombie gameobject is being rotated. currently only the original is
    //{

    //    x1 = (zombieBody.position.x) - (mplayer.playerx);
    //    z1 = (mplayer.playerz) - (zombieBody.position.z);
    //    rotationangle = (Mathf.Atan(z1 / x1)) * (180 / fpi);

    //    if (zombieObject.transform.position.x > mplayer.playerx) //bottom left
    //    {
    //        zombieBody.velocity = new Vector3(-speed, zombieBody.velocity.y, zombieBody.velocity.z);

    //    }
    //    else if (zombieObject.transform.position.x < mplayer.playerx) //bottom right
    //    {
    //        zombieBody.velocity = new Vector3(speed, zombieBody.velocity.y, zombieBody.velocity.z);
    //       // zombie.zombieBody.SetRotation(-rotationangle);
    //    }
    //    if (zombieObject.transform.position.z > mplayer.playerz)
    //    {
    //        zombieBody.velocity = new Vector3(zombieBody.velocity.x, zombieBody.velocity.y, -speed);
    //    }
    //    else if (zombieObject.transform.position.z < mplayer.playerz)
    //    {
    //        zombieBody.velocity = new Vector3(zombieBody.velocity.x, zombieBody.velocity.y, speed);
    //    }
    //    if (zombieObject.transform.position.y > mplayer.playery)
    //    {
    //        zombieBody.velocity = new Vector3(zombieBody.velocity.x, -speed, zombieBody.velocity.z);
    //    }
    //    else if (zombieObject.transform.position.z < mplayer.playerz)
    //    {
    //        zombieBody.velocity = new Vector3(zombieBody.velocity.x, speed, zombieBody.velocity.z);
    //    }

    //}

    // Update is called once per frame
    void Update()
    {
        zombieMovement();
    }
}
