using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Waves : MonoBehaviour
{

    // Define Listing of Wave Created and show it and to be used
    public List<WaveHolder> WaveList;

    //Variables
    public float TimeLeft;
    public float TimeAdder;
    public bool ActiveEnemyWave;
    public int TimeText;
    public bool TimerDone;

    // EnemySummon Script
    public PrefabEnemies enemyspawner;

    //Array List Number
    public int ListIncrease;

    //text
    public TMP_Text TimerText;

    public GameObject TextSet;

    void Start()
    {
        TextSet.SetActive(true);
        ActiveEnemyWave = false;
        TimerDone = false;
        enemyspawner.SetNewHealth(100);
        TimeLeft = TimeAdder;
    }

    void Update()
    {
         if (TimerDone == false && TimeLeft > 0)
         {
            //TextSet.SetActive(true);
            TimeLeft -= Time.deltaTime;
            TimeText = (int)TimeLeft;
            TimerText.text = TimeText.ToString();
         }
        else
        {
           TimeLeft = TimeAdder;
           TextSet.SetActive(false);
           ActiveEnemyWave = true;
           TimerDone = true;
        }
        //Add text displaying time left before next wave
        if (ScoreManager.instance.GetEnemyNumber() <= 0 && ActiveEnemyWave == true && TimerDone == true)
        {
            //StartCoroutine(AddNewWave());
            ActiveEnemyWave = false;
            Debug.Log("Wow");
            WaveCounter(WaveList[ListIncrease].EnemyNumber);
            enemyspawner.SetNewHealth(WaveList[ListIncrease].MaxHealth);
            enemyspawner.SetNewDamage(WaveList[ListIncrease].EnemyDamageValue);
            ListIncrease++;
            TimerDone = false;
        }

        //if (ScoreManager.instance.GetEnemyNumber() <= 0 && TimeLeft <= 0f && ActiveEnemyWave == false && TimerDone == true)
        //{
        //TextSet.SetActive(true);
        //TimeLeft = TimeAdder;
        //TimerDone = false;
        //}
    }

    public void WaveCounter(int increase)
    {
        Debug.Log(increase);
        enemyspawner.SetMaxEnemy(increase);
    }
}
