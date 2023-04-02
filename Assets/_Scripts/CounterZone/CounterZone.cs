using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterZone : QueueZone
{
    [SerializeField] WorkZone workZone;   

    public void CommunicateWithWorkZone(int gem, ref Sequence sequence)
    {
        workZone.ProvideGem(gem, ref sequence);
    }
}
