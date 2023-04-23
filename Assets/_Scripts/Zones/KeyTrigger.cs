using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    [SerializeField] Zone zone;

    private void OnTriggerEnter(Collider other)
    {
        if (zone == null)
        {
            if (other.CompareTag("ClientExit"))
            {
                Client client = other.GetComponent<Client>();
                client.SetDestination(client.GetCar().transform.position);
            }
            else
            {
                other.GetComponent<AgentBase>().GoToNextPosition();
            }
        } 
        else if (other.CompareTag("Client") || other.CompareTag("Worker") || other.CompareTag("Car"))
        {
            zone.MoveAgentToSpot(other.GetComponent<AgentBase>());
        }
    }
}
