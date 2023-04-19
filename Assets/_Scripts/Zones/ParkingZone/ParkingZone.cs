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
        // Si hace falta hacer Dequeue hay que hacerlo justo cuando el coche sale de CarQueue!!!!! TODO
        // O MOVER EL KEY SPOT MAS CERCA BOBO
        if (freeSpots.Count != 0)
        {
            ParkingSpot spot = freeSpots.Peek();
            if (++spot.Count == spot.Capacity())
                freeSpots.Dequeue();
            spot.actualClient = agent.gameObject;
            agent.SetDestination(spot.transform.position);
        }
    }

    public void AddFreeSpot(ParkingSpot spot)
    {
        if (spot.Count-- == spot.Capacity())
        {
            freeSpots.Enqueue(spot);
        }

        Debug.Log(spot.Count);

        // Communicate with RoadZone
        Client client = roadZone.GetActualClient();
        if (client != null)
            client.GoToNextPosition();
        
    }

    public bool IsParkingAvailable()
    {
        return freeSpots.Count != 0;
    }
}
