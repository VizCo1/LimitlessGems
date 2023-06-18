using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class CounterZone : QueueZone
{
    [NonZSerialized][SerializeField] WorkZone workZone;

    public List<CustomQueue> counters { get; private set; } = new();

    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < MaxActiveSpots; i++)
        {
            GameObject counter = transform.GetChild(SLOTS_INDEX).GetChild(i).gameObject; 
            counters.Add(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<CustomQueue>());
        }       
    }
    private void Start()
    {
        for (int i = 0; i < ActiveSpots; i++)
        {
            GameObject counter = transform.GetChild(SLOTS_INDEX).GetChild(i).gameObject;
            counter.SetActive(true);
        }
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
            Counter counter = c.queueFlow.GetComponent<Counter>();
            counter.DoMajorUpgrade();
        }
    }
}
