using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueFlow : MonoBehaviour
{
    [SerializeField] protected CircleCanvas circleCanvas;
    protected CustomQueue customQueue;

    protected bool placeOccupied = false;

    private void Awake()
    {
        customQueue = GetComponent<CustomQueue>();
        //customQueue.Dequeue();
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
