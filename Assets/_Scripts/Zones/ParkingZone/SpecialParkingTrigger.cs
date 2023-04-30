using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialParkingTrigger : MonoBehaviour
{
    [HideInInspector] public Client client;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == client.gameObject)
        {
            client.SetDestination(transform.parent.position);
            client = null;
        }
    }
}
