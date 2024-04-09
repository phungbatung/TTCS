using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions
{
    public static GameObject Spawn(this GameObject prefab)
    {
        return PoolManager.Spawn(prefab);
    }
    public static void Despawn(this GameObject prefab)
    {
        PoolManager.Despawn(prefab);
    }
}
