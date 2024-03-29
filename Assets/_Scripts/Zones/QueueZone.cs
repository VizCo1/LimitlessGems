using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueZone : Zone
{
    readonly protected QueuePriorityQueue priorityQueue = new();

    protected virtual void Awake()
    {
        MaxActiveSpots = transform.GetChild(SLOTS_INDEX).childCount;
        // Fill the priorityQueue with the available slots
        for (int i = 0; i < ActiveSpots; i++)
            priorityQueue.Enqueue(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<CustomQueue>(), 0);
    }

    public virtual void AddQueue()
    {
        // To add a new queue use AddQueue()
        GameObject newSlot = transform.GetChild(SLOTS_INDEX).GetChild(ActiveSpots++).gameObject;
        newSlot.SetActive(true);
        priorityQueue.Enqueue(newSlot.GetComponent<CustomQueue>(), 0);
    }

    public bool IsZoneFull()
    {
        return ActiveSpots < transform.GetChild(SLOTS_INDEX).childCount;
    }

    public override void MoveAgentToSpot(AgentBase agent)
    {
        CustomQueue bestQueue = priorityQueue.Peek();
        priorityQueue.IncreasePriority(bestQueue);
        bestQueue.Enqueue(agent);
    }

    public void DecreasePriorityOfQueue(CustomQueue queue)
    {
        priorityQueue.DecreasePriority(queue);
    }

    public virtual void MajorUpgrade()
    {

    }
}
