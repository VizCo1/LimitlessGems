using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Layer : MonoBehaviour
{
    protected CanvasManager canvas;

    protected virtual void Awake()
    {
        canvas = GetComponentInParent<CanvasManager>();
    }

    public virtual void Init()
    {
        gameObject.SetActive(true);
    }

    public virtual void End()
    {
        gameObject.SetActive(false);
    }

    public void BackButtonPressed()
    {
        //canvas.ChangeLayer(0);
        End();
    }
}
