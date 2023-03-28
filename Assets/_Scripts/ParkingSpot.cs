using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    [SerializeField] int capacity;
    [HideInInspector] public int Count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Client client = other.GetComponent<Client>();
            client.car.Park();
            // Dejar el coche aparcado
            
            client.GoToNextPosition();    // Mover el cliente hasta la siguiente zona
            
        }
    }

    public int Capacity()
    {
        return capacity;
    }

}
