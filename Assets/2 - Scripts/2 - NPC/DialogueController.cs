using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;


[System.Serializable]
public class Dialogue
{
    public AudioClip dialogueSound;

}
public class DialogueController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private List<Dialogue> dialogue;
    private int dialogueCounter;
    private bool firstInteraction;
    private bool coroutineRunning;
    
    // Multi-press detection
    private int pressCount;
    private float multiPressWindow = 0.6f; // Tiempo en segundos para detectar múltiples pulsaciones
    private float lastPressTime;

    
    
    //Dialogue Detection
    private bool PlayerIsOnArea;
    private int RandomIndex;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!PlayerIsOnArea || GameManager.instance.expulsadoPega) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (this.gameObject.tag == "Boss")
            {
                float currentTime = Time.time;
             
                // Verificar si la pulsación está dentro de la ventana de tiempo
                if (currentTime - lastPressTime > multiPressWindow)
                {
                    pressCount = 0;
                }

                pressCount++;
                lastPressTime = currentTime;

                // Si se presionó "E" varias veces rápidamente
                if (pressCount >= 7)
                {
                    Debug.Log("Tecla presionada 7 veces rápidamente!");
                    MultiPressAudio();
                    pressCount = 0; // Reinicia el contador
                }
            }
            DialogueTimeController();

        }

        if (!coroutineRunning && !firstInteraction)
        {
            coroutineRunning = true;
            StartCoroutine(SecondsCounter());
        }
    }

    IEnumerator SecondsCounter()
    {
        while (true) // Bucle infinito
        {
            yield return new WaitForSeconds(60); // Espera 60 segundos
            dialogueCounter++; // Incrementa el contador
        }
    }
    public void DialogueTimeController()
    {
        if (firstInteraction 
            && !GameManager.instance.expulsadoPega
            && !GameManager.instance.matarJefe )
        {
            firstInteraction = false;
            audioSource.clip = dialogue[0].dialogueSound;

            audioSource.Play();
        }
        else if (!firstInteraction &&
                 !GameManager.instance.expulsadoPega
                 && !GameManager.instance.matarJefe )
        {
            audioSource.clip = dialogue[1].dialogueSound;

            audioSource.Play();
        }
        else if (dialogueCounter == 3 &&
                 !GameManager.instance.expulsadoPega
                 && !GameManager.instance.matarJefe )
        {
            audioSource.clip = dialogue[2].dialogueSound;

            audioSource.Play();   
        }
        else if (dialogueCounter == 5 &&
                 !GameManager.instance.expulsadoPega
                 && !GameManager.instance.matarJefe )
        {
            audioSource.clip = dialogue[3].dialogueSound;

            audioSource.Play();
        }
        else if (dialogueCounter == 9 &&
                 !GameManager.instance.expulsadoPega 
                 && !GameManager.instance.matarJefe )
        {
            audioSource.clip = dialogue[4].dialogueSound;

            audioSource.Play();
        }
        else if (GameManager.instance.matarJefe)
        {
            audioSource.clip = dialogue[5].dialogueSound;
        }
    }
    
    private void MultiPressAudio()
    {
        GameManager.instance.expulsadoPega = true;
        GameManager.instance.finalesComprobation = true;
        // Acción especial cuando se detectan múltiples pulsaciones rápidas
        Debug.Log("Ejecutando acción especial por múltiples pulsaciones rápidas.");
        audioSource.clip = dialogue[5].dialogueSound;
        audioSource.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsOnArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            PlayerIsOnArea = false;
        }
    }
}




