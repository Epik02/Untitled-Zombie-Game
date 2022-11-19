using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ScoreManager : MonoBehaviour

{
    public static ScoreManager instance;

    public int EnemyCounter = 0;

    public TMP_Text ChangingText;
    int score = 200;
    // Start is called before the first frame update
    void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    public void ChangeScore(int killValue)
    {
        score += killValue;
        Debug.Log(score);
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
}
