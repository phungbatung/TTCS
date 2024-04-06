using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static Dictionary<GameObject, Pool> currentPools = new Dictionary<GameObject, Pool>();
    private void Start()
    {
        Pool[] pools = gameObject.GetComponentsInChildren<Pool>();
        for (int i=0; i<pools.Length; i++)
        {
            currentPools[pools[i].Prefab] = pools[i];
        }
    }

    public static GameObject Spawn(GameObject prefab)
    {
        if(!currentPools.ContainsKey(prefab))
        {
            Debug.Log("Debug: Spawn 1");
            return Instantiate(prefab);
        }
        Debug.Log("Debug: Spawn 2");
        return currentPools[prefab].Spawn();
    }
    public static void Despawn(GameObject obj)
    {
        foreach(KeyValuePair<GameObject, Pool> pool in currentPools)
        {
            if (pool.Value.IsResponsibleForObject(obj))
            {
                pool.Value.DeSpawn(obj);
                return;
            }
        }
        Destroy(obj);
    }
}
