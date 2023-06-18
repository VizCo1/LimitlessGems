using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using ZSerializer;

public class OptionsLayer : Layer
{
    [NonZSerialized][SerializeField] Toggle music;
    [NonZSerialized][SerializeField] Toggle sound;

    [HideInInspector][SerializeField] bool isMusicOn = true;
    [HideInInspector][SerializeField] bool isSoundOn = true;

    public override void OnPostLoad()
    {
        music.isOn = isMusicOn;
        sound.isOn = isSoundOn;
        MusicToggle();
        SoundToggle();
    }

    private void SetSound()
    {
        AudioController.SetSoundsAudio(sound.isOn);
    }

    private void SetMusic()
    {
        AudioController.SetMusicAudio(music.isOn);
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

    //public void LoadGame() => ZSerialize.LoadScene();

    public void SaveGame() => ZSerialize.SaveScene();
}
