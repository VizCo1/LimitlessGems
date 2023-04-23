using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Layer : MonoBehaviour
{

    [SerializeField] protected Button backButton;

    protected virtual void Awake()
    {
        //controller = GetComponentInParent<Controller>();
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
        
    }

    protected virtual void WaitAndChangeScene(bool finished) // IEnumerator
    {
        /*if (backButton != null)
            backButton.interactable = false;
        if (cameraButton != null)
            cameraButton.interactable = false;

        yield return new WaitForSeconds(1.5f);

        if (finished)
            controller.ReturnToMenuEscenarios();

        else
            controller.NextLayer(1);

        controller.IncrementarPuntuacion();*/
    }
}
