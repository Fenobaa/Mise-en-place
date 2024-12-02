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
        if (PlayerIsOnArea && Input.GetKeyDown(KeyCode.E))
        {
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
        if (dialogueCounter == 0)
        {
            DialogueTMP.text = dialogue[0].dialogueText;
            audioSource.clip = dialogue[0].dialogueSound;

            audioSource.Play();
        }
        else if (dialogueCounter == 1)
        {
            DialogueTMP.text = dialogue[1].dialogueText;
            audioSource.clip = dialogue[1].dialogueSound;

            audioSource.Play();
        }
        else if (dialogueCounter == 2)
        {
            DialogueTMP.text = dialogue[2].dialogueText;
            audioSource.clip = dialogue[2].dialogueSound;

            audioSource.Play();   
        }
        else if (dialogueCounter == 3)
        {
            DialogueTMP.text = dialogue[3].dialogueText;
            audioSource.clip = dialogue[3].dialogueSound;

            audioSource.Play();
        }
        else if (dialogueCounter == 4)
        {
            DialogueTMP.text = dialogue[4].dialogueText;
            audioSource.clip = dialogue[4].dialogueSound;

            audioSource.Play();
        }
        else if (dialogueCounter == 5)
        {
            DialogueTMP.text = dialogue[5].dialogueText;
            audioSource.clip = dialogue[5].dialogueSound;

            audioSource.Play();
        }
        else if (dialogueCounter == 6)
        {
            DialogueTMP.text = dialogue[6].dialogueText;
            audioSource.clip = dialogue[6].dialogueSound;

            audioSource.Play();
        }
  
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




