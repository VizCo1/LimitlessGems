using DG.Tweening;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTable : MonoBehaviour
{
    [SerializeField] WorkZone zoneManager;
    [SerializeField] CircleCanvas circleCanvas;
    [SerializeField] Worker worker;

    [SerializeField] float makeTime = 5f;

    /*private void Start()
    {
        CreateGemSequence();
    }*/

    Sequence CreateGemSequence()
    {
        return DOTween.Sequence()
            .Append(circleCanvas.AppearAndFill(makeTime))
            .AppendCallback(() => worker.GoToNextPosition())
            .SetDelay(0.2f);
    }

    void CreateGem()
    {
        int gem = Random.Range(0, 3);
        CreateGemSequence()
            .OnComplete(() =>
            {
                if (zoneManager.AnyRequestForThisGem(gem))
                {
                    
                    zoneManager.GetPendingRequestsOf(gem).Dequeue().counter.CreateReceivingGemSequence();
                }
                else
                {
                    zoneManager.AddGemToInventory(gem);
                }
            })
            .Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == worker.gameObject)
        {
            other.transform.DOLookAt(transform.position, 1f, AxisConstraint.Y);
            worker.ChangeTag("Worker");

            if (zoneManager.CheckForPendingRequests()) // There are pending requests
            {
                CreateGemSequence().Append(zoneManager.GetRandomPendingRequest().counter.CreateReceivingGemSequence());
            }
            else // No pending requests
            {
                CreateGem();
            }
        }
    }
}
