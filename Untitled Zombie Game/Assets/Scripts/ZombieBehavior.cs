using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public float rise = 0;
    public float run = 0;
    float slope = 0;
    float b = 0;
    float followx = 0;
    float followz = 0;
    float test = 0;
    //new shit

    Vector3 relPos;

    //void zombieMovement() //change it so the zombie gameobject is being rotated. currently only the original is
    //{
    //    rise = (mplayer.playerz) - (zombieObject.transform.position.z);
    //    run = (mplayer.playerx) - (zombieObject.transform.position.x);

    //    slope = rise / run;
    //    //y = mx + b
    //    b = slope * mplayer.playerx - mplayer.playerz;
    //    b = b / -1;

    //    followz = slope * mplayer.playerz + b;
    //    followx = mplayer.playerx - b / slope;
    //    relPos = new Vector3(0, zombieObject.transform.position.y, followz);

    //    Debug.Log("Rise:" + rise + "\n");
    //    Debug.Log("Run:" + run + "\n");
    //    Debug.Log("Slope:" + slope + "\n");
    //    Debug.Log("b:" + b + "\n");
    //    Debug.Log("Followx:" + followx + "\n");
    //    Debug.Log("followz:" + followz + "\n");

    //    //so zombie follows player
    //    GetComponent<Rigidbody>().velocity = (relPos - zombieBody.transform.position) * speed;

    //    //Vector3 zombPos = zombieBody.transform.position;
    //    //Vector3 playerPos = mplayer.transform.position;
    //    //zombieObject.transform.position = Vector3.MoveTowards(zombPos, playerPos, 0.005f);
    //}
    void zombieMovement()
    {
        rise = (zombieBody.transform.position.z) - (mplayer.playerz);
        run = (zombieBody.transform.position.x) - (mplayer.playerx);
        //rise = (mplayer.playerz) - (zombieObject.transform.position.z);
        //run = (mplayer.playerx) - (zombieObject.transform.position.x);

        slope = rise / run;
        b = mplayer.transform.position.z - slope * mplayer.transform.position.x;

        followz = slope * mplayer.transform.position.x + b; //y=mx+b
        followx = (mplayer.transform.position.z - b) / slope; //slope should not be able to equal 0 
        relPos = new Vector3(followx, zombieBody.transform.position.y, followz);

        Debug.Log("rise:" + rise + "\n");
        Debug.Log("run:" + run + "\n");
        Debug.Log("followx:" + followx + "\n");
        Debug.Log("followz:" + followz + "\n");
        Debug.Log("pos:" + mplayer.transform.position.z + "\n");
        Debug.Log("slope:" + slope + "\n");
        Debug.Log("b:" + b + "\n");

        GetComponent<Rigidbody>().velocity = (relPos - zombieBody.transform.position) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        zombieMovement();
    }
}
