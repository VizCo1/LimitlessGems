using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomQueue : MonoBehaviour
{
    public QueueFlow queueFlow;
    [SerializeField] int queueSize; // the number of spots in the queue
    [SerializeField] GameObject queueSpotPrefab; // the prefab for the queue spot object
    [SerializeField] Vector3 queueDirection; // the position of the first queue spot
    [SerializeField] float offset;
    [SerializeField] float initialOffset;

    private Queue<AgentBase> queueAgents = new(); // the actual queue of game objects
    private List<Vector3> queueSpots = new(); // a list of all the queue spot objects

    void Start()
    {
        // create the queue spot objects and add them to the list
        queueSpots.Add(transform.position + initialOffset * queueDirection);

        float offsetIncrement = offset;
        for (int i = 1; i < queueSize; i++)
        {
            //GameObject queueSpot = Instantiate(queueSpotPrefab, transform.position + offset * queueDirection, Quaternion.identity, transform);
            queueSpots.Add(transform.position + (initialOffset + offset) * queueDirection);
            offset += offsetIncrement;
        }
    }

    // add a game object to the queue
    public void Enqueue(AgentBase obj)
    {
        // place the object at the first available spot in the queue
        int index = queueAgents.Count;
        obj.SetDestination(queueSpots[index]);

        // add the object to the queue
        queueAgents.Enqueue(obj);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(3, 3, 3));
    }

    // remove a game object from the queue
    public AgentBase Dequeue()
    {
        // Dequeue en la cola implica DecreasePriority en la cola de prioridad
        if (queueAgents.Count > 0)
        {
            // remove the first object from the queue
            AgentBase obj = queueAgents.Dequeue();

            obj.SetDestination(transform.position);
            //Debug.Log(transform.position);

            // move all other objects forward in the queue
            for (int i = 0; i < queueAgents.Count; i++)
            {
                queueAgents.ElementAt(i).SetDestination(queueSpots[i]);
            }

            // return the removed object
            return obj;
        }
        else
        {
            // return null if the queue is empty
            return null;
        }
    }

    public int Count()
    {
        return queueAgents.Count;
    }

    public int Capacity()
    {
        return queueSpots.Count;
    }
}
