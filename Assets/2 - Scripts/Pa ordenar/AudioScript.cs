using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    public static AudioScript Instance;

    public AudioMixer Mixer;

    public Slider masterSlider, bgmSlider, sfxSlider;

    public AudioSource sfxSource;
    public AudioSource bgmSource1;
    public AudioSource bgmSource2;
    //void Update()
    //{
    //    Mixer.SetFloat("ExposedMaster", masterSlider.value);
    //    Mixer.SetFloat("ExposedBGM", bgmSlider.value);
    //    Mixer.SetFloat("ExposedSFX", sfxSlider.value);
    //}
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetBGMVolume()
    {
        float volume = bgmSlider.value;
        Mixer.SetFloat("ExposedBGM", volume);
    }

    public void SetMMasterVolume()
    {
        float volume = masterSlider.value;
        Mixer.SetFloat("ExposedMaster", volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        Mixer.SetFloat("ExposedSFX", volume);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void ReplaceSFXClip(AudioClip newClip)
    {
        sfxSource.clip = newClip;
    }

}
