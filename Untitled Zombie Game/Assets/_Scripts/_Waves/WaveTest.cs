using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveTest : MonoBehaviour
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
        //Add text displaying time left before next wave
        //if (ScoreManager.instance.GetEnemyNumber() <= 0)
        //{
        //    Debug.Log("HI from Waves 1st.");
        //}
        //if (ActiveEnemyWave == true)
        //{
        //    Debug.Log("HI from Waves 2nd.");
        //}
        //if (TimerDone == true)
        //{
        //    Debug.Log("HI from Waves 3rd.");
        //}
        //Debug.Log(ScoreManager.instance.GetEnemyNumber());

        if (TimerDone == false && ActiveEnemyWave == false)
        {
            TimeLeft -= Time.deltaTime;
            TimeText = (int)TimeLeft;
            TimerText.text = TimeText.ToString();
           // Debug.Log("Decreasing Time");

            if (TimeLeft <= 0)
            {
                //Detect when timer is done
                TimerDone = true;
                TimeLeft = 2;
                TextSet.SetActive(false);
                Debug.Log("Time is Done, Hide Text");
            }
        }

        if (ScoreManager.instance.GetEnemyNumber() <= 0 && ActiveEnemyWave == true)
        {
            Debug.Log("Start New Timer");
            //End Wave
            TimerDone = false;
            ActiveEnemyWave = false;
            //Start New Timer
            TimeLeft = TimeAdder;
            TextSet.SetActive(true);
        }

        if (TimerDone == true && ActiveEnemyWave == false)
        {
            //Start New Wave
            ScoreManager.instance.SetWaveCounter(1);
            Debug.Log("Start New Wave");
            WaveCounter(WaveList[ListIncrease].EnemyNumber);
            enemyspawner.SetNewHealth(WaveList[ListIncrease].MaxHealth);
            enemyspawner.SetNewDamage(WaveList[ListIncrease].EnemyDamageValue);
            ListIncrease++;
            //Enable ActiveEnemyWave
            ActiveEnemyWave = true;
        }

        
        

        ////Is the filler time in between waves
        //if (TimerDone == false && TimeLeft > 0)
        //{
        //    //TextSet.SetActive(true);
        //    TimeLeft -= Time.deltaTime;
        //    TimeText = (int)TimeLeft;
        //    TimerText.text = TimeText.ToString();
        //    Debug.Log("Clause 1");
        //    return;
        //}

        ////Declares The Timer is finished
        //if (TimeLeft <= 0)
        //{
        //    TextSet.SetActive(false);
        //    ActiveEnemyWave = true;
        //    TimerDone = true;
        //    TimeLeft = TimeAdder;
        //    Debug.Log("Clause 2");
        //    return;
        //}

        ////Spawns new enemy wave
        //if (ScoreManager.instance.GetEnemyNumber() <= 0 && ActiveEnemyWave == true && TimerDone == true)
        //{
        //    //StartCoroutine(AddNewWave());

        //    ActiveEnemyWave = false;
        //    TimerDone = false;
        //    Debug.Log("New Wave");
        //    WaveCounter(WaveList[ListIncrease].EnemyNumber);
        //    enemyspawner.SetNewHealth(WaveList[ListIncrease].MaxHealth);
        //    enemyspawner.SetNewDamage(WaveList[ListIncrease].EnemyDamageValue);
        //    ListIncrease++;
        //    return;  
        //}

        //Display Timer during downtime
        //End downtime when timer ends
        //Do wave
        //Reset Timer and start downtime

        //if (ScoreManager.instance.GetEnemyNumber() <= 0 && TimerDone == true)
        //{
        //    TimeLeft = TimeAdder;
        //    TextSet.SetActive(true);
        //    ActiveEnemyWave = true;
        //    TimerDone = false;
        //    Debug.Log("from 3rd if statement");
        //    return;
        //}
    }

    public void WaveCounter(int increase)
    {
        Debug.Log(increase);
        enemyspawner.SetEnemyCount();
        enemyspawner.SetMaxEnemy(increase);
    }
}
