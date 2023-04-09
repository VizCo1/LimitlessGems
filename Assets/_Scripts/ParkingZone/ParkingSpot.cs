using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    [SerializeField] ParkingZone zoneManager;
    [SerializeField] int capacity;
    [HideInInspector] public int Count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {           
            Client client = other.GetComponent<Client>();
            client.ParkCar();
        }
        else if (other.CompareTag("ClientExit"))
        {
            Client client = other.GetComponent<Client>();
            client.UnParkCar();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            zoneManager.AddFreeSpot(this);
        }
    }

    public int Capacity()
    {
        return capacity;
    }

}
