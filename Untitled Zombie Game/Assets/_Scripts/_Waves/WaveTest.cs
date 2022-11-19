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
        //TextSet.SetActive(true);
        //ActiveEnemyWave = false;
        //TimerDone = false;
        enemyspawner.SetNewHealth(100);
        TimeLeft = TimeAdder;
    }

    void Update()
    {
        //Add text displaying time left before next wave
        if (ScoreManager.instance.GetEnemyNumber() <= 0)
        {
            Debug.Log("HI from Waves 1st.");
        }
        if (ActiveEnemyWave == true)
        {
            Debug.Log("HI from Waves 2nd.");
        }
        if (TimerDone == true)
        {
            Debug.Log("HI from Waves 3rd.");
        }
        Debug.Log("Wow 2nd statement below");
        if (ScoreManager.instance.GetEnemyNumber() <= 0 && ActiveEnemyWave == true && TimerDone == true)
        {
            //StartCoroutine(AddNewWave());
            ActiveEnemyWave = false;
            Debug.Log("Wow");
            WaveCounter(WaveList[ListIncrease].EnemyNumber);
            enemyspawner.SetNewHealth(WaveList[ListIncrease].MaxHealth);
            enemyspawner.SetNewDamage(WaveList[ListIncrease].EnemyDamageValue);
            ListIncrease++;
            //TimerDone = false;
        }

        if (TimerDone == false && TimeLeft > 0)
        {
            //TextSet.SetActive(true);
            TimeLeft -= Time.deltaTime;
            TimeText = (int)TimeLeft;
            TimerText.text = TimeText.ToString();
        }
        else if (TimerDone == false && TimeLeft <= 0)
        {
            TextSet.SetActive(false);
            TimerDone = true;
            ActiveEnemyWave = true;
            Debug.Log("From timer statement");
        }

        if (ScoreManager.instance.GetEnemyNumber() <= 0 && TimeLeft <= 0f && ActiveEnemyWave == false && TimerDone == true)
        {
            TimeLeft = TimeAdder;
            //TextSet.SetActive(true);
            ActiveEnemyWave = false;
            TimerDone = false;
            Debug.Log("from 3rd if statement");
        }
    }

    public void WaveCounter(int increase)
    {
        Debug.Log(increase);
        enemyspawner.SetMaxEnemy(increase);
    }
}
