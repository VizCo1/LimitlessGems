using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Layer : MonoBehaviour
{
    CanvasManager canvasManager;

    [SerializeField] protected ObjectInLine[] objectInLines;

    protected virtual void Awake()
    {
        canvasManager = GetComponentInParent<CanvasManager>();
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

    protected virtual void InitializeObjectsInLine()
    {

    }

    protected void CheckButtons()
    {
        canvasManager.CheckAllButtons();
    }

    public void BackButtonPressed()
    {
        End();
    }

    public ObjectInLine[] GetObjectInLines()
    {
        return objectInLines;
    }
}
