using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTable : MonoBehaviour
{
    float makeTime = 5f;
    Worker worker;
    bool isWorkerFree = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Worker GetWorker()
    {
        if (isWorkerFree)
            return worker;

        return null;
    }
}
