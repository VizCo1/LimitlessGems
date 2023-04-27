using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingLayer : Layer
{
    [SerializeField] ParkingZone parkingZone;

    protected override void InitializeObjectsInLine()
    {
        /*for (int i = 0; i < counterZone.counters.Count; i++)
        {
            objectInLines[i].transform.parent.gameObject.SetActive(false);
            objectInLines[i].index = i;
        }

        for (int i = 0; i < counterZone.ActiveSpots(); i++)
        {
            objectInLines[i].transform.parent.gameObject.SetActive(true);
        }*/
    }
}
