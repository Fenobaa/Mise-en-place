using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossKillEnd : MonoBehaviour
{
    public GameObject panelNegro;
    public AudioSource source;
    
    public AudioClip endEffectClip;

    public GameObject Player;
    private bool soundEffectsEnded = false;

    public GameObject brokenGlass;
    public GameObject bossIddle;
    public GameObject bossDeath;

    public Animator AnimatorLookAt;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) 
            && GameManager.instance.canKill == true)
        {
            GameManager.instance.canKill = false;
            GameManager.instance.finalesComprobation = true;
            panelNegro.SetActive(true);
            StartCoroutine(soundEfects());

        }

        if (soundEffectsEnded)
        {
            Player.SetActive(false);
            bossIddle.SetActive(false);
            bossDeath.SetActive(true);
            brokenGlass.SetActive(false);
        }
    }

    IEnumerator soundEfects()
    {
        new WaitForSeconds(1f);
        source.clip = endEffectClip;
        source.Play();

        soundEffectsEnded = true;
        yield break;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.matarJefe == true)
        {
            GameManager.instance.canKill = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (GameManager.instance.matarJefe == true)
        {
            GameManager.instance.canKill = false;
        }
    }
}
