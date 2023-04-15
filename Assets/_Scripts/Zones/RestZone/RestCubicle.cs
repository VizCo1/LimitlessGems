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

            Sequence sq = DOTween.Sequence().SetDelay(0.2f)
                .Append(circleCanvas.AppearAndFill(restTime))
                .AppendCallback(() => worker.GoToNextPosition());                
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
