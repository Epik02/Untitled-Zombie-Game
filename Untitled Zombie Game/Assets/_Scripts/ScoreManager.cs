using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ScoreManager : MonoBehaviour

{
    public static ScoreManager instance;

    public int EnemyCounter = 0;
    public int WaveCounter = 0;
    public int TotalScore = 0;

    public TMP_Text ChangingText;
    public TMP_Text EnemyCountText;
    public TMP_Text WaveCounterText;

    int score = 200;
    // Start is called before the first frame update
    void Awake()
    {
        if(!instance)
        {
            instance = this;
            TotalScore = score;
        }
    }

    public void ChangeScore(int killValue)
    {
        score += killValue;
        TotalScore += killValue;
        Debug.Log(score);
        Debug.Log(TotalScore);
    }

    public void DecreaseScore(int decrease)
    {
        score -= decrease;
        Debug.Log(score);
    }
    public int GetScore()
    {
        return score;
    }

    public void Update()
    {
        ChangingText.text = score.ToString();
        EnemyCountText.text = EnemyCounter.ToString();
        WaveCounterText.text = WaveCounter.ToString();
    }

    public void AddEnemy()
    {
        EnemyCounter++;
    }
    public void DecreaseEnemy()
    {
        EnemyCounter--;
    }
    public int GetEnemyNumber()
    {
        //Debug.Log(EnemyCounter);
        return EnemyCounter;
    }
    public void SetEnemyNumber(int other)
    {
        EnemyCounter += other;
    }
    
    public void SetWaveCounter(int other)
    {
        WaveCounter += other;
    }
}
