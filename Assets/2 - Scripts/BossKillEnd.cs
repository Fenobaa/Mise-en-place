using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
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
    public GameObject canvas;
    
    
    public Camera cam;
    public GameObject cameraCinemachine;
    private Animator camAnimator;

    private void Start()
    {
        camAnimator = cameraCinemachine.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) 
            && GameManager.instance.canKill == true)
        {
            canvas.SetActive(false);
            GameManager.instance.canKill = false;
            GameManager.instance.finalesComprobation = true;
            panelNegro.SetActive(true);
            StartCoroutine(soundEfects());

        }

        if (soundEffectsEnded)
        {
            cameraCinemachine.SetActive(true);
            cam.enabled = false;

            Player.SetActive(false);
            bossIddle.SetActive(false);
            bossDeath.SetActive(true);
            brokenGlass.SetActive(false);
            panelNegro.SetActive(false);
            camAnimator.SetBool("GoodEnding", true);
            
        }
    }

    IEnumerator soundEfects()
    {
        yield return new WaitForSeconds(1f);
        source.clip = endEffectClip;
        source.Play();
        yield return new WaitForSeconds(11f);
        soundEffectsEnded = true;
        yield break;
    }

    IEnumerator waitforChange()
    {
        yield return new WaitForSeconds(25f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("si");
            if (GameManager.instance.matarJefe == true)
            {
                GameManager.instance.textAdvertencias.text = "Presiona click izquierdo para asesinar";
                GameManager.instance.canKill = true;
            }
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")
           && GameManager.instance.matarJefe == true)
        {

            GameManager.instance.canKill = false;
        }
    }
}
