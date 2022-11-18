using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public List<WaveHolder> WaveList;

    public float TimeLeft = 5.0f;
    public float TimeAdder;
    public bool ActiveEnemyWave = false;

    public PrefabEnemies enemyspawner;

    public int EnemyNumbers = 0;
    public int counter;

    void Update()
    {
        TimeLeft -= Time.deltaTime;

        if (ScoreManager.instance.GetEnemyNumber() <= 0 && TimeLeft <= 0 && !ActiveEnemyWave)
        {
            TimeLeft += TimeAdder;
            ActiveEnemyWave = true;
        }
        
        //Add text displaying time left before next wave
        if (ScoreManager.instance.GetEnemyNumber() <= 0 && counter == 0f && TimeLeft <= 0 && ActiveEnemyWave)
        {
            EnemyNumbers += 10;
            WaveCounter(EnemyNumbers);
            counter++;
            ActiveEnemyWave = false;
        }
    }

    public void WaveCounter(int increase)
    {
        Debug.Log(increase);
        enemyspawner.SetMaxEnemy(increase);
    }
}