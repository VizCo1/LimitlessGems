using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarQueue : MonoBehaviour
{
    CustomQueue customQueue;
    [SerializeField] RoadZone zoneManager;
    [SerializeField] Transform exitSpot;
    public bool placeOccupied { get; private set; } = false;

    [HideInInspector] public Client actualClient;

    private void Awake()
    {
        customQueue = GetComponent<CustomQueue>();
    }

    private void Update()
    {
        if (customQueue.Count() != 0 && !placeOccupied)
        {
            placeOccupied = true;
            customQueue.Dequeue();
        }
    }

    public void Enqueue(AgentBase client)
    {
        customQueue.Enqueue(client);
    }

    public void CarToParking()
    {
        customQueue.Dequeue();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            if (zoneManager.CommunicateWithParkingZone()) // Parking is available
            {
                other.GetComponent<Client>().GoToNextPosition();
            }
            else
            {
                actualClient = other.GetComponent<Client>();
            }
        }
    }

    public bool IsFull()
    {
        return customQueue.Count() >= customQueue.Capacity();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            placeOccupied = false;
        }
    }
}
