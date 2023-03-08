using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBase : MonoBehaviour
{
    protected const string KEY_POSITION = "keyPos";

    [SerializeField] protected Transform[] positions;
    protected int index = 0;

    protected NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected void GoToNextPosition()
    {
        if (index < positions.Length)
            agent.destination = positions[index++].position;
        else
            Debug.Log("Index out of range");
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(KEY_POSITION))
        {
            Debug.Log("Trigger");
            ZoneManager zone = other.GetComponentInParent<ZoneManager>();
            Vector3 bestPosition = zone.BestPosition();

            agent.destination = bestPosition;

            // Pedirle al ZoneManager la zona del parking, counter, o rest zone a la que ir
            // Si está todo lleno esperar hasta que haya hueco
            // Igual es mejor que la zona le proporcione la posición al jugador, podría tener una cola cada zona que representa cada cola
            //GoToNextPosition();
        }
    }
}
