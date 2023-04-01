using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Worker : AgentBase
{
    public bool isWorkerFree { get; private set; } = true;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void MakeGem(int gem)
    {
        
    }


    public override void GoToNextPosition()
    {
        base.GoToNextPosition();
        //isWorkerFree = false;
    }


}
