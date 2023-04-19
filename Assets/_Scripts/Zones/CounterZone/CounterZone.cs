using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterZone : QueueZone
{
    [SerializeField] WorkZone workZone;   

    public bool TryToProvideGemWithWorkZone(int gem, Counter counter)
    {
        return workZone.TryProvideGem(gem, counter);
    }

    public WorkZone GetWorkZone()
    {
        return workZone;
    }
}
