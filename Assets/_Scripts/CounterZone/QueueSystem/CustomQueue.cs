using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomQueue : MonoBehaviour
{
    [SerializeField] int queueSize; // the number of spots in the queue
    [SerializeField] GameObject queueSpotPrefab; // the prefab for the queue spot object
    [SerializeField] Vector3 queueDirection; // the position of the first queue spot
    [SerializeField] float offset;

    private Queue<AgentBase> queueAgents; // the actual queue of game objects
    private List<Vector3> queueSpots; // a list of all the queue spot objects

    void Start()
    {
        // initialize the queue and queue spot list
        queueAgents = new Queue<AgentBase>();
        queueSpots = new List<Vector3>();

        // create the queue spot objects and add them to the list
        float offsetIncrement = offset;
        for (int i = 0; i < queueSize; i++)
        {
            //GameObject queueSpot = Instantiate(queueSpotPrefab, transform.position + offset * queueDirection, Quaternion.identity, transform);
            queueSpots.Add(transform.position + offset * queueDirection);
            offset += offsetIncrement;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A key");
            
            
        }
    }

    // add a game object to the queue
    public void Enqueue(AgentBase obj)
    {
        // place the object at the first available spot in the queue
        int index = queueAgents.Count;
        obj.SetAgentDestination(queueSpots[index]);

        // add the object to the queue
        queueAgents.Enqueue(obj);
    }

    // remove a game object from the queue
    public AgentBase Dequeue()
    {
        // Dequeue en la cola implica DecreasePriority en la cola de prioridad
        if (queueAgents.Count > 0)
        {
            // remove the first object from the queue
            AgentBase obj = queueAgents.Dequeue();

            obj.SetAgentDestination(transform.position);

            // move all other objects forward in the queue
            for (int i = 0; i < queueAgents.Count; i++)
            {
                queueAgents.ElementAt(i).SetAgentDestination(queueSpots[i]);
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
}
