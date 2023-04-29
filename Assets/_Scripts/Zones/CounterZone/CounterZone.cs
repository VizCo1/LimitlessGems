using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterZone : QueueZone
{
    [SerializeField] WorkZone workZone;

    public List<CustomQueue> counters { get; private set; } = new();

    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < maxActiveSpots; i++)        
            counters.Add(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<CustomQueue>());
    }

    public bool TryToProvideGemWithWorkZone(int gem, Counter counter)
    {
        return workZone.TryProvideGem(gem, counter);
    }

    public WorkZone GetWorkZone()
    {
        return workZone;
    }

    public override void MajorUpgrade()
    {
        foreach (CustomQueue c in counters)
        {
            c.GetComponent<RestCubicle>().DoMajorUpdate();
        }
    }
}
