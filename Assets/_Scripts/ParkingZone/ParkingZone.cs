using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingZone : Zone
{
    Queue<ParkingSpot> freeSpots = new();

    void Start()
    {
        for (int i = 0; i < activeSpots; i++)
            freeSpots.Enqueue(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<ParkingSpot>());
    }

    public override void MoveAgentToSpot(AgentBase agent)
    {
        if (freeSpots.Count != 0)
        {
            ParkingSpot spot = freeSpots.Dequeue();
            agent.SetDestination(spot.transform.position);
        }
    }

    public void AddFreeSpot(ParkingSpot spot)
    {
        freeSpots.Enqueue(spot);
    }
}
