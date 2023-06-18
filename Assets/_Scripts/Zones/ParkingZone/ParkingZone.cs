using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ZSerializer;

public class ParkingZone : Zone
{
    [NonZSerialized][SerializeField] RoadZone roadZone;
    readonly Queue<ParkingSpot> freeSpots = new();

    SpecialParkingSpot specialParkingSpot;
    [HideInInspector] public int specialCapacity;

    public List<ParkingSpot> Spots { get; private set; } = new();

    private void Awake()
    {
        MaxActiveSpots = transform.GetChild(SLOTS_INDEX).childCount;

        for (int i = 0; i < MaxActiveSpots; i++)
            Spots.Add(transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<ParkingSpot>());
    }

    void Start()
    {
        specialParkingSpot = Spots[Spots.Count - 1].GetComponent<SpecialParkingSpot>();

        for (int i = 0; i < ActiveSpots; i++)
        {
            ParkingSpot parkingSpot = transform.GetChild(SLOTS_INDEX).GetChild(i).GetComponent<ParkingSpot>();

            parkingSpot.ActivateVisuals();
            freeSpots.Enqueue(parkingSpot);
        }

        if (specialParkingSpot.gameObject.activeSelf)
        {
            specialParkingSpot.SetCapacity(specialCapacity);
            specialParkingSpot.UpdateVisuals(freeSpots.Count);
        }
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddParkingSpot();
        }
    }*/

    public void AddParkingSpot()
    {
        ParkingSpot parkingSpot;
        // valor maximo -> activeSpots = maxActiveSpots - 1
        if (ActiveSpots == MaxActiveSpots)
        {
            parkingSpot = Spots[ActiveSpots - 1];
            parkingSpot.IncreaseCapacity();

            if (!freeSpots.Contains(parkingSpot))
                freeSpots.Enqueue(parkingSpot);

            Client client = roadZone.GetActualClient();
            if (client != null)
            {
                client.GoToNextPosition();
            }

            //parkingSpot.ActivateVisuals();
            parkingSpot.UpdateVisuals(freeSpots.Count);
        }
        else
        {
            ParkingSpot newSlot = Spots[ActiveSpots++];
            newSlot.gameObject.SetActive(true);

            parkingSpot = newSlot.GetComponent<ParkingSpot>();
         
            freeSpots.Enqueue(parkingSpot);

            Client client = roadZone.GetActualClient();
            if (client != null)
            {
                client.GoToNextPosition();
            }

            parkingSpot.ActivateVisuals();
        }

        parkingSpot.UpdateVisuals(freeSpots.Count);
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

            specialParkingSpot.UpdateVisuals(freeSpots.Count);
        }
    }

    public void AddFreeSpot(ParkingSpot spot)
    {
        if (spot.Count-- == spot.Capacity())
        {
            freeSpots.Enqueue(spot);
            specialParkingSpot.UpdateVisuals(freeSpots.Count);
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
