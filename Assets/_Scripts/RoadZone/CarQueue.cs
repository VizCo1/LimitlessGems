using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarQueue : MonoBehaviour
{
    CustomQueue customQueue;
    bool placeOccupied = false;

    void Awake()
    {
        customQueue = GetComponent<CustomQueue>();
    }

    private void Update()
    {
        if (customQueue.Count() != 0 && !placeOccupied)
        {
            placeOccupied = true;
            customQueue.Dequeue();
        }
    }
}
