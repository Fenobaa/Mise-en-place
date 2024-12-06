using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsoCuchillo : MonoBehaviour
{
    private Cambiodeobjetos Cambio;
    
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
                SFXManager.Instance.StabCeramic();
            }
            Anim.SetTrigger("Stab");
        }
    }
}
