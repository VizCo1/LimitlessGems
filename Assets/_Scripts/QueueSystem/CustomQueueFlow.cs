using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomQueueFlow : MonoBehaviour
{

    [SerializeField] QueuesZoneManager zoneManager;
    CustomQueue customQueue;

    bool counterOccupied = false;

    private void Awake()
    {
        customQueue = GetComponent<CustomQueue>();
        //customQueue.Dequeue();
    }


    private void Update()
    {
        if (customQueue.Count() != 0 && !counterOccupied)
        {
            counterOccupied = true;
            customQueue.Dequeue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Client client = other.GetComponent<Client>();
            zoneManager.DecreasePriorityOfQueue(customQueue);
            client.AskForGem();
            // Cuando recibe la gema se va a su coche.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            counterOccupied = false;
        }
    }
}
