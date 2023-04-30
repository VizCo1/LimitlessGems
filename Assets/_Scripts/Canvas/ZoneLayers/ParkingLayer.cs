using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingLayer : ZoneLayer
{
    [SerializeField] ParkingZone parkingZone;

    protected override void InitSpotsVariables()
    {
        activeSpots = 2;
        maxActiveSpots = 2;
    }

    public void UpdateAttributesAndCheckCosts(bool type) //, ref int keyLevel, int initialKeyLevel)
    {
        UpdateAndCheck();

        if (type)
            parkingZone.AddParkingSpot(); // Capacity
        else
            GameController.CreateSpawnSequence(-1); // Publicity

    }
}
