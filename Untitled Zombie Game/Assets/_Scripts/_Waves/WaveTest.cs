using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

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

    public int WaveEnemyNumbers = 2;
    public int WaveEnemyIncrease = 0;

    public int WaveHealthIncrease = 200;
    public int WaveEnemyHealth;

    public int WaveDamageIncrease = 100;
    public int WaveEnemyDamage;

    public int WaveCounterPrivate = 1;

    // EnemySummon Script
    public PrefabEnemies enemyspawner;

    //Array List Number
    public int ListIncrease;

    public int SpawnNumber;

    public bool Wave10Other = false;

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
        WaveEnemyIncrease = WaveEnemyNumbers;
        WaveEnemyHealth = WaveHealthIncrease;
        WaveEnemyDamage = WaveDamageIncrease;
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
            RenderSettings.fog = false;
            TimeLeft -= Time.deltaTime;
            TimeText = (int)TimeLeft;
            TimerText.text = TimeText.ToString();
           // Debug.Log("Decreasing Time");

            if (TimeLeft <= 0)
            {
                //Detect when timer is done
                RenderSettings.fog = true;
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
            if (Wave10Other == true)
            {
                WaveEnemyIncrease = WaveEnemyIncrease + WaveEnemyNumbers;
                WaveEnemyHealth = WaveEnemyHealth + WaveHealthIncrease;
                WaveEnemyDamage = WaveEnemyDamage + WaveDamageIncrease;
            }
            if (ListIncrease <= 9)
            {
                //Start New Wave
                ScoreManager.instance.SetWaveCounter(1);
                Debug.Log("Start New Wave");
                WaveCounter(WaveList[ListIncrease].EnemyNumber);
                enemyspawner.SetNewHealth(WaveList[ListIncrease].MaxHealth);
                enemyspawner.SetNewDamage(WaveList[ListIncrease].EnemyDamageValue);
                SpawnNumber = WaveList[ListIncrease].SpawnLocationIncrease;
                ListIncrease++;
                //Enable ActiveEnemyWave
                ActiveEnemyWave = true;
            }
            else
            {
                Wave10Other = true;
                ScoreManager.instance.SetWaveCounter(1);
                WaveCounter(WaveList[9].EnemyNumber + WaveEnemyIncrease);
                enemyspawner.SetNewHealth(WaveList[9].MaxHealth + WaveEnemyHealth);
                enemyspawner.SetNewDamage(WaveList[9].EnemyDamageValue + WaveEnemyDamage);
                SpawnNumber = WaveList[9].SpawnLocationIncrease;
                ActiveEnemyWave = true;
                Debug.Log("NewWaveAdded");
            }
            
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
