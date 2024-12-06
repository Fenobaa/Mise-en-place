using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    public AudioMixer Mixer;

    public Slider masterSlider, bgmSlider, sfxSlider;

    //void Update()
    //{
    //    Mixer.SetFloat("ExposedMaster", masterSlider.value);
    //    Mixer.SetFloat("ExposedBGM", bgmSlider.value);
    //    Mixer.SetFloat("ExposedSFX", sfxSlider.value);
    //}

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

}
