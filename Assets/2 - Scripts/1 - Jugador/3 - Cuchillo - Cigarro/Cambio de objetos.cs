using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambiodeobjetos : MonoBehaviour
{
    public GameObject cuchillo;

    public GameObject cigarro;

    public GameObject encendedor;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.pauseTimers = true;
            cuchillo.SetActive(false);
            cigarro.SetActive(true);
            encendedor.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.pauseTimers = false;
            cigarro.SetActive(false);  
            encendedor.SetActive(false);
            cuchillo.SetActive(true);

        }
    }
}
