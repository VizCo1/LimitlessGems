using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingZone : Zone
{
    [SerializeField] RoadZone roadZone;
    readonly Queue<ParkingSpot> freeSpots = new();
    Vector3 parkingLocation;

    void Start()
    {
        for (int i = 0; i < activeSpots; i++)
            freeSpots.Enqueue(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<ParkingSpot>());
    }

    public override void MoveAgentToSpot(AgentBase agent)
    {
        agent.SetDestination(parkingLocation);
        if (freeSpots.Count != 0)
        {
            ParkingSpot spot = freeSpots.Dequeue();
            agent.SetDestination(spot.transform.position);
        }
    }

    public void AddFreeSpot(ParkingSpot spot)
    {
        freeSpots.Enqueue(spot);
        // Communicate with RoadZone // Esta mal ??
        if (roadZone.IsCarQueueOccupied())
        {
            parkingLocation = freeSpots.Dequeue().transform.position;
            roadZone.GetActualClient().GoToNextPosition();
        }
    }

    public bool IsParkingAvailable()
    {
        if (freeSpots.Count != 0)
        {
            parkingLocation = freeSpots.Dequeue().transform.position;
            return true;
        }

        return false;
    }
}
