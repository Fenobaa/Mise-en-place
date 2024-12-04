using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    public AudioMixer Mixer;

    public Slider masterSlider, bgmSlider, sfxSlider;

    void Update()
    {
        Mixer.SetFloat("ExposedMaster", masterSlider.value);
        Mixer.SetFloat("ExposedBGM", bgmSlider.value);
        Mixer.SetFloat("ExposedSFX", sfxSlider.value);
    }
}
