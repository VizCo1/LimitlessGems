using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialParkingTrigger : MonoBehaviour
{
    [HideInInspector] public Queue<GameObject> clients = new();

    private void OnTriggerEnter(Collider other)
    {
        if (clients.Count == 0)
            return;

        if (other.gameObject == clients.Peek())
        {
            Client client = other.GetComponent<Client>();
            client.SetDestination(transform.parent.position);
            clients.Dequeue();
        }
    }
}
