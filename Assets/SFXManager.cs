using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioClip dingCook, dingBurn, drawKnife, goodEnding, kill1, kill2, kill3, sizzle, stabCeramic, stabMetal;
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
    public void Kill()
    {

    }
}
