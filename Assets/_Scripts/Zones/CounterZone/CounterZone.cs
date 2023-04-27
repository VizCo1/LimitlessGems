using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterZone : QueueZone
{
    [SerializeField] WorkZone workZone;

    public List<Counter> counters { get; private set; } = new();

    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < transform.GetChild(SLOTS_INDEX).childCount; i++)        
            counters.Add(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<Counter>());
    }

    public bool TryToProvideGemWithWorkZone(int gem, Counter counter)
    {
        return workZone.TryProvideGem(gem, counter);
    }

    public WorkZone GetWorkZone()
    {
        return workZone;
    }
}
