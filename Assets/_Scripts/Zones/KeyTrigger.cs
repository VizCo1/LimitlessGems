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
                Vector3 carPos = client.GetCar().transform.position;
                client.SetDestination(new Vector3(carPos.x, other.transform.position.y, carPos.z));
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
