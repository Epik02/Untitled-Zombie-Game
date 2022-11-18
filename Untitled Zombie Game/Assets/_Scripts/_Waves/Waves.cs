using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public List<WaveHolder> WaveList;

    public float TimeLeft;
    public float TimeAdder;
    public bool ActiveEnemyWave;

    public PrefabEnemies enemyspawner;

    public int ListIncrease;

    void Start()
    {
        ActiveEnemyWave = false;
        enemyspawner.SetNewHealth(100);
    }

    void Update()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
        }

        //Add text displaying time left before next wave
        if (ScoreManager.instance.GetEnemyNumber() <= 0 && TimeLeft <= 0f && ActiveEnemyWave == true)
        {
            ActiveEnemyWave = false;
            Debug.Log("Wow");
            WaveCounter(WaveList[ListIncrease].EnemyNumber);
            enemyspawner.SetNewHealth(WaveList[ListIncrease].MaxHealth);
            enemyspawner.SetNewDamage(WaveList[ListIncrease].EnemyDamageValue);
            ListIncrease++;
        }

        if (ScoreManager.instance.GetEnemyNumber() <= 0 && TimeLeft <= 0f && ActiveEnemyWave == false)
        {

            ActiveEnemyWave = true;
            TimeLeft = TimeAdder;
        }
    }

    public void WaveCounter(int increase)
    {
        Debug.Log(increase);
        enemyspawner.SetMaxEnemy(increase);
    }
}
