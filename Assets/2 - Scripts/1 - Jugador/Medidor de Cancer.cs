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


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Cambio = FindObjectOfType<Cambiodeobjetos>();
    }

    void Update()
    {
        CigarroyMuerte();
        Pulmon();

    }

    private void CigarroyMuerte()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && Cambio.cigarro.activeSelf == true)
        {
            UsoCigarro += 1;
            gameManager.puntosdeAnsiedad -= 0.3;

        }
        if (MuerteporCancer)
        {
            GameManager.instance.textAdvertencias.text =
                "Los cigarros calmaron tu ansiedad, pero te llevaron a la muerte";
            Time.timeScale = 0;
        }
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
