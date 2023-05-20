using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    protected CanvasManager canvasManager;

    [HideInInspector] public AudioSource backButtonAudioSource;

    void Awake()
    {
        canvasManager = GetComponentInParent<CanvasManager>();
    }

    public virtual void Init()
    {
        gameObject.SetActive(true);
    }

    public virtual void End()
    {
        CanvasManager.currentLayer = null;
        gameObject.SetActive(false);
    }

    /*public virtual void AudioInit(AudioSource backButtonAudioSource)
    {
        this.backButtonAudioSource = backButtonAudioSource;
    }*/

    public void BackButtonPressed()
    {
        End();
    }
}
