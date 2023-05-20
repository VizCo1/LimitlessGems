using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Worker : AgentBase
{
    protected override void Awake()
    {
        base.Awake();


        //initialRotation = model.rotation.eulerAngles;

        
    }

    public void StopAnimation()
    {
        animationSeq.Pause();
        //model.DORotate(new Vector3(-90, 0, -90), 0.5f, RotateMode.Fast);

        //model.rotation = Quaternion.Euler(-90, 0, 90);
    }

    public void PlayAnimation()
    {
        animationSeq.Restart();
    }
}
