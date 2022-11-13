using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyPool
{
    private static Dictionary<string, Pools> pools = new Dictionary<string, Pools>();

    public static void Spawn(GameObject go, Vector3 pos, Quaternion rot)
    {
        GameObject obj;
        string key = go.name.Replace("(Clone)", "");

        if (pools.ContainsKey(key))
        {
            if(pools[key].inactive.Count == 0)
            {
                Object.Instantiate(go, pos, rot, pools[key].Enemy.transform);
            }
            else
            {
                obj = pools[key].inactive.Pop();
                obj.transform.position = pos;
                obj.transform.rotation = rot;
                obj.SetActive(true);
            }
        }
        else
        {
            GameObject newEnemy = new GameObject($"{key}_POOL");
            Object.Instantiate(go, pos, rot, newEnemy.transform);
            Pools newPools = new Pools(newEnemy);
            pools.Add(key, newPools);
        }
    }

    public static void Despawn(GameObject go)
    {
        string key = go.name.Replace("(Clone)", "");

        if (pools.ContainsKey(key))
        {
            pools[key].inactive.Push(go);
            go.transform.position = pools[key].Enemy.transform.position;
            go.SetActive(false);
        }
        else
        {
            GameObject newEnemy = new GameObject($"{key}_POOL");
            Pools newPool = new Pools(newEnemy);

            go.transform.SetParent(newEnemy.transform);

            pools.Add(key, newPool);
            pools[key].inactive.Push(go);
            go.SetActive(false);
        }
    }
}
