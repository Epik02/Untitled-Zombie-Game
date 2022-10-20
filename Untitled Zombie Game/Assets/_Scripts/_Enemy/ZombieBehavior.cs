using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZombieBehavior : MonoBehaviour
{
    //public Movement playerpos;
    public Rigidbody zombieBody;
    public ZombieBehavior zombie;
    public float speed = 1;
    public float strafeSpeed = 1;

    public GameObject mplayer;

    public float rotationangle, x1 = 1, z1 = 1;
    public float fpi = Mathf.PI;

    private GameObject zombieClone;

    public float rise = 0;
    public float run = 0;
    float slope = 0;
    float b = 0;
    float followx = 0;
    float followz = 0;
    Vector3 relPos;
    float avoidDirection = 0;

    public Vector3 strafe;
    public bool NoObstacles = true;

    float frontSensorStart = 1;
    public float sensorLength = 5;

    private void Start()
    {
        mplayer = GameObject.FindWithTag("Player");
    }

    void zombieMovement() //BEDMAS is not built into C# you need to use brackets
    {
        rise = (zombieBody.transform.position.z) - (mplayer.transform.position.z);
        run = (zombieBody.transform.position.x) - (mplayer.transform.position.x);

        slope = rise / run;
        b = mplayer.transform.position.z - slope * mplayer.transform.position.x;

        followz = slope * mplayer.transform.position.x + b; //y=mx+b
        followx = (mplayer.transform.position.z - b) / slope; //slope should not be able to equal 0 
        relPos = new Vector3(followx, zombieBody.transform.position.y, followz);

        if (NoObstacles)
        {
            GetComponent<Rigidbody>().velocity = (relPos - zombieBody.transform.position) * speed;
        }
        else
        {
            //Actual Zombie Movement
            if (avoidDirection == -1)
            {
                GetComponent<Rigidbody>().velocity = -transform.right * strafeSpeed;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = transform.right * strafeSpeed;
            }
        }
    }

    void collisionAvoidance()
    {
        RaycastHit hit;
        Vector3 sensorPos = transform.position + (transform.forward * frontSensorStart);
        if (Physics.Raycast(sensorPos, transform.forward, out hit, sensorLength) || Physics.Raycast(sensorPos, -transform.right, out hit, sensorLength) || Physics.Raycast(sensorPos, transform.right, out hit, sensorLength))
        {
            if(hit.normal.x < 0)
            {
                avoidDirection = -1;
                NoObstacles = false;
                //GetComponent<Rigidbody>().velocity = (transform.forward + -transform.right + strafe) * speed;
            }
            else if(hit.normal.x > 0)
            {
                avoidDirection = 1;
                strafe.x = strafe.x * avoidDirection;
                NoObstacles = false;
                //GetComponent<Rigidbody>().velocity = (transform.forward + transform.right + strafe) * strafeSpeed;
            }
            Debug.DrawLine(transform.position, hit.point, Color.red);
            Debug.Log(avoidDirection);
        }
        else if (NoObstacles == false) {
            NoObstacles = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
       zombieMovement();
       //collisionAvoidance();

        //Rotates the zombie towards the player (required for collision avoidance)
        Vector3 direction = mplayer.transform.position - transform.position;
        Quaternion rotateTowardsPlayer = Quaternion.LookRotation(direction);
        transform.rotation = rotateTowardsPlayer;
    }
}
