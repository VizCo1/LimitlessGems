using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZSerializer;

public class CounterLayer : SpecialZoneLayer
{
    [NonZSerialized][SerializeField] CounterZone counterZone;

    protected override void InitSpotsVariables()
    {
        activeSpots = counterZone.ActiveSpots;
        maxActiveSpots = counterZone.MaxActiveSpots;       
    }

    public void UpdateAttributesAndCheckCosts(int index, ref int keyLevel, int initialKeyLevel)
    {
        UpdateAndCheck();
        if (objectInLines[index].level >= keyLevel)
        {
            keyLevel += initialKeyLevel;
            counterZone.counters[index].queueFlow.UpdateAttributes(true);
        }
        else
        {
            counterZone.counters[index].queueFlow.UpdateAttributes(false);
        }
    }

    public void UnlockCounter()
    {
        if (UnlockSpotLogic())
            counterZone.AddQueue();
    }

    public void MajorUpgrade()
    {
        if (MajorUpgradeLogic())
            counterZone.MajorUpgrade();
    }
}
