using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuesZoneManager : MonoBehaviour
{
    const int SLOTS_INDEX = 0;

    // La cola de prioridad tiene acceso a todas las colas.

    // Cuando el cliente llega a la posicion 0 de la cola --> Podra realizar su pedido

    QueuePriorityQueue priorityQueue = new();
    
    [SerializeField] int activeSlots;

    int maxSlots;


    void Start()
    {
        maxSlots = transform.childCount;

        // Fill the priorityQueue with the available slots
        for (int i = 0; i < activeSlots; i++)
            priorityQueue.Enqueue(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<CustomQueue>(), 0);
    }

    void Update()
    {

    }

    public void AddQueue()
    {
        // To add a new queue use AddQueue()
        CustomQueue newSlot = transform.GetChild(++activeSlots).GetComponent<CustomQueue>();
        newSlot.gameObject.SetActive(true);
        priorityQueue.Enqueue(newSlot, 0);
    }

    public void MoveAgentToSpot(AgentBase agent)
    {
        CustomQueue bestQueue = priorityQueue.Peek();
        priorityQueue.IncreasePriority(bestQueue);
        bestQueue.Enqueue(agent);
        
    }

    public void DecreasePriorityOfQueue(CustomQueue queue)
    {
        priorityQueue.DecreasePriority(queue);
    }
}
