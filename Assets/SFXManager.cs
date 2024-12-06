using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioClip dingCook, dingBurn, drawKnife, goodEnding, kill, stabCeramic;
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
        AudioScript.Instance.ReplaceSFXClip(kill);
        AudioScript.Instance.PlaySFX(kill);
    }

    public void DingCook()
    {
        AudioScript.Instance.ReplaceSFXClip(dingCook);
        AudioScript.Instance.PlaySFX(dingCook);
    }
    public void DingBurn()
    {
        AudioScript.Instance.ReplaceSFXClip(dingBurn);
        AudioScript.Instance.PlaySFX(dingBurn);
    }
    public void DrawKnife()
    {
        AudioScript.Instance.ReplaceSFXClip(drawKnife);
        AudioScript.Instance.PlaySFX(drawKnife);
    }
    public void StabCeramic()
    {
        AudioScript.Instance.ReplaceSFXClip(stabCeramic);
        AudioScript.Instance.PlaySFX(stabCeramic);
    }
    public void GoodEnding()
    {
        AudioScript.Instance.ReplaceSFXClip(goodEnding);
        AudioScript.Instance.PlaySFX(goodEnding);
    }
}
