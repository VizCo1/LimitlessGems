using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Client : MonoBehaviour
{
    const string GO_TO_TRANSFORM = "GoToTransform";
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform goToTransform;
    Vector3 goToPosition;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        goToPosition = goToTransform.position;
        agent.destination = goToPosition;
    }

    void Update()
    {
        
    }

    void ChooseGem()
    {

    }

    void WaitInQueue()
    {
        // La zona Counter sabe cual es el counter más optimo por lo que se puede elegir directamente el counter al que ir.
        //agent.destination = counterZone.BestCounter();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GO_TO_TRANSFORM))
        {
            Debug.Log("1");
            WaitInQueue();
            // Buscar counter más vacío, si no pues aleatorio (?)
        }
    }
}
