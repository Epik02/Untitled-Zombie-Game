using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabEnemies : MonoBehaviour
{
    public GameObject Enemy1;
   // public GameObject Enemy2;
    public int xRandom1 = 10;
    public int xRandom2 = 25;
    public int zRandom1 = 1;
    public int zRandom2 = 20;
    public int enemyCount;
    public int MaxEnemy;
    public int newHealth;
    public int damageValue;

    public Health healthchange;
    public EnemyController EnemyDamage;

    IEnumerator EnemyDrop()
    {
        while (enemyCount < MaxEnemy)
        {
            //xPos = Random.Range(1, 30);
            //yPos = Random.Range(1, 2);
            //zPos = Random.Range(1, 10);

            EnemyPool.Spawn(Enemy1, new Vector3(Random.Range(xRandom1, xRandom2), 2.4f, Random.Range(zRandom1, zRandom2)), Quaternion.identity);
            //Instantiate(Enemy1, new Vector3(Random.Range(1, 30), 2, Random.Range(1, 10)), Quaternion.identity);
            // Instantiate(Enemy2, new Vector3(Random.Range(1, 30), 3, Random.Range(1, 10)), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }

    }

    void Update()
    {
        if (ScoreManager.instance.GetEnemyNumber() <= 0 && enemyCount <= 0)
        {
            //enemyCount = 0;
            StartCoroutine(EnemyDrop());
            healthchange = Enemy1.GetComponent<Health>();
            healthchange.SetMaxHealth(newHealth);
            EnemyDamage = Enemy1.GetComponent<EnemyController>();
            EnemyDamage.SetDamage(damageValue);
        }
    }

    public void SetMaxEnemy(int Value)
    {
        MaxEnemy = Value;   
    }

    public void SetNewHealth(int value)
    {
        //healthchange = Enemy1.GetComponent<Health>();
        newHealth = value;
    }

    public void SetNewDamage(int value)
    {
        damageValue = value;
    }

    public void SetEnemyCount()
    {
        enemyCount = 0;
    }
}
