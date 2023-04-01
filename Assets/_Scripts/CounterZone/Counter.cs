using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Counter : MonoBehaviour
{
    [SerializeField] CounterZone zoneManager;
    [SerializeField] CircleCanvas circleCanvas;
    CustomQueue customQueue;

    float orderTime = 5f;
    bool counterOccupied = false;

    private void Awake()
    {
        customQueue = GetComponent<CustomQueue>();
        //customQueue.Dequeue();
    }


    private void Update()
    {
        if (customQueue.Count() != 0 && !counterOccupied)
        {
            counterOccupied = true;
            customQueue.Dequeue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Client client = other.GetComponent<Client>();
            zoneManager.DecreasePriorityOfQueue(customQueue);

            Sequence mySequence1 = DOTween.Sequence().Pause();
            Sequence mySequence2 = DOTween.Sequence().Pause();

            mySequence1.Append(circleCanvas.AppearAndFill(orderTime))
                .AppendCallback(() => zoneManager.CommunicateWithWorkZone(client.WantedGem(), ref mySequence2))
                .AppendCallback(() => 
                {
                    mySequence2.Append(circleCanvas.AppearAndFill(1f))
                        .AppendCallback(() => client.ReceiveGem())
                    .Play(); 
                })
                .Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            counterOccupied = false;
        }
    }
}
