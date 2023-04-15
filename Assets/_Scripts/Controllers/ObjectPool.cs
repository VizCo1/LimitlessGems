using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject objectToPool;
    [SerializeField] int poolSize;
    int activeObjects = 0;

    Vector3 spawnPosition;

    private List<GameObject> pooledObjects = new();

    void Start()
    {
        spawnPosition = objectToPool.transform.position;

        pooledObjects.Add(objectToPool);

        // i = 1 --> The game starts with 1 client not with 0 clients
        for (int i = 1; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectToPool, spawnPosition, Quaternion.identity, transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        if (activeObjects < poolSize)
            foreach (GameObject obj in pooledObjects)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    activeObjects++;
                    return obj;
                }
            }

        return null;

        /*
        GameObject newObj = Instantiate(objectToPool);
        pooledObjects.Add(newObj);
        newObj.SetActive(true);
        return newObj;
        */
    }

    public void ReturnPooledObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = spawnPosition; // move object off-screen
    }
}