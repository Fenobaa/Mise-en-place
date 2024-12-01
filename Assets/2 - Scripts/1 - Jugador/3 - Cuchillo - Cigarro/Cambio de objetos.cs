using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambiodeobjetos : MonoBehaviour
{
    public GameObject Cuchillo;

    public GameObject Cigarro;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.pauseTimers = true;
            Cuchillo.SetActive(false);
            Cigarro.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.pauseTimers = false;
            Cuchillo.SetActive(true);
            Cigarro.SetActive(false);
        }
    }
}
