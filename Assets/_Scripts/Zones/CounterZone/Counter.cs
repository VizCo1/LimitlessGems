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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Client"))
        {
            actualClient = other.GetComponent<Client>();
            zoneManager.DecreasePriorityOfQueue(customQueue);

            Sequence sequence = DOTween.Sequence().SetDelay(0.2f).Pause();

            sequence.Append(circleCanvas.AppearAndFill(orderTime)); // Client orders the gem

            if (zoneManager.CommunicateWithWorkZone(((int)actualClient.WantedGem()), this)) // If gem is available, then give gem. Else gem request saved 
            {
                // Give gem sequence
                Debug.Log("AAAAAA");
                sequence.Append(CreateReceivingGemSequence());
            }

            sequence.Play();
        }
    }

    public Sequence CreateReceivingGemSequence()
    {
         return DOTween.Sequence()
            .Append(circleCanvas.AppearAndFill(1f))
            .AppendCallback(() => actualClient.SetDestination(exitSpot.position))
            .Append(DOVirtual.DelayedCall(0.5f, () => actualClient.GemReceived()));
    }
}
