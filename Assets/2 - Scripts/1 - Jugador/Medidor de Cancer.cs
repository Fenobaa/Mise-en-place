using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (Input.GetKeyDown(KeyCode.Mouse1) && Cambio.Cigarro.activeSelf == true)
        {
            UsoCigarro += 1;
            gameManager.puntosdeAnsiedad -= 0.3;

        }
        

        if (UsoCigarro == 5)
        {
            MuerteporCancer = true;
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
        if (UsoCigarro == 1)
        {
            medidorCancerStage1.gameObject.SetActive(false);
            medidorCancerStage2.gameObject.SetActive(true);
        }
        else if (UsoCigarro == 2)
        {
        }
        else if (UsoCigarro == 3)
        {
        }
    }
}
