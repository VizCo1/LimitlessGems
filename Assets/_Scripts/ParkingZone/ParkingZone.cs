using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingZone : Zone
{
    [SerializeField] RoadZone roadZone;
    readonly Queue<ParkingSpot> freeSpots = new();

    void Start()
    {
        for (int i = 0; i < activeSpots; i++)
            freeSpots.Enqueue(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<ParkingSpot>());
    }

    public override void MoveAgentToSpot(AgentBase agent)
    {
        if (freeSpots.Count != 0)
        {
            ParkingSpot spot = freeSpots.Peek();
            if (++spot.Count == spot.Capacity())
                freeSpots.Dequeue();
            agent.SetDestination(spot.transform.position);
        }
    }

    public void AddFreeSpot(ParkingSpot spot)
    {
        if (spot.Count-- == spot.Capacity())
        {
            freeSpots.Enqueue(spot);
        }

        // Communicate with RoadZone
        if (roadZone.IsCarQueueOccupied())
        {
            roadZone.GetActualClient().GoToNextPosition();
        }
    }

    public bool IsParkingAvailable()
    {
        if (freeSpots.Count != 0)
        {
            return true;
        }

        return false;
    }
}
