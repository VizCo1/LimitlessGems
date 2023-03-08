using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    const int SLOTS = 0;


    TransformPriorityQueue priorityQueue = new();
    
    [SerializeField] int numberOfSlots;

    int maxSlots;


    void Start()
    {
        maxSlots = transform.childCount;

        // Fill the priorityQueue with the available slots
        for (int i = 0; i < numberOfSlots; i++)
            priorityQueue.Enqueue(transform.GetChild(SLOTS).GetChild(i), 0);
    }

    void Update()
    {
        
    }

    public void AddSlot()
    {
        Transform newSlot = transform.GetChild(++numberOfSlots);
        newSlot.gameObject.SetActive(true);
        priorityQueue.Enqueue(newSlot, 0);
    }

    public Vector3 BestPosition()
    {
        Transform bestSlot = priorityQueue.Peek();
        priorityQueue.DecreasePriority(bestSlot);
        return bestSlot.position;
    }
}
