using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField]private int initialPoolSize;

    private Stack<GameObject> pooledInstances = new Stack<GameObject>();
    private List<GameObject> aliveInstances = new List<GameObject>();

    public GameObject Prefab { get { return prefab; } }
    private void Awake()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject instance = Instantiate(prefab);
            instance.transform.SetParent(transform);
            instance.transform.localPosition = Vector3.zero;
            instance.SetActive(false);
            pooledInstances.Push(instance);
        }
    }

    public GameObject Spawn()
    {
        if (pooledInstances.Count <= 0)
        {
            GameObject newInstance = Instantiate(prefab);
            newInstance.transform.SetParent(transform);
            newInstance.transform.localPosition = Vector3.zero;
            newInstance.SetActive(false);
            pooledInstances.Push(newInstance);
        }
        GameObject obj = pooledInstances.Pop();
        obj.transform.SetParent(null);
        obj.SetActive(true);
        obj.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
        aliveInstances.Add(obj);
        return obj;
    }

    public void DeSpawn(GameObject obj)
    { 

        int indexInstance = aliveInstances.FindIndex(o => obj == o);
        if (indexInstance == -1)
        {
            Destroy(obj);
            return;
        }
        obj.SendMessage("OnPreDisable", SendMessageOptions.DontRequireReceiver);
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        aliveInstances.RemoveAt(indexInstance);
        pooledInstances.Push(obj);
    }
    public bool IsResponsibleForObject(GameObject obj)
    {
        int index = aliveInstances.FindIndex(o => obj == o);
        if (index == -1)
            return false;
        return true;
    }
}
