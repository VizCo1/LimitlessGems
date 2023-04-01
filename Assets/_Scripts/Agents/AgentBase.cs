using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBase : MonoBehaviour
{
    [SerializeField] protected Transform[] positions;
    protected int index = 0;

    protected NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

   public void SetAgentDestination(Vector3 pos)
    {
        agent.destination = pos;
    }

    public virtual void GoToNextPosition()
    {
        if (index < positions.Length)
            agent.destination = positions[index++].position;
        else
            index = 0;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag(COUNTER_QUEUE_TAG))
        {
            //other.GetComponent<CustomQueue>().Dequeue();
            //other.GetComponentInParent<ZoneManager>().

        }*/
    }
}
