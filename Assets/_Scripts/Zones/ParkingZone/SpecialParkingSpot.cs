using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialParkingSpot : ParkingSpot
{
    [SerializeField] Transform posT;
    [SerializeField] SpecialParkingTrigger sParkingTrigger;

    public Vector3 pos { get; private set; }

    private void Awake()
    {
        pos = posT.position;
    }

    public SpecialParkingTrigger SpecialParkingTrigger()
    {
        return sParkingTrigger;
    }
}
