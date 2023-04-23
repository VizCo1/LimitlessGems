using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCubicle : QueueFlow
{
    [SerializeField] RestZone zoneManager;
    [SerializeField] float restTime = 5f;

    void OnTriggerEnter(Collider other)
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

    private void OnTriggerExit(Collider other)
    {
        placeOccupied = false;
        other.GetComponent<Worker>().ChangeTag("WorkerExit");    
    }
}
