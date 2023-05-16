using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsLayer : Layer
{
    [SerializeField] Toggle music;
    [SerializeField] Toggle sound;

    bool isMusicOn;
    bool isSoundOn;

    private void Awake()
    {
        MusicToggle();
        SoundToggle();
    }

    private void SetSound()
    {
        AudioController.SetSoundsAudio(isSoundOn);
    }

    private void SetMusic()
    {
        AudioController.SetMusicAudio(isMusicOn);
    }

    public void MusicToggle()
    {
        isMusicOn = music.isOn;
        SetMusic();
    }

    public void SoundToggle()
    {
        isSoundOn = sound.isOn;
        SetSound();
    }
}
