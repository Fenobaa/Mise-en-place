using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;

    public AudioMixer mixer;
    public AudioClip menu, inside, outside;
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
    public void Start()
    {
        mixer.SetFloat("ExposedBGM1", 0f);
        mixer.SetFloat("ExposedBGM2", -80f);
    }
    public void Outside()
    {
        mixer.SetFloat("ExposedBGM1", 0f);
        mixer.SetFloat("ExposedBGM2", -80f);
    }

    public void Inside()
    {
        mixer.SetFloat("ExposedBGM1", -80f);
        mixer.SetFloat("ExposedBGM2", 0f);
    }
}
