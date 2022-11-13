using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pools
{
    public Stack<GameObject> inactive = new Stack<GameObject>();
    public GameObject Enemy;

    public Pools(GameObject Enemy)
    {
        this.Enemy = Enemy;
    }
}
