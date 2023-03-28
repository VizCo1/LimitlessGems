using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingZone : Zone
{
    readonly List<ParkingSpot> spots = new();
    int occupiedSpots = 0;

    void Start()
    {
        for (int i = 0; i < activeSpots; i++)
            spots.Add(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<ParkingSpot>());
    }

    public override void MoveAgentToSpot(AgentBase agent)
    {
        ParkingSpot selectedSpot = spots[occupiedSpots];

        agent.SetAgentDestination(selectedSpot.transform.position);

        if (++selectedSpot.Count == selectedSpot.Capacity())
            occupiedSpots++;

    }
}
