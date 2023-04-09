using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Counter : QueueFlow
{
    [SerializeField] CounterZone zoneManager;
    [SerializeField] Transform exitSpot;
    float orderTime = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Client"))
        {
            Client client = other.GetComponent<Client>();
            zoneManager.DecreasePriorityOfQueue(customQueue);

            Sequence mySequence1 = DOTween.Sequence().SetDelay(0.2f).Pause();
            Sequence mySequence2 = DOTween.Sequence().Pause();

            mySequence1.Append(circleCanvas.AppearAndFill(orderTime))
                .AppendCallback(() => zoneManager.CommunicateWithWorkZone(client.WantedGem(), ref mySequence2))
                .AppendCallback(() =>
                {
                    mySequence2
                        .Append(circleCanvas.AppearAndFill(1f))
                        .AppendCallback(() => client.SetDestination(exitSpot.position))                        
                        .Append(DOVirtual.DelayedCall(1f, () => client.GemReceived()))
                        .Play();
                })
                .Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Client"))
        {
            placeOccupied = false;
        }
    }
}
