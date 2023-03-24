using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Dejar el coche aparcado
            other.GetComponent<Client>().GoToNextPosition();    // Mover el cliente hasta la siguiente zona

        }
    }
}
