using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class Layer : PersistentMonoBehaviour
{
    protected CanvasManager canvasManager;

    [HideInInspector] [NonZSerialized] public AudioSource backButtonAudioSource;

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
