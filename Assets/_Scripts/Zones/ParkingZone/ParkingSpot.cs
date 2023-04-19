using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    [SerializeField] ParkingZone zoneManager;
    [SerializeField] int capacity;
    [HideInInspector] public int Count = 0;

    public GameObject actualClient;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") && other.gameObject == actualClient)
        {           
            Client client = other.GetComponent<Client>();
            client.ParkCar();
        }
        else if (other.CompareTag("ClientExit") && other.gameObject == actualClient)
        {
            Client client = other.GetComponent<Client>();
            client.UnParkCar();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CarExit"))
        {
            actualClient = null;
            other.GetComponent<Client>().ChangeTag("CarExit2");
            zoneManager.AddFreeSpot(this);
        }
    }

    public int Capacity()
    {
        return capacity;
    }

}
