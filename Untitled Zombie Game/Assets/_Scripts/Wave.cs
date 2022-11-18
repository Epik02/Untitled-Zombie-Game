using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public PrefabEnemies enemyspawner;

    public int EnemyNumbers = 0;
    public int counter;

    //public GameObject[]


    void Update()
    {
        if (ScoreManager.instance.GetEnemyNumber() <= 0 && counter == 0)
        {
            EnemyNumbers += 10;
            WaveCounter(EnemyNumbers);
            counter++;
        }
    }

    public void WaveCounter(int increase)
    {
        Debug.Log(increase);
        enemyspawner.SetMaxEnemy(increase);
    }

}
