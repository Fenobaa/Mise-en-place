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
    public string dialogueText;
    public AudioClip dialogueSound;

}
public class DialogueController : MonoBehaviour
{
    private AudioSource audioSource;
    public TMP_Text DialogueTMP;
    public Image dialogueBackground;
    [SerializeField] private List<Dialogue> dialogue;
    private int dialogueCounter;
    
    
    
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
        StartCoroutine(SecondsCounter());
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
        if (dialogueCounter == 0 &&
            !GameManager.instance.expulsadoPega)
        {
            DialogueTMP.text = dialogue[0].dialogueText;
            audioSource.clip = dialogue[0].dialogueSound;

            audioSource.Play();
        }
        else if (dialogueCounter == 3 &&
                 !GameManager.instance.expulsadoPega)
        {
            DialogueTMP.text = dialogue[1].dialogueText;
            audioSource.clip = dialogue[1].dialogueSound;

            audioSource.Play();
        }
        else if (dialogueCounter == 5 &&
                 !GameManager.instance.expulsadoPega)
        {
            DialogueTMP.text = dialogue[2].dialogueText;
            audioSource.clip = dialogue[2].dialogueSound;

            audioSource.Play();   
        }
        else if (dialogueCounter == 7 &&
                 !GameManager.instance.expulsadoPega)
        {
            DialogueTMP.text = dialogue[3].dialogueText;
            audioSource.clip = dialogue[3].dialogueSound;

            audioSource.Play();
        }
        else if (dialogueCounter == 9 &&
                 !GameManager.instance.expulsadoPega)
        {
            DialogueTMP.text = dialogue[4].dialogueText;
            audioSource.clip = dialogue[4].dialogueSound;

            audioSource.Play();
        }
    }
    
    private void MultiPressAudio()
    {
        GameManager.instance.expulsadoPega = true;
        GameManager.instance.finalesComprobation = true;
        // Acción especial cuando se detectan múltiples pulsaciones rápidas
        Debug.Log("Ejecutando acción especial por múltiples pulsaciones rápidas.");
        DialogueTMP.text = dialogue[5].dialogueText;
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




