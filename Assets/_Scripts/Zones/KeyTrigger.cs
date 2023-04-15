using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    [SerializeField] Zone zone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Client") || other.CompareTag("Worker") || other.CompareTag("Car"))
        {
            zone.MoveAgentToSpot(other.GetComponent<AgentBase>());
        }
        else if (other.CompareTag("ClientExit"))
        {
            Client client = other.GetComponent<Client>();
            client.SetDestination(client.GetCar().transform.position);
        }
        else if (other.CompareTag("CarExit"))
        {
            other.GetComponent<AgentBase>().GoToNextPosition();
        }
    }
}
