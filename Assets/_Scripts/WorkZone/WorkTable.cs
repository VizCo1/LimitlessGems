using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTable : MonoBehaviour
{
    [SerializeField] CircleCanvas circleCanvas;
    [SerializeField] Worker worker;

    float makeTime = 5f;

    public bool IsWorkerFree()
    {
        return worker.isWorkerFree;
    }

    public Worker CreateGem(ref Sequence sequence)
    {
        sequence.Append(circleCanvas.AppearAndFill(makeTime));
        sequence.AppendCallback(() => worker.GoToNextPosition());

        return worker;
        Debug.Log("A");
    }


}
