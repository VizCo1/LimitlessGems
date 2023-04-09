using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarQueue : MonoBehaviour
{
    CustomQueue customQueue;
    [SerializeField] RoadZone zoneManager;
    [SerializeField] Transform exitSpot;
    public bool placeOccupied { get; private set; } = false;

    public Client actualClient { get; private set; }

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
                Debug.Log("P");
                other.GetComponent<Client>().GoToNextPosition();
            }
            else
            {
                Debug.Log("not P");
                // Esta mal ??
                actualClient = other.GetComponent<Client>();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            placeOccupied = false;
        }
    }
}
