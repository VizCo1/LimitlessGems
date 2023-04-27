using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestLayer : Layer
{
    [SerializeField] RestZone restZone;

    protected override void InitSpotsVariables()
    {
        activeSpots = restZone.ActiveSpots();
        maxActiveSpots = restZone.maxActiveSpots;
    }

    public void UpdateAttributesAndCheckCosts(int index)
    {
        UpdateAndCheck();
        restZone.cubicles[index].UpdateAttributes();
    }

    public void UnlockRestCubicle()
    {
        UnlockSpotLogic();
        restZone.AddQueue();
    }
}
