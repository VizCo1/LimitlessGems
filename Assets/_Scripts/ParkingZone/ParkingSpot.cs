using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    [SerializeField] int capacity;
    [HideInInspector] public int Count = 0;
    //Client client;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {           
            Client client = other.GetComponent<Client>();
            /*client.GetCar().Park();
            client.GoToNextPosition();
            */
            client.GetCar().Park();
            DOVirtual.DelayedCall(1, () => client.ChangeTag("Client"));
            client.GoToNextPosition();
        }
        else if (other.CompareTag("ClientExit"))
        {
            Client client = other.GetComponent<Client>();
            client.GetCar().UnPark();
            client.GoToNextPosition();
            /*
            client.GetCar().UnPark();
            client.GoToNextPosition();
            Debug.Log("Cliente en parkingSlot");
            */
        }
    }

    public int Capacity()
    {
        return capacity;
    }

}
