using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ParkingZone : Zone
{
    [SerializeField] RoadZone roadZone;
    readonly Queue<ParkingSpot> freeSpots = new();

    SpecialParkingSpot specialParkingSpot;
    public List<ParkingSpot> spots { get; private set; } = new();

    private void Awake()
    {
        maxActiveSpots = transform.GetChild(SLOTS_INDEX).childCount;

        for (int i = 0; i < maxActiveSpots; i++)
            spots.Add(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<ParkingSpot>());
    }

    void Start()
    {
        for (int i = 0; i < activeSpots; i++)
            freeSpots.Enqueue(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<ParkingSpot>());

        specialParkingSpot = spots[spots.Count - 1].GetComponent<SpecialParkingSpot>();
    }

    public void AddParkingSpot()
    {
        ParkingSpot parkingSpot;
        // valor maximo -> activeSpots = maxActiveSpots - 1
        if (activeSpots == maxActiveSpots)
        {
            parkingSpot = spots[activeSpots - 1];
            parkingSpot.IncreaseCapacity();

            if (!freeSpots.Contains(parkingSpot))
                freeSpots.Enqueue(parkingSpot);

            Client client = roadZone.GetActualClient();
            if (client != null)
            {
                client.GoToNextPosition();
            }          
        }
        else
        {
            ParkingSpot newSlot = spots[activeSpots++];
            newSlot.gameObject.SetActive(true);

            parkingSpot = newSlot.GetComponent<ParkingSpot>();
         
            freeSpots.Enqueue(parkingSpot);

            Client client = roadZone.GetActualClient();
            if (client != null)
            {
                client.GoToNextPosition();
            }
        }
        parkingSpot.ActivateVisuals();
    }

    public override void MoveAgentToSpot(AgentBase agent)
    {
        if (freeSpots.Count != 0)
        {
            ParkingSpot spot = freeSpots.Peek();

            if (++spot.Count == spot.Capacity())
            {
                freeSpots.Dequeue();
            }
            else
            {
                freeSpots.Dequeue();
                freeSpots.Enqueue(spot);
            }

            spot.actualClients.Add(agent.gameObject);

            if (spot.isSpecial)
            {
                agent.SetDestination(specialParkingSpot.pos);
                specialParkingSpot.SpecialParkingTrigger().clients.Enqueue(agent.gameObject);
            }
            else
            {
                agent.SetDestination(spot.transform.position);
            }
        }
    }

    public void AddFreeSpot(ParkingSpot spot)
    {
        if (spot.Count-- == spot.Capacity())
        {
            freeSpots.Enqueue(spot);
        }

        // Communicate with RoadZone
        Client client = roadZone.GetActualClient();
        if (client != null)
        {
            client.GoToNextPosition();
        }    
    }

    public bool IsParkingAvailable()
    {
        return freeSpots.Count != 0;
    }
}
