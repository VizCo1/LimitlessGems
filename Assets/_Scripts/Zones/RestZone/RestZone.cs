using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestZone : QueueZone
{
    public List<CustomQueue> cubicles { get; private set; } = new();

    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < MaxActiveSpots; i++)
            cubicles.Add(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<CustomQueue>());
    }

    private void Start()
    {
        for (int i = 0; i < ActiveSpots; i++)
        {
            GameObject restCubicle = transform.GetChild(SLOTS_INDEX).GetChild(i).gameObject;
            restCubicle.SetActive(true);
        }
    }

    public override void AddQueue()
    {
        // To add a new queue use AddQueue()
        CustomQueue newSlot = cubicles[ActiveSpots++];
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
