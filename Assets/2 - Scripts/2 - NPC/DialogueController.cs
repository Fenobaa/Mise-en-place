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
    
    //Dialogue Detection
    private bool PlayerIsOnArea;
    private int RandomIndex;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (PlayerIsOnArea && Input.GetKeyDown(KeyCode.E))
        {
            RandomIndex = Random.Range(0, dialogue.Count);
            DialogueTMP.text = dialogue[RandomIndex].dialogueText;
            audioSource.clip = dialogue[RandomIndex].dialogueSound;

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




