using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestZone : QueueZone
{
    public List<CustomQueue> cubicles { get; private set; } = new();

    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < maxActiveSpots; i++)
            cubicles.Add(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<CustomQueue>());
    }

    public override void AddQueue()
    {
        // To add a new queue use AddQueue()
        CustomQueue newSlot = cubicles[activeSpots++];
        newSlot.gameObject.SetActive(true);
        priorityQueue.Enqueue(newSlot, 0);
    }

    public override void MajorUpgrade()
    {
        foreach (CustomQueue cub in cubicles)
        {
            cub.queueFlow.GetComponent<RestCubicle>().DoMajorUpdate();
        }
    }
}
