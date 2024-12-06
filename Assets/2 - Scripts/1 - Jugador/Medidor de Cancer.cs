using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MedidordeCancer : MonoBehaviour
{
    private GameManager gameManager;
    private Cambiodeobjetos Cambio;
    
    
    public Image medidorCancerStage1;
    public Image medidorCancerStage2;

    [SerializeField] private double UsoCigarro;
    private bool MuerteporCancer;
    public GameObject panelNegro;
    public AudioSource audioSource;
    public AudioClip clip;
    private bool isOnCD;
    public Animator animator;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Cambio = FindObjectOfType<Cambiodeobjetos>();
    }

    void Update()
    {
        if (GameManager.instance.finalesComprobation == false)
        {
            CigarroyMuerte();
            Pulmon();
        }
    }

    private void CigarroyMuerte()
    {
        if (MuerteporCancer && !GameManager.instance.gameOver)
        {
            GameManager.instance.gameOver = true;
            GameManager.instance.finalesComprobation = true;
            panelNegro.SetActive(true);
            audioSource.clip = clip;
            audioSource.Play();
            

        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && Cambio.cigarro.activeSelf == true)
        {
            if (isOnCD == false)
            {
                animator.SetTrigger("Stab");
                UsoCigarro += 1;
                gameManager.puntosdeAnsiedad -= 0.4;
                StartCoroutine(Cooldown());

            }
        }

    }

    IEnumerator Cooldown()
    {
        isOnCD = true;
        yield return new WaitForSeconds(12f);
        isOnCD = false;
        yield break;
    }

    private void Pulmon()
    {

        if (UsoCigarro == 3)
        {
            medidorCancerStage1.gameObject.SetActive(false);
            medidorCancerStage2.gameObject.SetActive(true);
        }
        
        InicioMuerte();

    }

    private void InicioMuerte()
    {
        if (UsoCigarro == 4)
        {
            int probabilidadMuerte = Random.Range(1, 11);
            if (probabilidadMuerte == 5)
            {
                MuerteporCancer = true;
            }
        }
        else if (UsoCigarro == 5)
        {
            int probabilidadMuerte = Random.Range(1, 11);
            if (probabilidadMuerte == 1 ||probabilidadMuerte == 5 || probabilidadMuerte == 9)
            {
                MuerteporCancer = true;
            }
        }
        else if (UsoCigarro == 6)
        {
            int probabilidadMuerte = Random.Range(1, 11);
            if (probabilidadMuerte == 1 || probabilidadMuerte == 3 || probabilidadMuerte == 5 ||
                probabilidadMuerte == 7 ||probabilidadMuerte == 9)
            {
                MuerteporCancer = true;
            }
        }
        else if (UsoCigarro == 7)
        {
            int probabilidadMuerte = Random.Range(1, 11);
            if (probabilidadMuerte == 1 || probabilidadMuerte == 2 || probabilidadMuerte == 3 ||
                 probabilidadMuerte == 5 || probabilidadMuerte == 7 || probabilidadMuerte == 9)
            {
                MuerteporCancer = true;
            }
        }
        else if (UsoCigarro == 8)
        {
            MuerteporCancer = true;
        }

    }
}
