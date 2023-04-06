using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabEnemies : MonoBehaviour
{
    public List<SpawnData> Placement;

    public GameObject Enemy1;
    //public GameObject Enemy2;

    public WaveTest GetValue;

    public int Spawn;
    //public int xRandom1 = 10;
    //public int xRandom2 = 20;
    //public int zRandom1 = 1;
    //public int zRandom2 = 12;
    public float yValue = 3f;
    public int enemyCount;
    public int MaxEnemy;
    public int newHealth;
    public int damageValue;

    public Health healthchange;
    public EnemyController EnemyDamage;

    public bool masterMPGame = false;

    IEnumerator EnemyDrop()
    {
        while (enemyCount < MaxEnemy)
        {
            //xPos = Random.Range(1, 30);
            //yPos = Random.Range(1, 2);
            //zPos = Random.Range(1, 10);

            //EnemyPool.Spawn(Enemy1, new Vector3(Random.Range(Placement[Spawn].Xcoor1, Placement[Spawn].Xcoor2), yValue, Random.Range(Placement[Spawn].Zcoor1, Placement[Spawn].Zcoor2)), Quaternion.identity);

            if (masterMPGame == true)
            {
                for (int i = 0; i <= GetValue.SpawnNumber; i++)
                {
                    EnemyPool.Spawn(Enemy1, new Vector3(Random.Range(Placement[i].L1.transform.position.x, Placement[i].L2.transform.position.x),
                    yValue, Random.Range(Placement[i].L1.transform.position.z, Placement[i].L2.transform.position.z)), Quaternion.identity);
                }
            }
            //EnemyPool.Spawn(Enemy1, new Vector3(Random.Range(Placement[Spawn].Xcoor1, Placement[Spawn].Xcoor2), yValue, Random.Range(Placement[Spawn].Zcoor1, Placement[Spawn].Zcoor2)), Quaternion.identity);

            //EnemyPool.Spawn(Enemy1, new Vector3(Random.Range(xRandom1, xRandom2), yValue, Random.Range(zRandom1, zRandom2)), Quaternion.identity);
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
            Spawn = GetValue.SpawnNumber;
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
