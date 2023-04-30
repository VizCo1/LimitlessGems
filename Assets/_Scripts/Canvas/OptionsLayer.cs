using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsLayer : Layer
{
    [SerializeField] Toggle music;
    [SerializeField] Toggle sound;

    bool isMusicOn;
    bool isSoundOn;

    private void Awake()
    {
        isMusicOn = music.isOn;
        isSoundOn = sound.isOn;

        SetAudio();
    }

    void SetAudio()
    {
        SetMusic();
        SetSound();
    }

    private void SetSound()
    {
        //throw new NotImplementedException();
    }

    private void SetMusic()
    {
        //throw new NotImplementedException();
    }

    public void MusicToggle()
    {
        isMusicOn = music.isOn;
    }

    public void SoundToggle()
    {
        isSoundOn = sound.isOn;
    }
}
