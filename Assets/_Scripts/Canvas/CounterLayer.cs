using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterLayer : Layer
{
    [SerializeField] CounterZone counterZone;

    protected override void InitSpotsVariables()
    {
        activeSpots = counterZone.ActiveSpots();
        maxActiveSpots = counterZone.maxActiveSpots;
    }

    public void UpdateAttributesAndCheckCosts(int index)
    {
        UpdateAndCheck();
        counterZone.counters[index].UpdateAttributes();
    }

    public void UnlockCounter()
    {
        UnlockSpotLogic();
        counterZone.AddQueue();
    }
}
