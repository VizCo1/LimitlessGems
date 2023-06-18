using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class RestLayer : SpecialZoneLayer
{
    [NonZSerialized][SerializeField] RestZone restZone;

    protected override void InitSpotsVariables()
    {
        activeSpots = restZone.ActiveSpots;
        maxActiveSpots = restZone.MaxActiveSpots;
    }

    public void UpdateAttributesAndCheckCosts(int index, ref int keyLevel, int initialKeyLevel)
    {
        UpdateAndCheck();
        if (objectInLines[index].level >= keyLevel)
        {
            keyLevel += initialKeyLevel;
            restZone.cubicles[index].queueFlow.UpdateAttributes(true);
        }
        else
        {
            restZone.cubicles[index].queueFlow.UpdateAttributes(false);
        }
    }

    public void UnlockRestCubicle()
    {
        if (UnlockSpotLogic())
            restZone.AddQueue();
    }

    public void MajorUpgrade()
    {
        if (MajorUpgradeLogic())       
            restZone.MajorUpgrade();        
    }
}
