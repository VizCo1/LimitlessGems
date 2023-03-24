using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    ObjectPool objectPool;

    void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    float time = 2f;
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 2;
            if (objectPool.GetPooledObject() == null)
                Debug.Log("Max of clients reached, can't spawn more");
        }
    }
}
