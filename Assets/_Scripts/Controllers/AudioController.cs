using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioMixer m_audioMixer;

    static AudioMixer audioMixer;

    [Space]

    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] AudioClip counterSound;
    [SerializeField] AudioClip worktableSound;
    [SerializeField] AudioClip cubicleSound;

    private void Awake()
    {
        audioMixer = m_audioMixer;
    }

    public static void SetMusicAudio(bool isOn)
    {
        if (isOn)
        {
            audioMixer.SetFloat("MusicVolume", 0f);
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", -80f);
        }
    }

    public static void SetSoundsAudio(bool isOn)
    {
        if (isOn) 
        {
            audioMixer.SetFloat("SoundsVolume", 4f);
        }
        else
        {
            audioMixer.SetFloat("SoundsVolume", -80f);
        }
    }
}
