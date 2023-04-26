using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Layer : MonoBehaviour
{
    protected CanvasManager canvas;

    [SerializeField] protected ObjectInLine[] objectInLines;

    protected virtual void Awake()
    {
        canvas = GetComponentInParent<CanvasManager>();
    }

    public virtual void Init()
    {
        gameObject.SetActive(true);
        CameraSystem.inGame = false;
    }

    public virtual void End()
    {
        gameObject.SetActive(false);
        CameraSystem.inGame = true;
    }

    public void BackButtonPressed()
    {
        //canvas.ChangeLayer(0);
        End();
    }
}
