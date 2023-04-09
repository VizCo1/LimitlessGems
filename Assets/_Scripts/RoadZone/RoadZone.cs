using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadZone : Zone
{
    [SerializeField] CarQueue carQueue;
    [SerializeField] ParkingZone parkingZone;

    public override void MoveAgentToSpot(AgentBase agent)
    {
        carQueue.Enqueue(agent);
    }

    public bool CommunicateWithParkingZone()
    {
        return parkingZone.IsParkingAvailable();
    }

    public bool IsCarQueueOccupied()
    {
        return carQueue.placeOccupied;
    }

    public Client GetActualClient()
    {
        return carQueue.actualClient;
    }
}
