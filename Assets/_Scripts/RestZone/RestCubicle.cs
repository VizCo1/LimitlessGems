using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCubicle : QueueFlow
{
    [SerializeField] RestZone zoneManager;
    float restTime = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Worker"))
        {
            Worker worker = other.GetComponent<Worker>();
            zoneManager.DecreasePriorityOfQueue(customQueue);

            circleCanvas.AppearAndFill(restTime).SetDelay(0.2f).Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Worker"))
        {
            placeOccupied = false;
        }
    }
}
