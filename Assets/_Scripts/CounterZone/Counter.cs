using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Counter : QueueFlow
{
    [SerializeField] CounterZone zoneManager;
    [SerializeField] Transform exitSpot;
    [SerializeField] float orderTime = 5f;

    Client actualClient;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Client"))
        {
            actualClient = other.GetComponent<Client>();
            zoneManager.DecreasePriorityOfQueue(customQueue);

            Sequence sequence = DOTween.Sequence().SetDelay(0.2f).Pause();

            sequence.Append(circleCanvas.AppearAndFill(orderTime)); // Client orders the gem

            if (zoneManager.CommunicateWithWorkZone(actualClient.WantedGem(), this)) // If gem is available, then give gem. Else gem request saved 
            {
                // Give gem sequence
                sequence.Append(ReceivingGemSequence());
            }

            sequence.Play();
        }
    }

    public Sequence ReceivingGemSequence()
    {
        return DOTween.Sequence()
            .Append(circleCanvas.AppearAndFill(1f))
            .AppendCallback(() => actualClient.SetDestination(exitSpot.position))
            .Append(DOVirtual.DelayedCall(0.5f, () => actualClient.GemReceived()));
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Client"))
        {
            placeOccupied = false;
        }
    }
}
