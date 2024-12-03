using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsoCuchillo : MonoBehaviour
{
    private Cambiodeobjetos Cambio;
    
    private AudioSource audioSource;
    public AudioClip wallSound;
    public bool isOntriggerWall;
    
    public Animator Anim;


    private void Awake()
    {
        Cambio = FindObjectOfType<Cambiodeobjetos>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (isOntriggerWall)
            {
                audioSource.clip = wallSound;
                audioSource.Play();
            }
            Anim.SetTrigger("Stab");
        }
    }
}
