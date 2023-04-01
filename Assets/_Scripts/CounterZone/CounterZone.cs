using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterZone : Zone
{
    [SerializeField] WorkZone workZone;

    readonly QueuePriorityQueue priorityQueue = new();

    int maxSlots;


    void Start()
    {
        maxSlots = transform.childCount;

        // Fill the priorityQueue with the available slots
        for (int i = 0; i < activeSpots; i++)
            priorityQueue.Enqueue(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<CustomQueue>(), 0);
    }

    public void AddQueue()
    {
        // To add a new queue use AddQueue()
        CustomQueue newSlot = transform.GetChild(++activeSpots).GetComponent<CustomQueue>();
        newSlot.gameObject.SetActive(true);
        priorityQueue.Enqueue(newSlot, 0);
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

    public void CommunicateWithWorkZone(int gem, ref Sequence sequence)
    {
        workZone.ProvideGem(gem, ref sequence);
    }
}
