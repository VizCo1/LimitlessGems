using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject objectToPool;
    [SerializeField] CarQueue carQueue;
    [SerializeField] int poolSize;

    private Queue<GameObject> inactivePooledObjects = new();

    void Start()
    {

        inactivePooledObjects.Enqueue(objectToPool);

        // i = 1 --> The game starts with 1 client not with 0 clients
        for (int i = 1; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectToPool, objectToPool.transform.position, Quaternion.identity, transform);
            obj.SetActive(false);
            inactivePooledObjects.Enqueue(obj);
        }
    }
    
    public void SpawnPooledObject()
    { 
        if (!carQueue.IsFull())
        {
            inactivePooledObjects.Dequeue().SetActive(true);
        }
    }

    public void ReturnPooledObject(GameObject parent)
    {
        inactivePooledObjects.Enqueue(parent);
        parent.SetActive(false);
        for (int i = 0; i < parent.transform.childCount; i++)
            parent.transform.GetChild(i).localPosition = Vector3.zero;
    }
}
