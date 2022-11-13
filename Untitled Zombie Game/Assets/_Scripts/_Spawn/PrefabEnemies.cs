using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabEnemies : MonoBehaviour
{
    public GameObject Enemy1;
   // public GameObject Enemy2;

    public int xPos;
    public int zPos;
    public int yPos;
    public int enemyCount;

    //void Start()
   // {
        //StartCoroutine(EnemyDrop());
   // }
    
    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(1, 30);
            //yPos = Random.Range(1, 2);
            zPos = Random.Range(1, 10);

            EnemyPool.Spawn(Enemy1, new Vector3(Random.Range(1, 30), 2, Random.Range(1, 10)), Quaternion.identity);
            //Instantiate(Enemy1, new Vector3(Random.Range(1, 30), 2, Random.Range(1, 10)), Quaternion.identity);
            // Instantiate(Enemy2, new Vector3(Random.Range(1, 30), 3, Random.Range(1, 10)), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }

    }

    void Update()
    {
        if (ScoreManager.instance.GetEnemyNumber() <= 0)
        {
            enemyCount = 0;
            StartCoroutine(EnemyDrop());
        }
    }
}
